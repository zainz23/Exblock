using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerDynamic : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] point;
   
    
    public AudioSource audioData;
    private float timer;
    private Queue myStack = new Queue();
    private float[] floatArray = { 5.05f, 6.06f, 7.08f, 8.09f, 9.09f, 10.11f, 11.12f, 12.12f, 12.13f, 14.14f, 14.15f, 15.16f, 16.17f, 17.18f, 18.18f, 18.19f, 19.19f, 20.20f, 20.21f, 21.21f, 22.22f, 22.23f, 23.24f, 23.24f, 24.25f, 25.25f, 26.26f, 37.37f, 38.38f, 38.39f, 39.39f, 39.40f, 40.41f, 41.42f, 42.42f, 42.43f, 43.43f, 44.44f, 44.45f, 45.45f, 46.46f, 47.48f, 48.49f, 49.49f, 50.50f, 50.50f, 51.51f, 52.52f, 52.53f, 53.53f, 54.54f, 54.55f, 55.56f, 55.56f, 56.57f, 57.57f, 58.59f, 59.59f, 36.01f, 37.01f, 38.02f, 38.03f, 39.04f, 40.05f, 41.05f, 42.06f, 42.07f, 43.08f, 44.08f, 45.09f, 46.10f, 46.11f, 47.12f, 47.12f, 48.13f, 49.13f, 50.14f, 50.14f, 51.15f, 52.16f, 52.17f, 53.17f, 54.18f, 54.19f, 55.19f, 55.20f, 56.21f, 57.22f, 58.22f, 58.22f, 59.24f, 60.24f, 60.25f, 61.25f, 62.26f, 62.27f, 63.28f, 63.28f, 64.29f, 65.30f, 66.30f, 71.36f, 72.37f, 73.38f, 74.38f, 74.38f, 75.39f, 76.40f, 77.41f, 78.42f, 78.43f, 79.44f, 79.44f, 80.45f, 81.46f, 82.46f, 82.46f, 83.48f, 84.48f, 84.49f, 85.49f, 86.50f, 86.51f, 87.51f, 88.53f, };
    private float hd = 0.0f;
 


    // Start is called before the first frame update
    void Start()
    {
        //audioData = GetComponent<AudioSource>();
        //audioData.Play(0);

        foreach (float x in floatArray)
        {
            myStack.Enqueue(x);
        }
        hd = (float)myStack.Dequeue();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > hd)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], point[Random.Range(0, 4)]);
            cube.transform.localPosition = Vector3.zero;
            //cube.transform.Rotate()
            //    timer -= 1.5f;
            hd = (float)myStack.Dequeue();
        }
        Debug.Log("this is the time: "+hd);
        //timer
        timer += (Time.deltaTime);
    }
}
