using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSound : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite SoundOn;
    public Sprite SoundOff;
    void Start()
    {
        
    }

    public void MelodyOn()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOn;
    }

    public void MelodyOff()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = SoundOff;
    }
}
