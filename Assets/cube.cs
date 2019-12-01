using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
/*    //public Transform bulletPrefab;
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();*/
    // Start is called before the first frame update
    void Start()
    {
/*        posOffset = transform.position;
*/    }

    // Update is called once per frame
    void Update()
    {
 
      
 
/*        transform.position +=( Time.deltaTime * transform.up)*(Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * Random.Range(0.0f,amplitude);
*/
        if (gameObject.name != "static")
        {
            transform.position += Time.deltaTime * transform.forward * 0.75f;

        }

        //Transform bullet = Instantiate(bulletPrefab) as Transform;
        //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
