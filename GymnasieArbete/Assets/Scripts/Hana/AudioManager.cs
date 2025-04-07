using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource beep;

    public AudioClip red;
    public AudioClip blue;
    public AudioClip green;
    public AudioClip yellow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBeep(AudioClip clip)
    {
        beep.PlayOneShot(clip);
    }
}
