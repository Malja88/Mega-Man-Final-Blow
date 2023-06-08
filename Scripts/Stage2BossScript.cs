using UnityEngine;
public class Stage2BossScript : MonoBehaviour
{
    [Header("Body Elements")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] SpriteRenderer render;
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bomb;
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float bulletInterval;
    [SerializeField] float bombInterval;
    Vector3 firePoint1pos1 = new Vector3(115.54f, 1.96f, 1.2f);
    Vector3 firePoint1pos2 = new Vector3(124.46f, 1.96f, 1.2f);
    Vector3 firePoint2pos1 = new Vector3(113.49f, 1.38f, 1.2f);
    Vector3 firePoint2pos2 = new Vector3(126.89f, 1.38f, 1.2f);
    private float bulletTimer;
    private float bombTimer;
    void FixedUpdate()
    {
        rigidBody.velocity = Vector2.left * speed;
        bulletTimer += Time.deltaTime;
        bombTimer += Time.deltaTime;
        if(bulletTimer >= bulletInterval)
        {
            ShootBullet();
            bulletTimer -= bulletInterval;
        }
        if (bombTimer >= bombInterval)
        {
            DropBomb();
            bombTimer -= bombInterval;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stopper"))
        {
            speed *= -1;
            render.flipX = !render.flipX;
            firePoint1.position = firePoint1pos1;
            firePoint2.position = firePoint2pos1;
        }
        if(collision.CompareTag("Stopper2"))
        {
            speed *= -1;
            render.flipX = !render.flipX;
            firePoint1.position = firePoint1pos2;
            firePoint2.position = firePoint2pos2;
        }
    }
    public void ShootBullet()
    {
        Instantiate(bullet,firePoint1.position, firePoint1.rotation);
    }
    public void DropBomb()
    {
        Instantiate(bomb, firePoint2.position, firePoint2.rotation);
    }
}