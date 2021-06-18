using UnityEngine;
using UnityEngine.UI;

public class play_btn : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        transform.parent.parent.GetChild(1).gameObject.SetActive(true);
        transform.parent.parent.GetChild(1).gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
