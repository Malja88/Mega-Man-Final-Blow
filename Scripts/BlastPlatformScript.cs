using UnityEngine;
public class BlastPlatformScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] GameObject platform;
    Vector3 startPoint = new Vector3(59.2f, -33.2f, 0);
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            animator.SetBool("isFly", true);
        }
    }
    /// <summary>
    /// Destroying platform and returning to its start point
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("DeathPoint"))
        {
            Instantiate(platform, startPoint, Quaternion.identity);
        }
    }
}
