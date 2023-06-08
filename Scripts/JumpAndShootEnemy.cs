using UnityEngine;
public class JumpAndShootEnemy : MonoBehaviour
{
    [Header("Body Components")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject lazer;
    [Header("Variables")]
    [SerializeField] float force;
    [SerializeField] float jumpingInterval;
    [SerializeField] float shootingInterval;
    private float timer, timer2;
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if (timer >= jumpingInterval)
        {
            animator.SetTrigger("Jump");
            rigidBody.velocity = Vector2.up * force;
            timer -= jumpingInterval;
        }
        if(timer2 >= shootingInterval)
        {
            Shoot();
            timer2 -= shootingInterval;
        }
    }
    public void Shoot()
    {
        Instantiate(lazer, firePoint.position, firePoint.rotation); 
    }
}