using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLogo : MonoBehaviour
{
    public string newMap;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewFase());
    }
    IEnumerator NewFase()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(newMap);
    }
}
