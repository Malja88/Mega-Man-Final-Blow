using UnityEngine;
public class FInalBossControll : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float speed, TimeToRevert;
    [Header("Body")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D col;
    Vector2 offset = new Vector2(-1,1);
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
                rb.velocity = Vector2.right * speed;
                break;
            case REVERT_STATE:
                speed *= -1;
                currentState = WALK_STATE;
                break;
        }
        animator.SetFloat("Dash", rb.velocity.magnitude);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stopper"))
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            col.offset *= offset;
            currentState = IDLE_STATE;
        }
    }
}