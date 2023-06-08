using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroSceneScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Intro());
    }
    void Update()
    {
        if (Input.GetButtonDown("Enable Debug Button 2") || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(39);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
