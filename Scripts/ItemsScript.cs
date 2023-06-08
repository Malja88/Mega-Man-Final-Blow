using TMPro;
using UnityEngine;
public class ItemsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI powerUpScrore;
    [SerializeField] TextMeshProUGUI enemyPoints;
    [SerializeField] SFXScript sound;
    public int weaponPowerUp;
    float maxTime = 40;
    float currentTime;
    public static Vector2 lastCheckPoint = new Vector2(-8.66f, -1.94f);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PowerUp"))
        {
           sound.CollectPU();
           Destroy(collision.gameObject);
           weaponPowerUp+=1;
           powerUpScrore.text = weaponPowerUp.ToString();
        }
    }
    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPoint;
        currentTime = maxTime;
    }
    private void Update()
    {
        if(weaponPowerUp >= 5)
        {
            currentTime -= Time.deltaTime; 
            if(currentTime <= 0)
            {
                weaponPowerUp = 0;
            }
        }
    }
}