using System.Collections;
using TMPro;
using UnityEngine;
public class BossHealth : MonoBehaviour
{
    [Header("Boss Body Elements")]
    [SerializeField] SpriteRenderer material;
    [SerializeField] Animator animator;
    [SerializeField] Collider2D collider;
    [Header("Variables")]
    [SerializeField] float bossHealth;
    [SerializeField] int damage;
    [SerializeField] int scorePerEnemy;
    [Header("Scripts")]
    [SerializeField] PlayerHealth health;
    [Header("Text & Sound")]
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] SFXScript sound;
    [Header("GameObjects")]
    [SerializeField] GameObject nextLevelTrigger;
    private Material matWhite;
    private Material matDefault;
    private Vector2 hit = new Vector2(-1, 0);
    private sbyte force = 6;
    public static int scoreValue;
    private void Start()
    {
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = material.material;
    }
    public void TakeDamage(float damage)
    {
        material.material = matWhite;
        bossHealth -= damage;

            if (bossHealth <= 0)
            {
                Die();
            }

        StartCoroutine(ChangeColor());
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
    public void Die()
    {
        sound.PlayEnemyDie();
        collider.isTrigger = true;
        animator.SetFloat("isDead", bossHealth);
        nextLevelTrigger.SetActive(true);
        StartCoroutine(RemoveEnemy());
    }
    private IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(.6f);
        scoreValue += scorePerEnemy;
        score.text = scoreValue.ToString();
        Destroy(gameObject);
    }
}