
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script can be attached to any weapon
//      Change the cubeToDestroy to set what the weapon can destroy
namespace Valve.VR.InteractionSystem
{
    public class destroyXCube : MonoBehaviour
    {
        // Enumerated list of balls that can be destroyed
        // This can be changed in the inspector
        public enum TagList
        {
            rockBall,
            lavaBall,
            groundBall,
            waterBall,
            runeCube
        }
        [Tooltip("What do you want this weapon to destroy?")]
        public TagList cubeToDestroy = TagList.rockBall;    // Default

        [Tooltip("Should this object be destroyed on collision?")]
        public bool destroySelf;

        void OnCollisionEnter(Collision collision)
        {
            // Boolean to see if player hit a block/ball
            bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;
            // Check if player has hit the correct block with the correct weapon
            if (hitBlock && collision.collider.gameObject.tag == cubeToDestroy.ToString())
            {
                collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
                ScoreText.score += 10;
                gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
                if (destroySelf)
                {
                    Destroy(gameObject);
                }
            }
            // Check if they hit a block with the wrong weapon
            else if (hitBlock)
            {
                // Destroy the incorrect block
                collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
                if (GameObject.Find("healthBar") )
                {
                    // Player takes damage
                    GameObject.Find("healthBar").GetComponent<healthBar>().reduceLife(1);
                }
                // Sould we destroy this object?
                if (destroySelf)
                {
                    Destroy(gameObject);
                }
                
            }
            

        }
    }
}
