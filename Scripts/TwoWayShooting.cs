using UnityEngine;
public class TwoWayShooting : MonoBehaviour
{
    [Header("Body Elements")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject missle;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;
    [SerializeField] Transform target;
    [Header("Variables")]
    [SerializeField] float interval;
    [SerializeField] float interval2;
    [SerializeField] float distance;
    float timer, timer2;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            ShootingBullet();
            timer -= interval;
        }
        if (Vector3.Distance(transform.position, target.position) <= distance)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= interval2)
            {
                ShootingMissle();
                timer2 -= interval2;
            }
        }
    }
    public void ShootingBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    public void ShootingMissle()
    {
        Instantiate(missle, firePoint2.position, firePoint2.rotation);
    }
}