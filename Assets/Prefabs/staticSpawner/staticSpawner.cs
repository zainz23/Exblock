using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Description: Script that spawns a target/block X seconds after player destroys
 * Usage: Attach this script to a location (empty) gameObject to continuously spawn blocks on destruction
 *          Specify the tag you want the block to be in dropdown of the inspector
*/
public class staticSpawner : MonoBehaviour
{
    // List of materials to use in relation to tags
    public Material[] materials;
    public enum TagList
    {
        blueCube,
        yellowCube,
        redCube,
        grayCube,
        runeCube
    }
    public float spawnTimer = 1f;   // How soon a respawn occurs after destruction
    public GameObject prefab;       // Prefab we are instantiating...
    public TagList prefabTag = TagList.redCube;   // Tag of the block we're spawning (redCube,gray, etc.)
    private Material mat;

    private GameObject clone;       // Instantiated clone of prefab
    // Start is called before the first frame update
    void Start()
    {
        // Find the matching material from list
        for (int i = 0; i < materials.Length; i++)
        {
            // Materials prints extra nonsense so we only want compare beginning
            if (materials[i].ToString().StartsWith(prefabTag.ToString() ) )
            {
                // Debug.Log(prefabTag.ToString());
                mat = materials[i];
            }
        }
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
                clone.GetComponent<Renderer>().material = mat;
                clone.tag= prefabTag.ToString();
            }
            yield return new WaitForSeconds(spawnTimer);
            yield return null;
        }

    }
}
