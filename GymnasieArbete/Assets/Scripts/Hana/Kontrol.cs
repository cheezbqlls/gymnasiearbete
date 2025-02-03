using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public static List<string> colors = new List<string>();
    public static List<string> order = new List<string>();
    int choise;
    bool debug = false;
    public Clicked script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colors.Add("Red");
        colors.Add("Blue");
        colors.Add("Green");
        colors.Add("Yellow");

        for(int i = 0; i < 5; i++)
        {
            choise = Random.Range(0, 4);
            order.Add(colors[choise]);
        }
        string counts = script.count.ToString();
        Debug.Log(counts);
    }

    public void ReactToClick()
    {
        
        Debug.Log("Objects been clicked");
    }
}
