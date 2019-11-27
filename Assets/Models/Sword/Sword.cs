using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Sword : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {

            Rigidbody rb = GetComponent<Rigidbody>();
            float rbSpeed = rb.velocity.sqrMagnitude;
            bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;


            // Only count collisions with good speed so that stationary swords without momentum can't deal damage
            // always break blocks
            if (rbSpeed > 0.1f || hitBlock && collision.gameObject.tag.Equals("redCube"))
            {
                collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);

                gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
            }

        }
    }
}