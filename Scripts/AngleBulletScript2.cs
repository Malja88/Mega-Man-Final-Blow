using UnityEngine;
public class AngleBulletScript2 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] Rigidbody2D rb;
    Vector3 angle = new Vector3(1, -1, 0);
    void Start()
    {
        rb.velocity = angle * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHP = collision.GetComponent<PlayerHealth>();
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHP.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}