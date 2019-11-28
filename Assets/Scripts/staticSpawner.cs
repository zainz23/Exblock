using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Description: Script that spawns a target/block X seconds after player destroys
 * Usage: Attach this script to a location (empty) gameObject to continuously spawn blocks on destruction
 *          Specify the tag you want the block to be in dropdown of the inspector
*/
public class staticSpawner : MonoBehaviour
{
    public enum TagList
    {
        redCube,
        grayCube
    }
    public float spawnTimer = 1f;   // How soon a respawn occurs after destruction
    public GameObject prefab;       // Prefab we are instantiating...
    public TagList prefabTag = TagList.redCube;   // Tag of the block we're spawning (redCube,gray, etc.)

    private GameObject clone;       // Instantiated clone of prefab
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CloneCheck());
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
                clone.tag= prefabTag.ToString();
            }
            yield return new WaitForSeconds(spawnTimer);
            yield return null;
        }

    }
}
