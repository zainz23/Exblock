using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class SciHeavyBullet : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {

            Rigidbody rb = GetComponent<Rigidbody>();
            bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;

            if (hitBlock && collision.gameObject.tag.Equals("yellowCube"))
            {
                collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
                gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
            }
            if (!collision.gameObject.tag.Equals("RayRevolver"))
            {
                Destroy(gameObject);
            }
        }

    }
}