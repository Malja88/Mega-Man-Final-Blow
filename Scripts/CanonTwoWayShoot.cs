using UnityEngine;
public class CanonTwoWayShoot : MonoBehaviour
{
    [Header("GameObjects & Body")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;
    [Header("Variable")]
    [SerializeField] float interval;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            Shoot();
            timer -= interval;
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
    }
}