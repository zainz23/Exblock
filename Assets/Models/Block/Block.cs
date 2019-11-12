
using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    public class Block : MonoBehaviour
    {
        private Hand hand;

        public GameObject breakPrefab;

        public float maxVelocity = 5f;

        public float lifetime = 15f;
        public bool burstOnLifetimeEnd = false;

        public GameObject lifetimeEndParticlePrefab;
        public SoundPlayOneshot lifetimeEndSound;

        private float destructTime = 0f;

        public SoundPlayOneshot collisionSound;


        private bool bParticlesSpawned = false;

        private static float s_flLastDeathSound = 0f;



        void Start()
        {
            destructTime = Time.time + lifetime + Random.value;
            hand = GetComponentInParent<Hand>();

        }

        void Update()
        {
            if ((destructTime != 0) && (Time.time > destructTime))
            {
                if (burstOnLifetimeEnd)
                {
                    SpawnParticles(lifetimeEndParticlePrefab, lifetimeEndSound);
                }
                // Object is destroyed
                Destroy(gameObject);
            }
        }


        private void SpawnParticles(GameObject particlePrefab, SoundPlayOneshot sound)
        {
            // Dont spawn particles again
            if (bParticlesSpawned)
            {
                return;
            }

            bParticlesSpawned = true;

            if (particlePrefab != null)
            {
                GameObject particleObject = Instantiate(particlePrefab, transform.position, transform.rotation) as GameObject;
                particleObject.GetComponent<ParticleSystem>().Play();
                Destroy(particleObject, 2f);
            }

            if (sound != null)
            {
                float lastSoundDiff = Time.time - s_flLastDeathSound;
                if (lastSoundDiff < 0.1f)
                {
                    sound.volMax *= 0.25f;
                    sound.volMin *= 0.25f;
                }
                sound.Play();
                s_flLastDeathSound = Time.time;
            }
        }

        private void ApplyDamage()
        {
            SpawnParticles(breakPrefab, null);
            Destroy(gameObject);
        }

    }
}
