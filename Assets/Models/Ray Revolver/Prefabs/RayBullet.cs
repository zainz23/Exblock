﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class RayBullet : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {

            Rigidbody rb = GetComponent<Rigidbody>();
            float rbSpeed = rb.velocity.sqrMagnitude;
            bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;

            if (rbSpeed > 0.1f || hitBlock && collision.gameObject.tag.Equals("grayCube"))
            {
                collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
                gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
            }
            if (!collision.gameObject.tag.Equals("RayRevolver") )
            {
                Destroy(gameObject);
            }
        }

    }
}