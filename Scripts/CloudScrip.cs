using UnityEngine;
public class CloudScrip : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    void Start()
    {
        rb.velocity = Vector2.left * speed; 
    }
}