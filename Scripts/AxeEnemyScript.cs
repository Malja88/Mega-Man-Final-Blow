using System.Collections;
using UnityEngine;
public class AxeEnemyScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float interval;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            animator.SetBool("Attack", true);
            StartCoroutine(EnemyIdle());
            timer -= interval;
        }
    }
    IEnumerator EnemyIdle()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("Attack", false);
    }
}