using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class BallHand : MonoBehaviour
    {
        public GameObject prefab;       // The thing we are poofing up
        public Rigidbody attachPoint;   // Used for velocity calculations
        public float speedOffset;       // Adjustable speed setting

        public SteamVR_Action_Boolean spawn;

        private SteamVR_Behaviour_Pose trackedObj;
        FixedJoint joint;

        private void Start()
        {
            // Uses transform of controller
            trackedObj = transform.parent.GetComponent<SteamVR_Behaviour_Pose>();
        }

        private void FixedUpdate()
        {
            if (joint == null && spawn.GetStateDown(trackedObj.inputSource))
            {
                GameObject go = GameObject.Instantiate(prefab);
                go.transform.position = attachPoint.transform.position;

                joint = go.AddComponent<FixedJoint>();
                joint.connectedBody = attachPoint;
            }
            else if (joint != null && spawn.GetStateUp(trackedObj.inputSource))
            {
                GameObject go = joint.gameObject;
                Rigidbody rigidbody = go.GetComponent<Rigidbody>();
                Object.DestroyImmediate(joint);
                joint = null;
                // Destroy after 15s
                Object.Destroy(go, 15.0f);

                Transform origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
                if (origin != null)
                {
                    rigidbody.velocity =  origin.TransformVector(trackedObj.GetVelocity() * speedOffset);
                    rigidbody.angularVelocity = origin.TransformVector(trackedObj.GetAngularVelocity());
                }
                else
                {
                    rigidbody.velocity = trackedObj.GetVelocity();
                    rigidbody.angularVelocity = trackedObj.GetAngularVelocity();
                }

                rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
            }
        }

    }
}
