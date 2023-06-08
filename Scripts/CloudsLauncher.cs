using UnityEngine;
public class CloudsLauncher : MonoBehaviour
{
    [SerializeField] GameObject cloud;
    [SerializeField] Transform firePoint;
    [SerializeField] float interval;
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            CloudLaunch();
            timer -= interval;
        }
    }
    public void CloudLaunch()
    {
        Instantiate(cloud, firePoint.position, firePoint.rotation);
    }
}