using UnityEngine;
public class AutomaticShooting : MonoBehaviour
{
    [Header("Gameobject Body Elements")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform target;
    [SerializeField] Animator animator;
    [Header("Variables")]
    [SerializeField] float interval;
    [SerializeField] int distance;
    float timer;
    void Update()
    { 
        if (Vector3.Distance(transform.position, target.position) <= distance)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                animator.SetBool("isShoot", true);
                EnemyShooter();
                timer -= interval;
            }
        }
        else if(Vector3.Distance(transform.position, target.position) > distance)
        {
            animator.SetBool("isShoot", false);
        }
    }
    public void EnemyShooter()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}