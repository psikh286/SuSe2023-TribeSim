using System;
using UnityEngine;

public class BoxFoodFinder : MonoBehaviour, IFoodFinder
{
    [SerializeField] private Vector3 _halfSize;
    [SerializeField] private int _maxTargets;
    [SerializeField] private bool _drawGizmos;
    
    public IFood FindFood(Type type)
    {
        var hitColliders = new Collider[_maxTargets];
        var i = Physics.OverlapBoxNonAlloc(transform.position, _halfSize, hitColliders, Quaternion.identity, 1 << 9);

        if (i <= 0) return null;
        
        var col = GetClosestCollider();

        if (col == null) return null;
        
        return col.TryGetComponent<IFood>(out var food) ? food : null;
        
        Collider GetClosestCollider()
        {
            var bestDistance = float.MaxValue;
            var pos = transform.position;
            Collider bestCollider = null;
            
            for (var j = 0; j < i; j++)
            {
                if (!hitColliders[j].TryGetComponent<IFood>(out var f)) continue;
                if (f.GetType() != type) continue;
                
                var distance = Vector3.Distance(pos, hitColliders[j].transform.position);

                if (Math.Abs(distance) > bestDistance) continue;
                
                bestDistance = distance;
                bestCollider = hitColliders[j];
            }
 
            return bestCollider;
        }
    }

    private void OnDrawGizmos()
    {
        if(!_drawGizmos) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _halfSize * 2f);
    }
}
