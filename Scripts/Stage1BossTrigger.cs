using System.Collections;
using UnityEngine;
public class Stage1BossTrigger : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject boss;
    [SerializeField] GameObject wall;
    [Header("Scripts")]
    [SerializeField] SFXScript audio;
    [Header("Audio")]
    [SerializeField] AudioSource stageMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            audio.PlayBoss();
            stageMusic.mute = true;
            boss.SetActive(true);
            StartCoroutine(Wall());
        } 
    }
    IEnumerator Wall()
    {
        yield return new WaitForSeconds(2);
        wall.SetActive(true);
    }
}