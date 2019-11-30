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
    [Tooltip("Attach this to empty_mag in INSPECTOR not prefabs folder")]
    public GameObject emptySocket;

    private AudioSource audioSource;
    public AudioClip magDumpSound;
    public AudioClip magLoadSound;

    public enum GunType
    {
        SciHeavy,
        SciPistol,
        SciRifle,
        SciSniper
    }
    public GunType prefabTag = GunType.SciHeavy;    // Default

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void ThrownMagazine()
    {
        // We are now awaiting a new mag
        //  emptysocket starts looking for 
        //  new mags
        emptySocket.SetActive(true);
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    void PlayMagDump()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(magDumpSound, 1f);
    }
    void PlayMagLoad()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(magLoadSound, 1f);
    }
    // Function to set thrown status
    //  called by event of throwing weapon
    void SetThrown()
    {
        hasThrown = true;
    }

    void DestroyMag()
    {
        Destroy(gameObject, 2f);
    }

    // Used when mag is grabbed/picked up
    void ZeroAmmo()
    {
        switch (prefabTag.ToString() )
        {
            case "SciHeavy":
                Ammo.ammoSciHeavy = 0;
                break;
            case "SciPistol":
                Ammo.ammoSciPistol = 0;
                break;
            case "SciRifle":
                Ammo.ammoSciRifle = 0;
                break;
            case "SciSniper":
                Ammo.ammoSciSniper = 0;
                break;
        }
        
    }
}
