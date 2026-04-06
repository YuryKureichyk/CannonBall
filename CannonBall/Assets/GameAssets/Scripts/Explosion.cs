using UnityEngine;

public class BridgeExplosion : MonoBehaviour
{
    [SerializeField] private GameObject _bridge;
    [SerializeField] private float _horizontalPower = 500f;
    [SerializeField] private float _verticalPower = 200f;

    public void Explode()
    {
        var allForces = _bridge.GetComponentsInChildren<ConstantForce>(true);

        foreach (var cf in allForces)
        {
            cf.enabled = true;

            cf.force = new Vector3(
                Random.Range(-_horizontalPower, _horizontalPower),
                Random.Range(20f, _verticalPower),
                Random.Range(-_horizontalPower, _horizontalPower)
            );

            cf.torque = Random.insideUnitSphere * 100f;
        }
    }
}