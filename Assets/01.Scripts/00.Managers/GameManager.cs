using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : SingleTon <GameManager>
{
    public Player Player{ get; private set; }
    

    private void Update()
    {
       
            if (Input.GetMouseButtonDown(0)) // 좌클릭
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit)) // 3D Raycast
                {
                    Debug.Log("Ray hit (3D): " + hit.collider.gameObject.name);
                }
            }
        
    }

    
    
    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Start()
    {
        Player = FindObjectOfType<Player>();
       
      
    }
}
