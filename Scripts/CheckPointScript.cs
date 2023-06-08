using System.Collections;
using UnityEngine;
public class CheckPointScript : MonoBehaviour
{
    [SerializeField] GameObject checkPointText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            checkPointText.SetActive(true);
            StartCoroutine(DestroyText());
            ItemsScript.lastCheckPoint = transform.position;
        }
    }
    IEnumerator DestroyText()
    {
        yield return new WaitForSeconds(2);
        Destroy(checkPointText);
    }
}