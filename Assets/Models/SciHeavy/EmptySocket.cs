using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script handles most of the logic for when a user wants to
//      reload his gun. Empty socket waits for a "magazine" clip
//      creating a clone of the prefab mag and then destroying the old one
//      while activating the clone. Finally setting itself to false since the gun
//      is considered "reloaded"
public class EmptySocket : MonoBehaviour
{

    public GameObject mag;              // PREFAB of the gun mag (not the instantiated instance)
    private GameObject cloneMag;        // Create new instance

    private GameObject spawnLocation;   // Location of the mag for this gun

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Magazine>() != null && collider.GetComponent<Magazine>().hasThrown == false)
        {
            spawnLocation = transform.parent.GetChild(0).gameObject;
            // We begin instantiating a new mag that takes the place of the old "destroyed" mag
            cloneMag = Instantiate(mag, spawnLocation.transform.position, spawnLocation.transform.rotation);
            // We set Kinematic to true since we only want to worry about physics when we pickup the mag
            cloneMag.GetComponent<Rigidbody>().isKinematic = true;  
            // Box collider was off before, so lets turn it on for the next pickup..
            cloneMag.GetComponent<BoxCollider>().enabled = true;
            // This sets the cloned mag as a child of the parent; which is what the controller is tracking
            cloneMag.transform.SetParent(gameObject.transform.parent);
            // Old mag destroyed; this also removes it from the players hand
            Destroy(collider.gameObject);
            // Now that it's destroyed, lets turn on the new mag we had ready
            cloneMag.SetActive(true);
            // Turn off empty socket since we are no longer looking for a new magazine in the gun
            gameObject.SetActive(false);
        }
    }
}
