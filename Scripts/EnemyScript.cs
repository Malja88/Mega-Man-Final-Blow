using System.Collections;
using TMPro;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    [Header("Variables")]
    [SerializeField] float maxHealth;
    [SerializeField] int damage;
    [SerializeField] int scorePerEnemy;
    [Header("Script References")]
    [SerializeField] PlayerHealth health;
    [Header("Enemies Sceleton")]
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer material;
    [SerializeField] Collider2D collider;
    [Header("TextMeshPro")]
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] SFXScript sound;
    private Vector2 hit = new Vector2(-1, 0);
    private sbyte force = 6;
    private Material matWhite;
    private Material matDefault;
    public static int scoreValue;
    private void Start()
    {
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = material.material;
    }
    public void TakeDamage(float damage)
    {
        material.material = matWhite;
        maxHealth -= damage;
        if (maxHealth <= 0)
        {
            Die();
        }
        StartCoroutine(ChangeColor());
    }
        public void Die()
    {
        sound.PlayEnemyDie();
        collider.isTrigger = true;
        animator.SetFloat("isDead", maxHealth);
        StartCoroutine(RemoveEnemy());
    }
    private IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(0.6f);
        scoreValue += scorePerEnemy;
        score.text = scoreValue.ToString();
        Destroy(gameObject);
    }
    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(.2f);
        material.material = matDefault;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(hit * force, ForceMode2D.Impulse);
            health.TakeDamage(damage);
        }
    }
}