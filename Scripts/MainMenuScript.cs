using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] GameObject trans;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioMixer sfxMixer;
    public void StartGame()
    {
        StartCoroutine(LoadScene());
    }
    public void QuitGame()
    {
        Application.Quit();
    }

   private IEnumerator LoadScene()
    {
        trans.SetActive(true);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetSFXVolume(float sfxVolume)
    {
        sfxMixer.SetFloat("SFX", sfxVolume);
    }
}