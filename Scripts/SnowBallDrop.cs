using UnityEngine;
public class SnowBallDrop : MonoBehaviour
{
    [SerializeField] GameObject[] snowBalls;
    [SerializeField] Transform firePoint;
    [SerializeField] float interval;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            SnowBall();
            timer -= interval;
        }        
    }
    public void SnowBall()
    {
        Instantiate(snowBalls[Random.Range(0, snowBalls.Length)], firePoint.position, firePoint.rotation);
    }
}