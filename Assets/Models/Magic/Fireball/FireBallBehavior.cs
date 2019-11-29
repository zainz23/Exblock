using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// This script handles the lifetime behavior
// of an instantiated fire ball
public class FireBallBehavior : MonoBehaviour
{
    // Particle
    public GameObject explosionPrefab;  // Which is a child object of the ball effect

    // List of tags to ignore colliding with
    string[] ignoreList = { "RayRevolver", "RuneShield", "RuneHammer", "RuneSword", "IceBall", "Player", "LeftHand", "RightHand", "Respawn" };

    private void OnCollisionEnter(Collision collision)
    {
        bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;

        // Iterate through collision list and ignore colliding..
        for (int i = 0; i < ignoreList.Length; i++)
        {
            if (collision.gameObject.tag.Equals(ignoreList[i]))
            {
                Physics.IgnoreCollision(collision.transform.GetComponent<Collider>(), GetComponent<Collider>());
                return;
            }
        }

        // Collides with block
        if (hitBlock && collision.gameObject.tag.Equals("yellowCube"))
        {
            Kill();
            collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            // Destroy on contact with anything else
            Destroy(gameObject);
        }

    }

    private void Kill()
    {
        // Instantiated clone of explosion prefab
        GameObject go = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        // Destroy block
        Destroy(gameObject);
        // Destroy after playing effect
        Destroy(go, go.GetComponent<ParticleSystem>().main.duration);
    }

}
