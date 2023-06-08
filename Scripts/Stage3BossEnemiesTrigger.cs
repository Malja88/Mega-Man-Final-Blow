using System.Collections;
using UnityEngine;
public class Stage3BossEnemiesTrigger : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject boss;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject HP;
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject[] enemies2;
    [SerializeField] GameObject[] enemies3;
    [Header("Script")]
    [SerializeField] SFXScript audio;
    [Header("Audio")]
    [SerializeField] AudioSource stageMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(Wall());
            audio.PlayBoss();
            stageMusic.mute = true;
            boss.SetActive(true);
            StartCoroutine(Bats());
        }
    }
    IEnumerator Bats()
    {
        yield return new WaitForSeconds(5);
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
        }
        yield return new WaitForSeconds(10);
        HP.SetActive(true);
        for(int j = 0; j < enemies2.Length; j++)
        {
            enemies2[j].SetActive(true);
        }
        yield return new WaitForSeconds(20);
        for(int k = 0; k < enemies3.Length; k++)
        {
            enemies3[k].SetActive(true);
        }
    }
    IEnumerator Wall()
    {
        yield return new WaitForSeconds(1);
        wall.SetActive(true);
    }
}