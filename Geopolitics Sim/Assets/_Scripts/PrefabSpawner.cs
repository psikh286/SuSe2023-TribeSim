using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _bounds;
    [SerializeField] private int _prefabsPerSpawn;
    [SerializeField] private float _delay = 2f;
    [SerializeField] private bool _autoSpawn;
    [SerializeField] private Color _gizmoColor = Color.red;

    private void Start() => SpawnFood();


    public void SpawnFood()
    {
        for (var i = 0; i < _prefabsPerSpawn; i++)
        {
            var x = _bounds.x * 0.5f;
            var z = _bounds.z * 0.5f;
            var pos = new Vector3(Utility.RandomFloat(-x, x), 0.5f, Utility.RandomFloat(-z, z));
            
            var transform1 = transform;
            var worldPos = transform1.position + pos;
            
            if (!Physics.Raycast(worldPos, Vector3.down, out var hit, Mathf.Infinity, 1 << 13)) continue;
            

            worldPos.y = hit.point.y;
            worldPos.y += 0.5f;
            
            
            Instantiate(_prefab, worldPos, Quaternion.identity, transform1);
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
        Gizmos.color = _gizmoColor;
        Gizmos.DrawWireCube(transform.position, _bounds);
    }
}