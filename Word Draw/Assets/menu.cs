using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    void Start()
    {
        transform.parent.GetChild(1).gameObject.SetActive(false);
    }
}
