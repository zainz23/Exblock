using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    private float lifeScalez;
     private float lifeSubtructScaleZ;

    public Material greenLife;
    public Material yellowLife;
    public Material redLife;

    public GameObject gameOverText;
    public GameObject spawning;
    public AudioSource gameOverSound;
    public float total;
    // Start is called before the first frame update
    void Start()
    {
         lifeScalez = gameObject.transform.localScale.y;
         lifeSubtructScaleZ = lifeScalez / 10;
        total = lifeScalez;
     }
    public void reduceLife(int amount)
    {
        lifeScalez -= lifeSubtructScaleZ / amount;
        if (lifeScalez > 0.0f)
            transform.localScale = new Vector3(transform.localScale.x, lifeScalez, transform.localScale.z);


        if (total * 0.70f < lifeScalez)
            gameObject.GetComponent<Renderer>().material = greenLife;

        else if (total * 0.30f < lifeScalez)
            gameObject.GetComponent<Renderer>().material = yellowLife;

        else
            gameObject.GetComponent<Renderer>().material = redLife;


        if(lifeScalez < 0.0f)
        {
            gameOverText.SetActive(true);
            spawning.SetActive(false);
            gameOverSound.Play();

        }
    }
    // Update is called once per frame
    void Update()
    {
 
    }
}
