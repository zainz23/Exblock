using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] cubes;
    public Transform[] point;
    

    public AudioSource audioData;
    private float timer;
    private Queue myStack = new Queue();
    private float[] floatArray = { 6.06f, 7.08f, 8.09f, 9.09f, 10.11f, 11.12f, 12.12f, 12.13f, 14.14f, 14.15f, 15.16f, 16.17f, 17.18f, 18.18f, 18.19f, 19.19f, 20.20f, 20.21f, 21.21f, 22.22f, 22.23f, 23.24f, 23.24f, 24.25f, 25.25f, 26.26f, 37.37f, 38.38f, 38.39f, 39.39f, 39.40f, 40.41f, 41.42f, 42.42f, 42.43f, 43.43f, 44.44f, 44.45f, 45.45f, 46.46f, 47.48f, 48.49f, 49.49f, 50.50f, 50.50f, 51.51f, 52.52f, 52.53f, 53.53f, 54.54f, 54.55f, 55.56f, 55.56f, 56.57f, 57.57f, 58.59f, 59.59f, 60.01f, 61.01f, 62.02f, 62.03f, 63.04f, 64.05f, 65.05f, 66.06f, 66.07f, 67.08f, 68.08f, 69.09f, 70.10f, 70.11f, 71.12f, 71.12f, 72.13f, 73.13f, 74.14f, 74.14f, 75.15f, 76.16f, 76.17f, 77.17f, 78.18f, 78.19f, 79.19f, 79.20f, 80.21f, 81.22f, 82.22f, 82.22f, 83.24f, 84.24f, 84.25f, 85.25f, 86.26f, 86.27f, 87.28f, 87.28f, 88.29f, 89.30f, 90.30f, 95.36f, 96.37f, 97.38f, 98.38f, 98.38f, 99.39f, 100.40f, 101.41f, 102.42f, 102.43f, 103.44f, 103.44f, 104.45f, 105.46f, 106.46f, 106.46f, 107.48f, 108.48f, 108.49f, 109.49f, 110.50f, 110.51f, 111.51f, 112.53f };
    private float hd = 0.0f;

    public List<GameObject>  twoCubes;
    public bool secondWave = false;

    public GameObject message;
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

        changeTo("yellowCube", "blueCube");

     }
    private int prev = 0;
    private int curr = 0;
   
    void changeTo(string cube1, string cube2)
    {

        for(int i = 0; i < twoCubes.Count; i++)
            twoCubes.RemoveAt(0);
                
        foreach( GameObject x in cubes)
        {

            if (x.tag.Equals(cube1) || x.tag.Equals(cube2))
            {
                 twoCubes.Add(x);
               
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > hd)
        {
            if(timer > 36.5f)
            {
                message.SetActive(false);


            }
            else if(timer > 25.0f && !secondWave)
            {
                changeTo("redCube", "grayCube");
                message.SetActive(true);
            }

            curr = Random.Range(0, point.Length);
            if (curr == prev)
            {
                if (curr == 4)
                    curr = 0;
                else
                    curr++;

                 
            }
             prev = curr;


            GameObject cube = Instantiate(twoCubes[Random.Range(0, 2)], point[curr]);
          
            if(curr == 2 || curr == 7)//for 3 & 8. we start from 0
                cube.name = "static";

            cube.transform.localPosition = Vector3.zero;
            //cube.transform.Rotate()
            //    timer -= 1.5f;
            hd = (float)myStack.Dequeue();
        }
        Debug.Log("this is the time: " + point.Length);
        //timer
        timer += (Time.deltaTime);
    }
}

