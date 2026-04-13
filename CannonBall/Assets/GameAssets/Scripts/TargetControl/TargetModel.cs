using DG.Tweening;
using UnityEngine;

namespace GameAssets.Scripts.TargetControl
{
    public class TargetModel : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _renderer;
        [SerializeField] private Transform _target;

        private Sequence _hitSequence;
        private Sequence _moveSequence;

        private Color _defaultColor;

        private void StartYoyo()
        {
            _moveSequence?.Kill();
            _moveSequence = DOTween.Sequence();
            _moveSequence.Append(_target.DOLocalMoveY(_target.localPosition.y + 1f, 1f)
                .SetEase(Ease.InOutSine));
            _moveSequence.SetLoops(-1, LoopType.Yoyo);
        }


        public void AnimateHit()
        {
            _moveSequence?.Kill();
            _hitSequence = DOTween.Sequence();
            _hitSequence.Append(
                _renderer.material.DOColor(Color.red, 0.3f));
            _hitSequence.AppendInterval(0.2f);
            _hitSequence.Append(
                _renderer.material.DOColor(_defaultColor, 0.3f));
            _hitSequence.OnComplete(() => { Destroy(gameObject); });
        }


        private void Start()
        {
            StartYoyo();
            _defaultColor = _renderer.material.color;
        }
    }
}