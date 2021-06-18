using UnityEngine;
using UnityEngine.UI;

public class inventory_btn : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddLetter);
    }
    public void AddLetter()
    {
        GameObject.Find("shelf").transform.GetChild(0).GetComponent<Text>().text += transform.GetChild(0).gameObject.GetComponent<Text>().text + " ";
        int num_left = 0;
        for (int i = 0; i < transform.parent.parent.parent.GetChild(4).childCount; i++)
            if (transform.parent.parent.parent.GetChild(4).GetChild(i).childCount == 0)
                num_left++;
        if (transform.GetChild(0).gameObject.GetComponent<Text>().text == GameSystem.Instance.current_pic[num_left].ToString().ToUpper())
            GameSystem.Instance.current_correct++;
        else
            GameSystem.Instance.current_incorrect++;
        Destroy(gameObject);
    }
}
