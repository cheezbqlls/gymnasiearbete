using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicked : MonoBehaviour
{
    public int count;
    public string clicked;
    public GameObject light;
    public Kontrol kontrol;

    public async void OnMouseDown()
    {
        Debug.Log("yes");
        count += 1;
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
