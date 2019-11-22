using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script primarily handles the "mechanics"
// of throwing the spell ball
// Methods are accessed via BallHand.cs
public class BallBehavior : MonoBehaviour
{
    public Transform handle;         // Position of ball


    public Rigidbody rb;
    public float currScale = 0.5f;        // Starting/Current size of ball
    public float scaleLimit = 1.5f;     // Max size of ball

    // Particles
    private ParticleSystem ballEffect;
    public GameObject explosionEffect;  // Which is a child object of the ball effect

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ballEffect = gameObject.GetComponent<ParticleSystem>();
        // When we spawn the ball, we want to immediately start growing it
        //  Note: Coroutines are functions with a yield statement inside
        //        a yield statement stops processing at that point and waits until next frame before continuing
        //        (Kind of like a timer as it runs with the main script)
        StartCoroutine(GrowBall() );
    }

    // Update is called once per frame
    void Update()
    {
        if (handle)
        {
            // Source to where we want to be
            transform.position = Vector3.Lerp(transform.position, handle.position, 0.9f);
        }
    }

    // Actual throwing
    public void Throw(Vector3 handAngleVelocity, Vector3 handVelocity)
    {
        // Stop the ball from growing when we throw it
        StopAllCoroutines();
        // Updating based on what the controller has when its thrown
        rb.angularVelocity = handAngleVelocity;
        rb.velocity = handVelocity;
        // We want it to behave as a normal object in real world
        rb.isKinematic = false;
        // No longer have handle so it doesn't follow hand
        handle = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Kill();
    }

    private void Kill()
    {
        // Stop fireball effect
        ballEffect.Stop();
        // Turn on explosion effect
        explosionEffect.SetActive(true);
        // then destroy whole game object
        Destroy(gameObject, 2f);
    }

    public IEnumerator GrowBall()
    {
        while (currScale < scaleLimit)
        {
            // Increase scale
            currScale += 0.1f;
            // Vector represents scale as it grows
            Vector3 ballScale = new Vector3(currScale, currScale, currScale);
            // Update this object
            transform.localScale = ballScale;
            yield return new WaitForSeconds(0.1f);
        }
    }


}

/*
// a reference to the action
public SteamVR_Action_Boolean shoot;
// a reference to the hand
private SteamVR_Input_Sources handType;

private Interactable interactable;

public Hand leftHand; // use to find hand
public Hand rightHand; // use to find hand
Hand hand;          // use hand to calculate trajectories

public BallBehavior ballPrefab;
private BallBehavior spawnedBall;

private SteamVR_Behaviour_Pose trackedObject;

void Start()
{

    interactable = GetComponent<Interactable>();
    if (interactable.attachedToHand)
    {
        // handType is the hand used (left or right)
        handType = interactable.attachedToHand.handType;

        // Check which controller used so we can calculate
        hand = rightHand;
        // Check if user used right hand (default: left)
        if (handType != leftHand.handType)
        {
            // Is using right hand
            hand = rightHand;
        }

        trackedObject = hand.GetComponent<SteamVR_Behaviour_Pose>();

        // When holding trigger
        shoot.AddOnStateDownListener(StartBall, handType);
        // When releasing trigger
        shoot.AddOnStateUpListener(ThrowBall, handType);

    }
}

// Start Ball (Instantiate)

public void StartBall(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
{
    if (interactable.attachedToHand)
    {
        spawnedBall = Instantiate(ballPrefab, transform.position, transform.rotation);
        spawnedBall.handle = transform;
    }
}


// Throw Ball
// Take velocity from hand and apply to rigidbody

public void ThrowBall(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
{
    spawnedBall.Throw(hand.GetTrackedObjectAngularVelocity() , hand.GetTrackedObjectVelocity());
    // Ball is released
    spawnedBall = null;
}


private void FixedUpdate()
{
    if (shoot.GetStateDown(trackedObject.inputSource))
    {
        if (interactable.attachedToHand)
        {
            spawnedBall = Instantiate(ballPrefab, transform.position, transform.rotation);
            spawnedBall.handle = transform;
        }
    }
    else if (shoot.GetStateUp(trackedObject.inputSource))
    {
        spawnedBall.Throw(hand.GetTrackedObjectAngularVelocity(), hand.GetTrackedObjectVelocity());
        // Ball is released
        spawnedBall = null;
    }
}

// Destroy Ball

void OnDestroy()
{

    shoot.RemoveOnStateDownListener(StartBall, handType);
    shoot.RemoveOnStateUpListener(ThrowBall, handType);
}

*/
