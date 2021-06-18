using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class hint_btn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowHint);
    }
    void ShowHint()
    {
        GameSystem.Instance.hint_presses++;
        int num_left = 0;
        for (int i = 0; i < transform.parent.parent.GetChild(4).childCount; i++)
            if (transform.parent.parent.GetChild(4).GetChild(i).childCount == 0)
                num_left++;
        for (int i = 0; i < transform.parent.parent.GetChild(4).childCount; i++)
        {
            if (transform.parent.parent.GetChild(4).GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text == GameSystem.Instance.current_pic[num_left].ToString().ToUpper())
                transform.parent.parent.GetChild(4).GetChild(i).GetChild(0).GetComponent<Animator>().Play("inventory_btn_highlight", -1, 0f);
        }
        GetComponent<Button>().interactable = false;
        StartCoroutine(Wait30());
    }
    IEnumerator Wait30()
    {
        yield return new WaitForSeconds(30);

        GetComponent<Button>().interactable = true;
    }
}
