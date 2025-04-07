using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAgain : MonoBehaviour
{
    public Kontrol kontrol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        kontrol.OnShowAgainClicked();
        Debug.Log("clicked");
    }
}
