using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondWave : MonoBehaviour
{
    public GameObject[] weapons;
    public Transform[] point;


     void Start()
    {
 
        GameObject weapon1 = Instantiate(weapons[0], point[0]);
        GameObject weapon2 = Instantiate(weapons[1], point[1]);

 
        weapon1.transform.localPosition = Vector3.zero;
        weapon2.transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);

    }
    

    // Update is called once per frame
    void Update()
    {
 
    }
}
