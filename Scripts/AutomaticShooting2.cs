using UnityEngine;
public class AutomaticShooting2 : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float interval;
    [Header("GameObjects & Body")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePoint;
    float timer;
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
    }
}