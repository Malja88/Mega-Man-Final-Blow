using System.Collections;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class FallingBlocks : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.5f);
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
    }
}