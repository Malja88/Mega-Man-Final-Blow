using System.Collections;
using UnityEngine;
public class AxeThrowingEnemy : MonoBehaviour
{
    [Header("GameObjects & Body")]
    [SerializeField] Animator animator;
    [SerializeField] GameObject axe;
    [SerializeField] Transform firePoint;
    [Header("Variable")]
    [SerializeField] float interval;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            animator.SetTrigger("Throw");
            StartCoroutine(Shoot());
            timer -= interval;
        }
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.6f);
        Instantiate(axe, firePoint.position, firePoint.rotation);
    }
}