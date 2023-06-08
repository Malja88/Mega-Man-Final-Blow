using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        BossHealth boss = collision.GetComponent<BossHealth>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Boss"))
        {
            boss.TakeDamage(damage);
            Destroy (gameObject);
        }
    }
}