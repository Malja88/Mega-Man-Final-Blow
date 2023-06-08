using UnityEngine;
public class FlyScript : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHP = collision.gameObject.GetComponent<PlayerHealth>();
        if(collision.CompareTag("Player"))
        {
            playerHP.TakeDamage(damage);
        }
    }
}