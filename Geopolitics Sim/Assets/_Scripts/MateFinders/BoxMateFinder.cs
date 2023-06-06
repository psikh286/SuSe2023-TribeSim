using UnityEngine;

public class BoxMateFinder : MonoBehaviour, IMateFinder
{
    [SerializeField] private Vector3 _halfSize;
    [SerializeField] private int _maxTargets;
    [SerializeField] private bool _drawGizmos;
    
    public FoodAgentTree FindMate()
    {
        var hitColliders = new Collider[_maxTargets];
        var i = Physics.OverlapBoxNonAlloc(transform.position, _halfSize, hitColliders, Quaternion.identity, 1 << 8);

        if (i <= 0) return null;
        
        var col = GetClosestCollider();

        if (col == null) return null;

        return col.TryGetComponent<FoodAgentTree>(out var mate) ? mate : null;
        
        Collider GetClosestCollider()
        {
            var bestDistance = float.MaxValue;
            var pos = transform.position;
            Collider bestCollider = null;

            for (var j = 0; j < i; j++)
            {
                if(hitColliders[j].transform.position == transform.position) continue;
                
                var distance = Vector3.Distance(pos, hitColliders[j].transform.position);

                if (distance > bestDistance) continue;
                
                bestDistance = distance;
                bestCollider = hitColliders[j];
            }
 
            return bestCollider;
        }
    }

    private void OnDrawGizmos()
    {
        if(!_drawGizmos) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _halfSize * 2f);
    }
}