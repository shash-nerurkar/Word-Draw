using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class star : MonoBehaviour
{
    public void PlayDisappear()
    {
        if(GetComponent<Image>().color.a == 1)
            GetComponent<Animation>().Play("star_disappear");
    }
}
