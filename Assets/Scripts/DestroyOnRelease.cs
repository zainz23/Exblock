using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class DestroyOnRelease : MonoBehaviour
    {
        private void OnDetachedFromHand(Hand hand)
        {
            Destroy(gameObject);
        }
    }
}
