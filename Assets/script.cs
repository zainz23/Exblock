using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{

   
    // Start is called before the first frame update
    void Start()
    {

    }

// Update is called once per frame
void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {  //If the GameObject's name matches the one you suggest, output this message in the console

        GameObject.Find("healthBar").GetComponent<healthBar>().reduceLife();

        Debug.Log("Do something here");
    }
}
