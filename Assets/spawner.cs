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
    private float hd = 0.0f;

    public List<GameObject>  twoCubes;
    public bool secondWave ;

    private float[] floatArray;
    public string rawData;
    public float secondWaveTime;

    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {


        string[] spawns = rawData.Split(',');
        floatArray = new float[spawns.Length];
        foreach (string x in spawns)
        {
            Debug.Log(x);
            myStack.Enqueue(float.Parse(x));
        }
        //audioData = GetComponent<AudioSource>();
        //audioData.Play(0);
        secondWave = false;
     
        hd = (float)myStack.Dequeue();

        changeTo("yellowCube", "blueCube");

     }
        private int prev = 0;
        private int curr = 0;
   
    void changeTo(string cube1, string cube2)
    {

             twoCubes = new List<GameObject>();




        foreach ( GameObject x in cubes)
        {

            if (x.tag.Equals(cube1) || x.tag.Equals(cube2))
            {
                 twoCubes.Add(x);
                Debug.Log("found");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > hd)
        {
            Debug.Log("this is the time: " + timer);

            if (timer > secondWaveTime && !secondWave)
            {
                secondWave = true;
                changeTo("redCube", "grayCube");
                message.SetActive(true);
            }

            if (timer > secondWaveTime + 7.0f)
            {
                message.SetActive(false);


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
        //timer
        timer += (Time.deltaTime);
    }
}

