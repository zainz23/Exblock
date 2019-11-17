using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class RayRevolver : MonoBehaviour
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
        {

            Rigidbody rb = GetComponent<Rigidbody>();
            float rbSpeed = rb.velocity.sqrMagnitude;
            bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;


            if (rbSpeed > 0.1f || hitBlock)
            {
                collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
                gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
            }

        }
    }
}