using System.Collections;
using UnityEngine;
public class HintScript : MonoBehaviour
{
    [SerializeField] GameObject hintText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            hintText.SetActive(true);
            StartCoroutine(Hint());
        }
    }
    IEnumerator Hint()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}