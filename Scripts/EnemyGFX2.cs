using Pathfinding;
using UnityEngine;
public class EnemyGFX2 : MonoBehaviour
{
    [SerializeField] AIPath aiPath;
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1);
        }
    }
}