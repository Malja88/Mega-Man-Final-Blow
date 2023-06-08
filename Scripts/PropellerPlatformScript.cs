using UnityEngine;
public class PropellerPlatformScript : MonoBehaviour
{
    [SerializeField] Transform finish;
    private float speed = 0;
    private void Update()
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, finish.position, speed * Time.deltaTime);
        transform.position = newPos;
        if(Vector2.Distance(transform.position, finish.position) <= 25)
        {
            speed = 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            speed = 1.5f;
        }
    }
}