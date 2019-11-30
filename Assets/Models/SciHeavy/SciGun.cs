using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Valve.VR.InteractionSystem
{
    public class SciGun : MonoBehaviour
    {
        // a reference to the action
        public SteamVR_Action_Boolean fire;
        // a reference to the hand
        private SteamVR_Input_Sources handType;

        private Interactable interactable;

        public Rigidbody projectile;
        public float speed = 20;

        private GameObject spawnLocation;


        // Ammo to display over gun
        public Text ammoText;

        // Clicking sound when out of ammo
        public AudioClip gunShotSound;
        // Clicking sound when out of ammo
        public AudioClip clickSound;
        private AudioSource audioSource;

        public enum GunType
        {
            SciHeavy,
            SciPistol,
            SciRifle,
            SciSniper
        }
        public GunType prefabTag = GunType.SciHeavy;    // Default

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
            switch (prefabTag.ToString() )
            {
                case "SciHeavy":
                    ammoText.text = Ammo.ammoSciHeavy.ToString() + " / " + Ammo.maxAmmoSciHeavy.ToString();
                    break;
                case "SciPistol":
                    ammoText.text = Ammo.ammoSciPistol.ToString() + " / " + Ammo.maxAmmoSciPistol.ToString();
                    break;
                case "SciRifle":
                    ammoText.text = Ammo.ammoSciRifle.ToString() + " / " + Ammo.maxAmmoSciRifle.ToString();
                    break;
                case "SciSniper":
                    ammoText.text = Ammo.ammoSciSniper.ToString() + " / " + Ammo.maxAmmoSciSniper.ToString();
                    break;
            }
            
        }

        void Fire(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            if (prefabTag.ToString() == "SciHeavy")
            {
                AmmoCheck(ref Ammo.ammoSciHeavy);
            }
            else if (prefabTag.ToString() == "SciPistol")
            {
                AmmoCheck(ref Ammo.ammoSciPistol);
            }
            else if (prefabTag.ToString() == "SciRifle")
            {
                AmmoCheck(ref Ammo.ammoSciRifle);
            }
            else if (prefabTag.ToString() == "SciSniper")
            {
                AmmoCheck(ref Ammo.ammoSciSniper);
            }
        }

        // Changes the passed in ammo parameter
        //      x should be the static variable from Ammo.cs
        void AmmoCheck(ref int ammo)
        {
            if (ammo > 0)
            {
                Rigidbody instantiatedProjectile = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation) as Rigidbody;
                instantiatedProjectile.velocity = spawnLocation.transform.TransformDirection(new Vector3(0, 0, speed));
                ammo -= 1;
                // Play gun shot
                audioSource.PlayOneShot(gunShotSound, 0.25f);
            }
            else if (ammo == 0)
            {
                // out of ammo
                audioSource.PlayOneShot(clickSound, 0.5f);
            }
        }

        void OnDestroy()
        {
            fire.RemoveOnStateDownListener(Fire, handType);
        }
    }
}