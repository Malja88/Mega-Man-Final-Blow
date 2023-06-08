using System.Collections;
using UnityEngine;
public class FinalBossTrigger : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] GameObject HP;
    [SerializeField] GameObject HP2;
    [Header("Audio")]
    [SerializeField] SFXScript audio;
    [SerializeField] AudioSource stageMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(HealthSpawn());
        if (collision.gameObject.CompareTag("Player"))
        {
            audio.FinalBoss();
            stageMusic.mute = true;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
    IEnumerator HealthSpawn()
    {
        yield return new WaitForSeconds(30);
        HP.SetActive(true);
        yield return new WaitForSeconds(30);
        HP2.SetActive(true);
    }
}