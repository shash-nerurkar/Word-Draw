using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance { get; private set; }
    public string current_pic = "";
    public GameObject pause_panel;
    public int hint_presses = 0;
    public List<int> correct = new List<int>();
    public List<int> incorrect = new List<int>();
    public int current_correct = 0;
    public int current_incorrect = 0;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
}
