using System.Collections;
using UnityEngine;
public class MovingShootingCanon : MonoBehaviour
{
    [Header("Body Elements")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [Header("Variables")]
    [SerializeField] int speed;
    [SerializeField] float interval;
    private float timer;
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        rigidBody.velocity = Vector3.up * speed;
        animator.SetInteger("Velocity", speed);
        if(timer >= interval)
        {
            StartCoroutine(ShootOnTime());
            timer -= interval;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stopper"))
        {
            speed *= -1;
        }
    }
    IEnumerator ShootOnTime()
    {
        if (speed == 1)
        {
            speed = 0;
            Shoot();
            yield return new WaitForSeconds(.5f);
            speed = 1;
        }
        if (speed == -1)
        {
            speed = 0;
            Shoot();
            yield return new WaitForSeconds(0.5f);
            speed = -1;
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}