using UnityEngine;
using UnityEngine.UI;

public class quit_btn : MonoBehaviour
{
    GameObject pause_panel;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(QuitGame);
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}