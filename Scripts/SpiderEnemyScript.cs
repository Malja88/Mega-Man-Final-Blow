using UnityEngine;
public class SpiderEnemyScript : MonoBehaviour
{
    [Header("Body Elements")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float interval;
    private float timer;
    void FixedUpdate()
    {
        rigidBody.velocity = Vector3.left * speed;
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            Shoot();
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
        Instantiate(bullet2, firePoint2.position, firePoint2.rotation);
    }
}