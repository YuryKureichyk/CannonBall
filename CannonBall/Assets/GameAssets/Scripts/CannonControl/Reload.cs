using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.CannonControl
{
    public class Reload : MonoBehaviour

    {
        [SerializeField] private Slider _slider;
        private float _reload;
        private float _shotTime;
        public bool IsReady => Time.time >= _shotTime;

        public void ResetReload(float duration)
        {
            _reload = duration;
            _shotTime = Time.time + _reload;
        }

        private void Update()
        {
            if (_reload <= 0) return;

            float lastFireTime = _shotTime - _reload;
            float elapsed = Time.time - lastFireTime;
            float progress = elapsed / _reload;
            
            _slider.value = Mathf.Clamp01(progress);
        }
    }
}