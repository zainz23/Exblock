using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Bullet : MonoBehaviour
    {
        public enum TagList
        {
            blueCube,
            yellowCube,
            redCube,
            grayCube,
            runeCube
        }
        // The tag we want to collide with
        public TagList collideTag = TagList.redCube;

        void OnCollisionEnter(Collision collision)
        {

            Rigidbody rb = GetComponent<Rigidbody>();
            bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;

            if (hitBlock && collision.gameObject.tag.Equals(collideTag.ToString() ))
            {
                collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
                gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
            }
        }

    }
}