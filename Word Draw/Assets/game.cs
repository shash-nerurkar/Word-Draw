using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    GameObject help_text;

    GameObject score;

    string base_folder = "../New Unity Project/Assets/Resources/pictures";
    public List<string> pictures = new List<string>();
    string current_pic;
    GameObject picture;

    GameObject shelf_answer;
    GameObject shelf_underline;

    GameObject inventory;
    int inv_rows = 5;
    int inv_columns = 2;
    Vector2 inv_button_size;
    Vector2 inv_space_between = new Vector2(10, 10);
    public GameObject inventory_btn;

    GameObject hintbtn;

    IEnumerator hint_coroutine;

    private void Start()
    {
        hintbtn = transform.GetChild(1).GetChild(3).gameObject;

        GameSystem.Instance.pause_panel = transform.GetChild(5).gameObject;
        help_text = transform.GetChild(6).gameObject;
        GameSystem.Instance.pause_panel.SetActive(false);

        picture = transform.GetChild(2).GetChild(0).gameObject;
        shelf_answer = transform.GetChild(3).GetChild(0).gameObject;
        shelf_underline = transform.GetChild(3).GetChild(1).gameObject;

        score = transform.GetChild(1).GetChild(0).GetChild(1).gameObject;

        inventory = transform.GetChild(4).gameObject;
        inv_button_size.x = (inventory.GetComponent<RectTransform>().rect.width - (inv_columns + 1) * inv_space_between.x) / inv_columns;
        inv_button_size.y = (inventory.GetComponent<RectTransform>().rect.height - (inv_rows + 1) * inv_space_between.y) / inv_rows;
    }

    public void StartGame()
    {
        transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Animation>().Play("star_rotate");
        score.GetComponent<Text>().text = "0";
        help_text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        help_text.GetComponent<Text>().text = "SPELL THE PICTURE USING THE LETTERS IN THE RED BOX!";
        transform.GetChild(5).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "PAUSED";
        transform.GetChild(1).GetChild(2).GetComponent<Button>().interactable = false;
        transform.parent.GetChild(1).gameObject.SetActive(true);

        foreach (string pic_file in Directory.GetFiles(base_folder))
            if(Path.GetExtension(pic_file) == ".png")
                pictures.Add(pic_file.Substring(0, pic_file.LastIndexOf(".png")).Replace(base_folder + "\\", ""));
        ShowPicture();
    }

    public void ShowPicture()
    {
        hint_coroutine = ShowHint();
        StartCoroutine(hint_coroutine);

        help_text.GetComponent<Text>().color = new Color(1, 1, 1, 1);
        help_text.GetComponent<Text>().text = "SPELL THE PICTURE USING THE LETTERS IN THE GOLDEN BOX!";

        current_pic = pictures[UnityEngine.Random.Range(0, pictures.Count)];
        GameSystem.Instance.current_pic = current_pic;
        picture.GetComponent<Image>().sprite = Resources.Load<Sprite>("pictures/" + current_pic);

        shelf_answer.GetComponent<Text>().text = "";
        shelf_underline.GetComponent<Text>().text = "";

        StringBuilder jumbled_pic = new StringBuilder(current_pic);

        for (int i = 0; i < current_pic.Length; i++)
        {
            int randi = UnityEngine.Random.Range(0, current_pic.Length);
            char temp = jumbled_pic[i];
            jumbled_pic[i] = jumbled_pic[randi];
            jumbled_pic[randi] = temp;
        }

        for (int i=0; i<(current_pic.Length/inv_rows==0 ? current_pic.Length%inv_rows : inv_rows); i++)
        {
            for(int j=0; j<(current_pic.Length/inv_rows + (current_pic.Length%inv_rows >= i+1 ? 1 : 0)); j++)
            {
                Transform inv_btn_prefab_trans = Instantiate(inventory_btn).transform;
                inv_btn_prefab_trans.parent = inventory.transform;
                inv_btn_prefab_trans.localPosition = new Vector3(-inventory.GetComponent<RectTransform>().rect.width/2 + inv_space_between.x + (inv_button_size.x + inv_space_between.x)*j + inv_button_size.x/2, 
                                                                 -inventory.GetComponent<RectTransform>().rect.height/2 + inv_space_between.y + (inv_button_size.y + inv_space_between.y)*i + inv_button_size.y/2, 
                                                                 0);
                inv_btn_prefab_trans.GetChild(0).GetComponent<RectTransform>().sizeDelta = inv_button_size;
                inv_btn_prefab_trans.GetChild(0).GetChild(0).GetComponent<RectTransform>().sizeDelta = inv_button_size;
                inv_btn_prefab_trans.GetChild(0).GetChild(0).GetComponent<Text>().text = jumbled_pic[i + j*inv_rows].ToString().ToUpper();
                shelf_underline.GetComponent<Text>().text += "_ ";
            }
        }

    }

    void PictureComplete()
    {
        StopCoroutine(hint_coroutine);
        hintbtn.GetComponent<Button>().interactable = false;

        GameSystem.Instance.correct.Add(GameSystem.Instance.current_correct);
        GameSystem.Instance.incorrect.Add(GameSystem.Instance.current_incorrect);
        GameSystem.Instance.current_correct = 0;
        GameSystem.Instance.current_incorrect = 0;

        for (int i=0; i< shelf_answer.GetComponent<Text>().text.Length; i+=2)
        {
            if(shelf_answer.GetComponent<Text>().text[i].ToString().ToLower() != current_pic[i / 2].ToString())
            {
                if(current_pic.Length*2/3 < (i + 2) / 2)
                {
                    for (int j = 0; j < 2; j++)
                        transform.GetChild(0).GetChild(j + 1).gameObject.GetComponent<Animation>().Play("star_appear");
                    score.GetComponent<Text>().text = (Int32.Parse(score.GetComponent<Text>().text) + 2).ToString();
                }
                else if (current_pic.Length / 3 < (i + 2) / 2)
                {
                    transform.GetChild(0).GetChild(1).gameObject.GetComponent<Animation>().Play("star_appear");
                    score.GetComponent<Text>().text = (Int32.Parse(score.GetComponent<Text>().text) + 1).ToString();
                }
                help_text.GetComponent<Text>().color = new Color(1, 0, 0, 1);
                help_text.GetComponent<Text>().text = "AWW, THAT'S INCORRECT! THE CORRECT ANSWER IS " + current_pic.ToUpper() + "!";
                break;
            }
            else if(i == shelf_answer.GetComponent<Text>().text.Length - 2)
            {
                for (int j = 0; j < 3; j++)
                    transform.GetChild(0).GetChild(j + 1).gameObject.GetComponent<Animation>().Play("star_appear");
                score.GetComponent<Text>().text = (Int32.Parse(score.GetComponent<Text>().text) + 3).ToString();
                help_text.GetComponent<Text>().color = new Color(0, 1, 0, 1);
                help_text.GetComponent<Text>().text = "THAT'S CORRECT! AMAZING JOB, KID!";
                pictures.Remove(current_pic);
            }
        }

        for (int i = 0; i < inventory.transform.childCount; i++)
            Destroy(inventory.transform.GetChild(i).gameObject);

        if (pictures.Count > 0)
            transform.GetChild(1).GetChild(2).GetComponent<Button>().interactable = true;
        else
        {
            help_text.GetComponent<Text>().color = new Color(0, 1, 0, 1);
            help_text.GetComponent<Text>().text = "CONGRATULATIONS! YOU WIN!";
            GameSystem.Instance.pause_panel.SetActive(true);
            GameSystem.Instance.pause_panel.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "YOU WIN!";
            GameSystem.Instance.pause_panel.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        for(int i=0; i<inventory.transform.childCount; i++) 
        {
            if(inventory.transform.GetChild(i).childCount != 0)
                break;
            else if(i == inventory.transform.childCount - 1)
                PictureComplete();
        }
    }
    IEnumerator ShowHint()
    {
        yield return new WaitForSeconds(10);

        hintbtn.GetComponent<Button>().interactable = true;
    }
}
