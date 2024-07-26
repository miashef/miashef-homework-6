using BHSCamp;
using UnityEngine;

namespace BHSCamp
{
    [RequireComponent(typeof(Collider2D))]
    public class FinishZone : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            GameManager.Instance.FinishCurrentLevel();
        }
    }
}