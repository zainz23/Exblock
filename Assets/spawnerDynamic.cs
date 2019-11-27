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

    private float[] floatArray = { 1.746f, 3.333f, 4.795f, 6.423f, 8.0f, 9.651f, 11.31f, 14.357f, 16.309f, 17.693f, 19.234f, 21.100f };
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
