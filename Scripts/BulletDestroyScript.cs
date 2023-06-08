using UnityEngine;
public class BulletDestroyScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Lazer"))
        {
            Destroy(collision.gameObject);
        }
    }
}