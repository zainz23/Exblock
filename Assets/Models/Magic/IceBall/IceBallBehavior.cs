using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// This script handles the lifetime behavior
// of an instantiated ice ball
public class IceBallBehavior : MonoBehaviour
{

    // Particle
    public GameObject explosionPrefab;  // Which is a child object of the ball effect

    private void OnCollisionEnter(Collision collision)
    {
        bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;
        // Ignore collision on shield or player
        if (collision.gameObject.tag.Equals("RuneShield") || collision.gameObject.tag.Equals("Player") )
        {
            Physics.IgnoreCollision(collision.transform.GetComponent<Collider>(), GetComponent<Collider>());
        }
        else if (hitBlock && collision.gameObject.tag.Equals("grayCube") )
        {
            Kill();
            collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
        }
        else
        {
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
