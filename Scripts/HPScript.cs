using UnityEngine;
public class HPScript : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] int healthAmount;
    [Header("Scripts")]
    [SerializeField] PlayerHealth health;
    [SerializeField] HealthBarScript healthBar;
    [Header("Audio")]
    [SerializeField] SFXScript sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            health.currentHealth += healthAmount;
            healthBar.SetHealth(health.currentHealth);
            sound.ColletHealth();
            Destroy(gameObject);
        }
    }
}