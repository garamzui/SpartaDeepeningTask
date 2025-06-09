using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public StatHandler statHandler;


    void Start()
    {
        statHandler = GetComponent<StatHandler>();

    }
}
