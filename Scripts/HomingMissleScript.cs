using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissleScript : MonoBehaviour
{
    Transform target;
    [SerializeField] Rigidbody2D rb;
    [Header("Variables")]
    [SerializeField] int damage;
    [SerializeField] float speed;
    [SerializeField] float bulletLife;
    [SerializeField] float rotateSpeed = 100;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.right * speed;
        StartCoroutine(destroyBullet());
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
    private IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }
}