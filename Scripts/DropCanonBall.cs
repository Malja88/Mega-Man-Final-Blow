using UnityEngine;
public class DropCanonBall : MonoBehaviour
{
    [Header("GameObjects & Body")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] GameObject canonBall;
    [SerializeField] Transform firePoint;
    [SerializeField] Animator animator;
    [Header("Variable")]
    [SerializeField] float speed;
    void Update()
    {
        rigidBody.velocity = Vector3.left * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stopper"))
        {
            animator.SetTrigger("Drop");
            DropBomb();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Stopper2"))
        {
            Destroy(gameObject);
        }
    }
    public void DropBomb()
    {
        Instantiate(canonBall, firePoint.position, firePoint.rotation);
    }
}