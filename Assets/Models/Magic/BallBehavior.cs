using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

// This script primarily handles the "mechanics"
// of throwing the spell ball
// Methods are accessed via BallHand.cs
public class BallBehavior : MonoBehaviour
{

    // Particle
    public GameObject explosionPrefab;  // Which is a child object of the ball effect

    private void OnCollisionEnter(Collision collision)
    {
        bool hitBlock = collision.collider.gameObject.GetComponent<Block>() != null;
        if (hitBlock && collision.gameObject.tag.Equals("grayCube") )
        {
            Kill();
            collision.collider.gameObject.SendMessageUpwards("ApplyDamage", SendMessageOptions.DontRequireReceiver);
            gameObject.SendMessage("HasAppliedDamage", SendMessageOptions.DontRequireReceiver);
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
