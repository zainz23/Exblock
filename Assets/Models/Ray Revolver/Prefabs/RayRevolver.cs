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

        void Start()
        {
            interactable = GetComponent<Interactable>();
            if (interactable.attachedToHand)
            {
                // Depending on which hand we are using...
                handType = interactable.attachedToHand.handType;
                fire.AddOnStateDownListener(Fire, handType);
            }
        }
        
        void Fire(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        }

        void OnDestroy()
        {
            fire.RemoveOnStateDownListener(Fire, handType);
        }
    }
}