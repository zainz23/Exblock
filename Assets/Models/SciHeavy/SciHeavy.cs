using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Valve.VR.InteractionSystem
{
    public class SciHeavy : MonoBehaviour
    {
        // a reference to the action
        public SteamVR_Action_Boolean fire;
        // a reference to the hand
        private SteamVR_Input_Sources handType;

        private Interactable interactable;

        public Rigidbody projectile;
        public float speed = 20;

        private GameObject spawnLocation;

        static private bool firstTimeGrab = false;

        // Ammo to display over gun
        public Text ammoText;


        // Clicking sound when out of ammo
        public AudioClip gunShotSound;
        // Clicking sound when out of ammo
        public AudioClip clickSound;
        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            interactable = GetComponent<Interactable>();
            spawnLocation = transform.GetChild(1).gameObject;
            if (interactable.attachedToHand)
            {
                // Depending on which hand we are using...
                handType = interactable.attachedToHand.handType;
                fire.AddOnStateDownListener(Fire, handType);
            }
        }

        void Update()
        {
            ammoText.text = Ammo.ammoSciHeavy.ToString() + " / " + Ammo.maxAmmoSciHeavy.ToString();
        }

        void Fire(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            // Dont instantiate bullet if we're using trigger to grab gun
            /*
            if (!firstTimeGrab)
            {
                firstTimeGrab = true;
                return;
            }
            */
            if (Ammo.ammoSciHeavy > 0)
            {
                Rigidbody instantiatedProjectile = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = spawnLocation.transform.TransformDirection(new Vector3(0, 0, speed));
                Ammo.ammoSciHeavy -= 1;
                // Play gun shot
                audioSource.PlayOneShot(gunShotSound, 0.25f);
            }
            else if (Ammo.ammoSciHeavy == 0)
            {
                // out of ammo
                audioSource.PlayOneShot(clickSound, 0.5f);

            }

        }

        void OnDestroy()
        {
            fire.RemoveOnStateDownListener(Fire, handType);
            firstTimeGrab = false;  // Reset incase user grabs gun again
        }
    }
}