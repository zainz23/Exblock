using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDisplay : MonoBehaviour
{
    // Model of ball
    public GameObject cubeToDestroy;
    // Where on the gun to display ball
    public Transform positionDisplay;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cubeToDestroy, positionDisplay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
