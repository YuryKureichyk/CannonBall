using System.Threading.Tasks;
using UnityEngine;

namespace GameAssets.Scripts.TargetControl
{
    public class TargetGenerator : MonoBehaviour

    {
        [SerializeField] private BoxCollider[] _spawnArea;
        [SerializeField] private Target _targetPrefab;
        [SerializeField] private Score.Score _scoreCounter;

        private async void Start()
        {
            for (int i = 0; i < _spawnArea.Length; i++)
            {
                BoxCollider Area = _spawnArea[i];


                Vector3 spawnPosition = new Vector3(
                    Area.bounds.center.x,
                    Random.Range(Area.bounds.min.y, Area.bounds.max.y),
                    Area.bounds.center.z
                );

                var result = await InstantiateAsync(_targetPrefab, spawnPosition, Quaternion.identity);
                Target Target = result[0];


                Target.Hit += _scoreCounter.AddPoint;


                await Task.Delay(1000);
            }
        }
    }
}