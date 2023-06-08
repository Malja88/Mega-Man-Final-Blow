using UnityEngine;
public class CrawlingBugScript : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] private float speed, TimeToRevert;
    [Header("Body")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;
    private float currentState, currentTimeToRevert;
    void Start()
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }
        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
                break;
            case WALK_STATE:
                rb.velocity = Vector2.up * speed;
                break;
            case REVERT_STATE:
                speed *= -1;
                spriteRenderer.flipY = !spriteRenderer.flipY;
                currentState = WALK_STATE;
                break;
        }
        animator.SetFloat("Velocity", rb.velocity.magnitude);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stopper"))
        {
            currentState = IDLE_STATE;
        }
    }
}