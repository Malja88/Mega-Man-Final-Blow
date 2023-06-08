using UnityEngine;
public class FlippingShootingEnemy : MonoBehaviour
{
    [SerializeField] SpriteRenderer robot;
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;
    [SerializeField] GameObject[] bunnies;
    Vector3 newFirePoint = new Vector3(54.31f, 2.77f, -0.26f);
    Vector3 newFirePoint2 = new Vector3(53.7f, 3.56f, -0.32f);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            robot.flipX = true;
            firePoint.rotation = Quaternion.Euler(0,0,0);
            firePoint.position = newFirePoint;
            firePoint2.rotation = Quaternion.Euler(0,0,0);
            firePoint2.position = newFirePoint2;
            for(int i = 0; i < bunnies.Length; i++)
            {
                bunnies[i].SetActive(true);
            }
        }
    }
}