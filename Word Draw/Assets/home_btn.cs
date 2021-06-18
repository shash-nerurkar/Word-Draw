using UnityEngine;
using UnityEngine.UI;

public class home_btn : MonoBehaviour
{
    GameObject pause_panel;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoToMenu);
    }
    public void GoToMenu()
    {
        Time.timeScale = 1.0f;
        for(int i=0; i<transform.parent.parent.parent.GetChild(4).childCount; i++)
            Destroy(transform.parent.parent.parent.GetChild(4).GetChild(i).gameObject);
        transform.parent.parent.parent.GetChild(1).GetChild(3).GetComponent<Button>().interactable = false;
        transform.parent.parent.parent.parent.GetChild(2).gameObject.SetActive(true);
        transform.parent.parent.gameObject.SetActive(false);
        transform.parent.parent.parent.gameObject.SetActive(false);
    }
}
