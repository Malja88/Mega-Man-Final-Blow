using UnityEngine;
public class EnemyControll : MonoBehaviour
{
    [Header("Gameobject Body Elements")]
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sprite;
    [Header("Variables")]
    [SerializeField] float speed;
    void Update()
    {
        rigidBody.velocity = Vector2.left * speed;
        animator.SetFloat("Pace", rigidBody.velocity.magnitude);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Stopper"))
        {
                sprite.flipX = !sprite.flipX;
                speed *= -1;
        } 
    }
}