using UnityEngine;

namespace GameAssets.Scripts.BallControl
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;


        public void Setup(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
           transform.rotation = rotation;
           _rigidbody.angularVelocity = Vector3.zero;
           _rigidbody.linearVelocity = Vector3.zero;
        }
        public void Apply(Vector3 force)
        {
            _rigidbody.AddForce(force, ForceMode.Impulse);
        }
        
    }
}
