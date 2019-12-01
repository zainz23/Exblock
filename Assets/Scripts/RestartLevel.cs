using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class RestartLevel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Ignore weapons/bullets
        
        if (collision.gameObject.GetComponent("destroyXCube")  ) {
            return;
        }

        Ammo.ResetAmmo();
        ScoreText.score = 0;
        SteamVR_LoadLevel.Begin("CastleRaid");
    }
}
