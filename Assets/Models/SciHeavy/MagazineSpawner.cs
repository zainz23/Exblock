using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineSpawner : MonoBehaviour
{

    public float spawnTimer = 1f;   // How soon a respawn occurs after pickup (Cooldown)
    public GameObject prefab;       // Prefab we are instantiating...


    private GameObject clone;       // Instantiated clone of prefab

    void BeginSpawn()
    {
        StartCoroutine(CloneCheck() );
    }

    IEnumerator CloneCheck()
    {
        while (true)
        {
            // Means it was destroyed
            if (clone == null)
            {
                // Instantiate a new one
                clone = Instantiate(prefab, transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(spawnTimer);
            yield return null;
        }
    }

    // Destroy the left behind mag
    void DestroyClone()
    {
        StopAllCoroutines();
        Destroy(clone);
    }
}
