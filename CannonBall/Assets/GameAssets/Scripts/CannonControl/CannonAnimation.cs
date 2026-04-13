using DG.Tweening;
using UnityEngine;

namespace GameAssets.Scripts.CannonControl
{
    public class CannonAnimation : MonoBehaviour
    {
        [SerializeField] private Transform _visualModel;
        [SerializeField] private float _shakeDuration = 0.15f;
        [SerializeField] private float _shakeStrength = 0.2f;
        [SerializeField] private ParticleSystem _particle; 
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _shootSound;

        public void PlayShootAnimation()
        {
            _visualModel.DOComplete();
            _visualModel.DOShakePosition(_shakeDuration, _shakeStrength, 10, 90);
            _particle.Play();
            _audioSource.PlayOneShot(_shootSound);
        }
    }
}