using System.Collections;
using UnityEngine;
public class Stage2BossTrigger : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] GameObject wall;
    [Header("Script")]
    [SerializeField] SFXScript audio;
    [Header("Audio")]
    [SerializeField] AudioSource stageMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Wall());
            audio.PlayBoss();
            stageMusic.mute = true;
            for(int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(true);
            }
        }
    }
    IEnumerator Wall()
    {
        yield return new WaitForSeconds(2);
        wall.SetActive(true);
    }
}