using UnityEngine;
public class TwoWayCanonScript : MonoBehaviour
{
    [SerializeField] Transform firePoint1;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject bullet;
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
        Instantiate(bullet, firePoint1.position, firePoint1.rotation);
        Instantiate(bullet, firePoint2.position, firePoint2.rotation);
    }
}