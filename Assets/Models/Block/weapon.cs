﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public LayerMask layer;
    private Vector3 prviousPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit, 1, layer))
        {
            Destroy(hit.transform.gameObject);
        }
        prviousPos = transform.position;

    }
}
