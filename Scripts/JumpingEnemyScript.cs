using System.Collections;
using UnityEngine;
public class JumpingEnemyScript : MonoBehaviour
{
    [Header("Body Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [Header("Variables")]
    [SerializeField] float speed;
    [SerializeField] float interval;
    Vector2 jump = new Vector2(-1, 1.5f);
    private float timer;
    private float currentSpeed;
    private void Start()
    {
        currentSpeed = speed;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            rb.velocity = jump * speed;
            animator.SetBool("isJump", true);
            StartCoroutine(BunnyIdle());
            timer -= interval;
        }
    }
    IEnumerator BunnyIdle()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("isJump", false);
        speed = currentSpeed;
    }
}