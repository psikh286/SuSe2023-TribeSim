using System;
using UnityEngine;
using UnityEngine.AI;

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
            var pos = Vector3ToVector2(transform.position);
            Collider bestCollider = null;
            
            for (var j = 0; j < i; j++)
            {
                if (!hitColliders[j].TryGetComponent<IFood>(out var f)) continue;
                if (f.GetType() != type) continue;
                
                var distance = Vector2.Distance(Vector3ToVector2(hitColliders[j].transform.position), pos);

                if (Math.Abs(distance) > bestDistance) continue;
                
                bestDistance = Math.Abs(distance);
                bestCollider = hitColliders[j];
            }
 
            return bestCollider;
        }
    }
    
    private static Vector2 Vector3ToVector2(Vector3 v)
    {
        return new Vector2(v.x, v.z);
    }

    private void OnDrawGizmos()
    {
        if(!_drawGizmos) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _halfSize * 2f);
    }
}
