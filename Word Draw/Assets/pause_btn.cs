using UnityEngine;
using UnityEngine.UI;

public class pause_btn : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(PauseGame);
    }
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        GameSystem.Instance.pause_panel.SetActive(true);
    }
}
