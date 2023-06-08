using System.Collections;
using UnityEngine;
public class FollowPlayer : MonoBehaviour
{
    Transform player;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float bulletLife;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        Vector2 newPos = Vector2.MoveTowards(rb.position, player.position, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        StartCoroutine(destroyBullet());
    }
    private IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }
}