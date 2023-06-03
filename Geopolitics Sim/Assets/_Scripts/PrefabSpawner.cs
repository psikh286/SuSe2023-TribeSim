using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _bounds;
    [SerializeField] private int _prefabsPerSpawn;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private bool _autoSpawn;


    public void SpawnFood()
    {
        for (var i = 0; i < _prefabsPerSpawn; i++)
        {
            var x = _bounds.x * 0.5f;
            var z = _bounds.z * 0.5f;
            var pos = new Vector3(Utility.RandomFloat(-x, x), 0.5f, Utility.RandomFloat(-z, z));
            var transform1 = transform;
            Instantiate(_prefab, transform1.position + pos, Quaternion.identity, transform1);
        }
    }

    private float _elapsedTickTime;

    private void Update()
    {
        if (!_autoSpawn || _delay == 0f) return;

        _elapsedTickTime += Time.deltaTime;
        while (_elapsedTickTime >= _delay)
        {
            SpawnFood();
            _elapsedTickTime -= _delay;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _bounds);
    }
}