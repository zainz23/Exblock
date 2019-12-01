using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Ammo to display over gun
    public Text ammoText;

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Score: " + ScoreText.total.ToString();
    }
}
