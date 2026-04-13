using System;
using UnityEngine;

namespace GameAssets.Scripts.TargetControl
{
    public class TargetCollider : MonoBehaviour
    {
        public event Action Hit;
        
        private void OnCollisionEnter()
        {
            Hit?.Invoke();
        }
    }
}