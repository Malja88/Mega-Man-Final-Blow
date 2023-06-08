using UnityEngine;
public class UnicycleRobotScript : MonoBehaviour
{
    [SerializeField] private float speed, TimeToRevert;
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
                rb.velocity = Vector2.left * speed;
                break;
            case REVERT_STATE:
                spriteRenderer.flipX = !spriteRenderer.flipX;
                speed *= -1;
                currentState = WALK_STATE;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stopper"))
        {
            animator.SetTrigger("Revert");
            currentState = IDLE_STATE;
        }
    }
}
