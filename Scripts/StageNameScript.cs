using System.Collections;
using UnityEngine;
public class StageNameScript : MonoBehaviour
{
    [SerializeField] GameObject stage;
    void Start()
    {
        StartCoroutine(StageName());
    }
    IEnumerator StageName()
    {
        yield return new WaitForSeconds(4);
        Destroy(stage);
    }
}