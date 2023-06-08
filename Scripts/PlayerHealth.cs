using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] int MaxHealth = 1000;
    [SerializeField] public int currentHealth;
    [Header("Player Body")]
    [SerializeField] Animator anim;
    [SerializeField] HealthBarScript healthBar;
    [SerializeField] PlayerMovement move;
    [SerializeField] SFXScript sound;
    [SerializeField] Rigidbody2D rigidBody;
    [Header("GameObjecs")]
    [SerializeField] GameObject trans;
    [SerializeField] Animator transition;
    void Start()
    {
        currentHealth = MaxHealth;
        healthBar.SetHealth(MaxHealth);
    }
    public void TakeDamage(int damage)
    {
        sound.PlayHurt();
        currentHealth -= damage;
        anim.SetTrigger("isHit");
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathPoint"))
        {
            currentHealth = 0;
            rigidBody.bodyType = RigidbodyType2D.Static;
            healthBar.SetHealth(currentHealth);
            move.runSpeed = 0;
            anim.SetFloat("isDead", currentHealth);
            sound.PlayDie();
            StartCoroutine(DeathOnTrigger());
        }
    }
    public void Die()
    {
        sound.PlayDie();
        anim.SetFloat("isDead", currentHealth);
        move.runSpeed = 0;
        StartCoroutine(DeathOnTrigger());
    }
    private IEnumerator DeathOnTrigger()
    {
        trans.SetActive(true);
        transition.SetTrigger("Start"); 
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}