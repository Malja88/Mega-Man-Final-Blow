using System.Collections;
using UnityEngine;
public class MiniBossScript : MonoBehaviour
{
    [Header("Body Elements")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float interval;
    private float timer;
    void FixedUpdate()
    {
        rb.velocity = Vector2.left * speed;
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            speed = 0;
            Shoot();
            animator.SetBool("isShoot", true);
            StartCoroutine(StopShoot());
            timer -= interval;
        }
    }
    IEnumerator StopShoot()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("isShoot", false);
        speed = 1.5f;   
    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stopper"))
        {
            speed *= Random.Range(-2, -5);
        }
        if (collision.gameObject.CompareTag("Stopper2"))
        {
            speed = 1.7f;
        }
    }
}