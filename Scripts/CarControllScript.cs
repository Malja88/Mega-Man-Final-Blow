using UnityEngine;
public class CarControllScript : MonoBehaviour
{
    [Header("GameObjects & Body")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] Transform target;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float interval;
    [SerializeField] float distance;
    private float timer;
    void Update()
    {
        rb.velocity = Vector2.left * speed;
        if (Vector2.Distance(transform.position, target.position) <= distance)
        {
            timer += Time.deltaTime;
            if(timer >= interval)
            {
                CarShoot();
                timer -= interval;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Stopper"))
        {
            anim.SetBool("Back", false);
            speed *= -1;
        }
        if(collision.gameObject.CompareTag("Stopper2"))
        {
            anim.SetBool("Back", true);
            speed *= -1;    
        }
    }
    private void CarShoot()
    {
        Instantiate(bullet, firePoint.position, transform.rotation);
    }
}