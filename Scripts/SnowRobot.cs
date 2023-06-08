using UnityEngine;
public class SnowRobot : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    Vector2 hit = new Vector2(-1.5f, 1f);
    private sbyte force = 1;
    private sbyte speed = 4;
    private void FixedUpdate()
    {
        rigidBody.velocity = Vector2.left * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(hit * force, ForceMode2D.Impulse);
        }
        if(collision.CompareTag("Stopper"))
        {
            speed *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}