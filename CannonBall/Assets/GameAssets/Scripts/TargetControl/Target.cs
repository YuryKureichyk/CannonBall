using System;
using DG.Tweening;
using UnityEngine;

namespace GameAssets.Scripts.TargetControl
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private TargetCollider _collider;
        [SerializeField] private TargetModel _model;

        public event Action Hit;

        private void OnEnable()
        {
            _collider.Hit += OnHit;
        }

        private void OnDisable()
        {
            _collider.Hit -= OnHit;
        }


        private void OnHit()
        {
            Hit?.Invoke();
            _model.AnimateHit();
        }
    }
}