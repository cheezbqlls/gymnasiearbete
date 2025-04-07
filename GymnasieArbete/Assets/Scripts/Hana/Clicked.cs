using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour
{
    public int count;
    public string clicked;
    public GameObject light;
    public Kontrol kontrol;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public async void OnMouseDown()
    {
        Debug.Log("yes");
        count += 1;
        if(gameObject.name == "Red")
        {
            audioManager.PlayBeep(audioManager.red);
        }
        if (gameObject.name == "Blue")
        {
            audioManager.PlayBeep(audioManager.blue);
        }
        if (gameObject.name == "Green")
        {
            audioManager.PlayBeep(audioManager.green);
        }
        if (gameObject.name == "Yellow")
        {
            audioManager.PlayBeep(audioManager.yellow);
        }
        light.SetActive(true);
        Invoke("TurnOffLight", 1f);
        kontrol.OnColorClicked(gameObject.name);

    }

    public void TurnOffLight()
    {
        light.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
