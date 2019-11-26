using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class RayRevolver : MonoBehaviour
    {
        // a reference to the action
        public SteamVR_Action_Boolean fire;
        // a reference to the hand
        private SteamVR_Input_Sources handType;

        private Interactable interactable;

        public Rigidbody projectile;
        public float speed = 20;

        private GameObject spawnLocation;

        void Start()
        {
            interactable = GetComponent<Interactable>();
            spawnLocation = transform.GetChild(0).gameObject;
            if (interactable.attachedToHand)
            {
                // Depending on which hand we are using...
                handType = interactable.attachedToHand.handType;
                fire.AddOnStateDownListener(Fire, handType);
            }
        }
        
        void Fire(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, spawnLocation.transform.position, spawnLocation.transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = spawnLocation.transform.TransformDirection(new Vector3(0, 0, speed));
        }

        void OnDestroy()
        {
            fire.RemoveOnStateDownListener(Fire, handType);
        }
    }
}