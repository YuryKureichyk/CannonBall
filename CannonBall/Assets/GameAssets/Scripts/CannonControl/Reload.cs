using UnityEngine;
using UnityEngine.UI;

namespace GameAssets.Scripts.CannonControl
{
    public class Reload : MonoBehaviour

    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _reload = 1f;

        private float _shotTime;
        public bool IsReady => Time.time >= _shotTime;

        public void ResetReload()
        {
            _shotTime = Time.time + _reload;
        }

        private void Update()
        {
            
            float lastFireTime = _shotTime - _reload;
            float elapsed = Time.time - lastFireTime;
            float progress = elapsed / _reload;

            _slider.value = Mathf.Clamp01(progress);
        }
        
    }
}