using System.Collections;
using UnityEngine;


public class SceneSequence : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    void Start()
    {
        StartCoroutine(TheSequence());
    }

   IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(4);
        Cam2.SetActive(true);
        yield return new WaitForSeconds(4);
        Cam3.SetActive(true);
        Cam2.SetActive(false);
    }
}
