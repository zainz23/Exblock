using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This script helps send event messages to
//      the empty socket
public class Magazine : MonoBehaviour
{
    //  We check this to make sure user doesn't use same mag
    //    to reload
    public bool hasThrown = false;
    public GameObject emptySocket;

    void ThrownMagazine()
    {
        // We are now awaiting a new mag
        //  emptysocket starts looking for 
        //  new mags
        emptySocket.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    // Function to set thrown status
    //  called by event of throwing weapon
    void SetThrown()
    {
        hasThrown = true;
    }
}
