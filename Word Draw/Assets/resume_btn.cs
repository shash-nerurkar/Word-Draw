using UnityEngine;
using UnityEngine.UI;

public class resume_btn : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(UnpauseGame);
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        GameSystem.Instance.pause_panel.SetActive(false);
    }
}
