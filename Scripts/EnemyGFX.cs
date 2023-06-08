using UnityEngine;
using Pathfinding;
public class EnemyGFX : MonoBehaviour
{
    [SerializeField] AIPath aiPath;
    [SerializeField] Transform firePoint;
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 1);
            firePoint.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(2, 2, 1);
            firePoint.rotation = Quaternion.Euler(0, 0, 215);
        }
    }
}