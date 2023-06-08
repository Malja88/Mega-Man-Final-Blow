using System.Collections;
using UnityEngine;
public class LazerBlastScript : MonoBehaviour
{
    [SerializeField] GameObject lazer;
    [SerializeField] Transform firePoint;
    [SerializeField] float interval;
    [SerializeField] float waitTime;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        {
            if (timer >= interval)
            {
                lazer.SetActive(true); 
                StartCoroutine(Lazer());
                timer -= interval;
            }
        }
    }
    IEnumerator Lazer()
    {
        yield return new WaitForSeconds(waitTime);
        lazer.SetActive(false);
    }
}