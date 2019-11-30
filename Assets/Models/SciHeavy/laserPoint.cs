using UnityEngine;
using System.Collections;

namespace Valve.VR.Extras
{
    public class laserPoint : MonoBehaviour
    {

        public Color color;
        public float thickness = 0.002f;
        public Color clickColor = Color.green;
        // Controller
        public GameObject holder;
        // Pointer laser
        public GameObject pointer;
        public bool addRigidBody = false;


        private void Start()
        {
            holder = new GameObject();
            holder.transform.parent = this.transform;
            holder.transform.localPosition = Vector3.zero;
            holder.transform.localRotation = Quaternion.identity;

            pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
            pointer.transform.parent = holder.transform;
            pointer.transform.localScale = new Vector3(thickness, thickness, 100f);
            pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
            pointer.transform.localRotation = Quaternion.identity;
            pointer.GetComponent<BoxCollider>().enabled = false;
            // BoxCollider collider = pointer.GetComponent<BoxCollider>();

            Material newMaterial = new Material(Shader.Find("Unlit/Color"));
            newMaterial.SetColor("_Color", color);
            pointer.GetComponent<MeshRenderer>().material = newMaterial;
        }

        private void Update()
        {

            float dist = 6f;

            Ray raycast = new Ray(transform.position, transform.forward);
            pointer.transform.localScale = new Vector3(thickness, thickness, dist);
            pointer.GetComponent<MeshRenderer>().material.color = color;
            pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
        }
    }



}