using UnityEngine;
public class BirdScript : MonoBehaviour
{
    [Header("GameObjects & Body")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject bomb;
    [SerializeField] Transform firePoint;
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float interval;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        rigidBody.velocity = Vector3.left * speed;
        if(timer >= interval)
        {
            DropBomb();
            timer -= interval;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stopper"))
        {
            speed *= -1;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
    public void DropBomb()
    {
        Instantiate(bomb, firePoint.position, firePoint.rotation);
    }
}