using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeLevel : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] GameObject trans;
    [SerializeField] GameObject[] objects;
    [SerializeField] GameObject endOfRound;
    [Header("Body")]
    [SerializeField] Animator transition;
    [Header("Scripts")]
    [SerializeField] PlayerMovement move;
    [SerializeField] SFXScript sound;
    [Header("Audio")]
    [SerializeField] AudioSource bossMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < objects.Length; i++)
            {
                Destroy(objects[i]);
            }
            move.runSpeed = 0;
            StartCoroutine(LoadScene());
        }
    }
    private IEnumerator LoadScene()
    {
        bossMusic.mute = true;
        endOfRound.SetActive(true);
        sound.StageEnd();
        yield return new WaitForSeconds(6);
        trans.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}