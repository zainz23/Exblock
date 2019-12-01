using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreText : MonoBehaviour
{
    // Start is called before the first frame update
    public int total;
    void Start()
    {
        total = 0;
    }
    public void updateText()
    {
        total = total + 10;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "Score: " + total;

    }

    // Update is called once per frame
    void Update()
    {


    }
}