using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitCanvas : MonoBehaviour
{
    public Button exit;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(HideUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HideUI()
    {
        canvas.SetActive(false);
    }
}
