using System;
using GameAssets.Scripts.BallControl;
using GameAssets.Scripts.Systems.InputSystem;
using UnityEngine;

namespace GameAssets.Scripts.CannonControl
{
    public class Cannon : MonoBehaviour

    {
        [SerializeField] private float _power = 30;
        [SerializeField] private BallPool _ballPool;
        [SerializeField] private InputSystem _input;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Reload _reload;
        [SerializeField] private CannonAnimation _cannonAnimation;
        [SerializeField] private float _reloadDuration = 1f;

        private  float _nextShot;
        private void OnEnable()
        {
            _input.FirePressed += OnFirePressed;
        }

        private void OnDisable()
        {
            _input.FirePressed -= OnFirePressed;
        }

        private void OnFirePressed()
        {
            if (_reload.IsReady)
            {
                Shot();
                _reload.ResetReload(_reloadDuration);
            }
        }

        private void Shot()
        {
            var ball = _ballPool.Get();
            ball.Setup(_spawnPoint.position, _spawnPoint.rotation);
            ball.Apply(_spawnPoint.forward * _power);
            _cannonAnimation.PlayShootAnimation();
        }
    }
}