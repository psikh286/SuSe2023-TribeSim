using UnityEngine;

public class BoxFoodFinder : MonoBehaviour, IFoodFinder
{
    [SerializeField] private Vector3 _halfSize;
    [SerializeField] private int _maxTargets;
    [SerializeField] private bool _drawGizmos;
    
    public IFood FindFood()
    {
        var hitColliders = new Collider[_maxTargets];
        var i = Physics.OverlapBoxNonAlloc(transform.position, _halfSize, hitColliders, Quaternion.identity, 1 << 9);

        if (i <= 0) return null;
        
        var col = hitColliders[Random.Range(0, i)];
        return col.TryGetComponent<IFood>(out var food) ? food : null;
    }

    private void OnDrawGizmos()
    {
        if(!_drawGizmos) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _halfSize * 2f);
    }
}
