using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroScript : MonoBehaviour
{
   void Update()
    {
        if (Input.GetButtonDown("Enable Debug Button 2") || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}
