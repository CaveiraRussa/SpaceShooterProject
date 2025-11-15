using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(PlayAudio());
    }
    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponent<AudioSource>().Play();// ativa o som
    }
}
