using UnityEngine;
public class SpikeShellScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] float speed;
    void FixedUpdate()
    {
        rigidBody.velocity = Vector3.left * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Stopper"))
        {
            speed *= -1;
        }
    }
}