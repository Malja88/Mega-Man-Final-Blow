using System.Collections;
using UnityEngine;
public class Boss3Script : MonoBehaviour
{
    [Header("GameObjects & Body")]
    [SerializeField] Animator animator;
    [SerializeField] GameObject iceCube;
    [SerializeField] GameObject wave;
    [SerializeField] Transform firePoint;
    [Header("Variables")]
    [SerializeField] float interval;
    [SerializeField] float interval2;
    private float timer, timer2;
    void Update()
    {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if(timer >= interval)
        {
            animator.SetTrigger("ShootIce");
            ShootIce();
            timer -= interval;
        }
        if(timer2 >= interval2)
        {
            timer = 0;
            animator.SetTrigger("ShootWave");
            StartCoroutine(ShootWaveBlast());
            timer2 -= interval2;
        }
    }
    public void ShootIce()
    {
        Instantiate(iceCube, firePoint.position, firePoint.rotation);
    }
    public void ShootWave()
    {
        Instantiate(wave, firePoint.position, firePoint.rotation);  
    }
    IEnumerator ShootWaveBlast()
    {
        yield return new WaitForSeconds(1.2f);
        ShootWave();
    }
}