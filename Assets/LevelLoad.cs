using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LevelLoad : MonoBehaviour
{
    [Tooltip("Scene name to load")]
    public string levelToLoad;
    void OnCollisionEnter(Collision collision)
    {
        // Ignore weapons/bullets
        if (collision.gameObject.GetComponent("destroyXCube") )
        {
            return;
        }
        // Reset ammo and score since they are static
        Ammo.ResetAmmo();
        ScoreText.score = 0;
        SteamVR_LoadLevel.Begin(levelToLoad);
    }
}
