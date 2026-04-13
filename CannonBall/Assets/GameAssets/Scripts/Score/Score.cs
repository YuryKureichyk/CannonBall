using TMPro;
using UnityEngine;

namespace GameAssets.Scripts.Score
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        private int _score = 0;

        public void AddPoint()
        {
            
            _score++;
            _scoreText.text = _score.ToString();
        }
    }
}
