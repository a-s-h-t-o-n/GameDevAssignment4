using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip[] audioTracks = new AudioClip[2];

    IEnumerator playIntro()
    {
        GetComponent<AudioSource>().clip = audioTracks[0];
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(audioTracks[0].length);
        StartCoroutine(playTracks());
    }

    IEnumerator playTracks()
    {
        GetComponent<AudioSource>().clip = audioTracks[1];
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(audioTracks[1].length);
        StartCoroutine(playTracks());
        

    }
    void Start()
    {
        StartCoroutine(playIntro());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
