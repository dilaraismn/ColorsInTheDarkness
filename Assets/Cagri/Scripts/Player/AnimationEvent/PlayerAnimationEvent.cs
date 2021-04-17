using UnityEngine;

namespace Cagri.Scripts.Player.AnimationEvent
{
    public class PlayerAnimationEvent : MonoBehaviour
    {
        public void ColliderOn()
        {
            GetComponentInChildren<Collider>().enabled = true;
        }

        public void ColliderOff()
        {
            GetComponentInChildren<Collider>().enabled = false;
        }
    }
}
