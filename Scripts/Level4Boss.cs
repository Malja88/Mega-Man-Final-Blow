using System.Collections;
using UnityEngine;
public class Level4Boss : MonoBehaviour
{
    [Header("Body Elements")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float interval;
    private float timer;
    void FixedUpdate()
    {
        rigidBody.velocity = Vector3.up * speed;
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            StartCoroutine(ShootOnTime());
            animator.SetBool("Shoot",true);
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
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
    }
    IEnumerator ShootOnTime()
    {
        yield return new WaitForSeconds(.5f);
        Shoot();
        animator.SetBool("Shoot", false);
    }
}