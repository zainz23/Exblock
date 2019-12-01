using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawner : MonoBehaviour
{
    // List of balls to spawn
    public enum Ball
    {
        rockBall,
        lavaBall,
        groundBall,
        waterBall
    }
    [Tooltip("Set what you would like to spawn for first wave")]
    public Ball ballOne;
    public Ball ballTwo;

    [Tooltip("Second wave ball spawn")]
    public Ball ballThree;
    public Ball ballFour;

    public AudioSource audioData;
    private float timer;
    public Transform[] point;


    public GameObject[] destroyables;
    public List<GameObject> weapons;
    public float[] waveStarts;
    private bool[] waveBools;
    public GameObject message;
    public GameObject messageText;
    private Text txt;
    private int waveNum = 0;
    private List<GameObject> weaponsNeeded;


    private Queue myStack = new Queue();

    private float hd = 0.0f;

    public string rawData;
    public bool[] staticBlocks = new bool[10];


    // Start is called before the first frame update
    void Start()
    {
        //all static
        /*
        for (int i = 0; i < staticBlocks.Length; i++)
            staticBlocks[i] = true;
        */


        string[] spawns = rawData.Split(',');
        //each x is a ball spawn 
        foreach (string x in spawns)
        {
            // Debug.Log(x);
            myStack.Enqueue(float.Parse(x));
        }
        //same length of waveStarts
        waveBools = new bool[waveStarts.Length];

        hd = (float)myStack.Dequeue();

        weaponsNeeded = new List<GameObject>();
        weaponsNeeded.Add(weapons[0]);
        message.GetComponent<secondWave>().wave(weaponsNeeded);
        weaponsNeeded.Clear();
        message.SetActive(true);

    }


    private int prev = 0;
    private int curr = 0;

    private float endGame = 0.0f;




    // Update is called once per frame
    void Update()
    {

        // Debug.Log("this is the time: " + timer);
        //remove 1st wave mesage
        if (waveNum < waveStarts.Length)
        {


            if (!waveBools[waveNum] && waveNum == 0 && timer > 7.0f)
            {
                message.SetActive(false);
            }
            //HIDE message after 7 secs
            if (timer > waveStarts[waveNum] + 7.0f)
            {
                message.SetActive(false);
                if (waveNum < waveStarts.Length)
                    waveNum++; //check next wave time
            }


            //SHOW message
            if (timer > waveStarts[waveNum] && !waveBools[waveNum])
            {
                //only one weapon
                if (waveNum == 0)
                {
                    weaponsNeeded.Clear();
                    weaponsNeeded.Add(weapons[1]);
                    message.GetComponent<secondWave>().wave(weaponsNeeded);
                    weaponsNeeded.Clear();


                }
                else
                {//two weapons 
                    weaponsNeeded.Clear();
                    weaponsNeeded.Add(weapons[2]);
                    weaponsNeeded.Add(weapons[3]);
                    message.GetComponent<secondWave>().wave(weaponsNeeded);
                    weaponsNeeded.Clear();


                }

                waveBools[waveNum] = true;
                txt = messageText.GetComponent<Text>();
                txt.text = "Get ready for wave " + (waveNum + 2) + "! \nYou will need the following weapon(s):";
                message.SetActive(true);

            }


        }




        if (timer > hd && myStack.Count > 0)
        {

            //ramdom postiton on spawning
            curr = Random.Range(0, point.Length);
            if (curr == prev)
            {
                if (curr == 4)
                    curr = 0;
                else
                    curr++;
            }
            prev = curr;



            //make ball appear
            GameObject cube = new GameObject();
            if (waveNum == 0)
            {
                cube = Instantiate(destroyables[0], point[curr]);


            }
            else if (waveNum == 1)
            {

                cube = Instantiate(destroyables[1], point[curr]);

            }
            else
            {

                cube = Instantiate(destroyables[Random.Range(2, 4)], point[curr]);

            }

            if (staticBlocks[curr])//for 3 & 8. we start from 0
                cube.name = "static";

            cube.transform.localPosition = Vector3.zero;
            //cube.transform.Rotate()
            //    timer -= 1.5f;
            hd = (float)myStack.Dequeue();
        }
        if (myStack.Count == 1) { endGame = timer + 4.0f; }



        if (myStack.Count == 0 && timer > endGame)
        {
            weaponsNeeded.Clear();
            message.GetComponent<secondWave>().wave(weaponsNeeded);
            txt = messageText.GetComponent<Text>();
            txt.text = "Victory!";
            message.SetActive(true);
            audioData.Stop();

        }



        Debug.Log("timer " + timer);

        //timer
        timer += (Time.deltaTime);
    }

}
