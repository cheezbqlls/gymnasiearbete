using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public static List<string> colors = new List<string>();
    public static List<string> order = new List<string>();
    public static List<string> check = new List<string>();
    int choise;
    public Clicked Redscript;
    public Clicked Bluescript;
    public Clicked Greenscript;
    public Clicked Yellowscript;
    public int totalcount;

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
            Debug.Log(order[i]);
        }
        totalcount = Redscript.count + Bluescript.count + Greenscript.count + Yellowscript.count;
        string counts = totalcount.ToString();
        Debug.Log(counts);

        if(Redscript.count == 1)
        {
            check.Add("Red");
        }
        if(Redscript.count == 2)
        {
            check.Add("Red");
        }
        if (Redscript.count == 3)
        {
            check.Add("Red");
        }
        if (Redscript.count == 4)
        {
            check.Add("Red");
        }
        if (Redscript.count == 5)
        {
            check.Add("Red");
        }
        if (Bluescript.count == 1)
        {
            check.Add("Blue");
        }
        if (Bluescript.count == 2)
        {
            check.Add("Blue");
        }
        if (Bluescript.count == 3)
        {
            check.Add("Blue");
        }
        if (Bluescript.count == 4)
        {
            check.Add("Blue");
        }
        if (Bluescript.count == 5)
        {
            check.Add("Blue");
        }
        if (Greenscript.count == 1)
        {
            check.Add("Green");
        }
        if (Greenscript.count == 2)
        {
            check.Add("Green");
        }
        if (Greenscript.count == 3)
        {
            check.Add("Green");
        }
        if (Greenscript.count == 4)
        {
            check.Add("Green");
        }
        if (Greenscript.count == 5)
        {
            check.Add("Green");
        }
        if (Yellowscript.count == 1)
        {
            check.Add("Yellow");
        }
        if (Yellowscript.count == 2)
        {
            check.Add("Yellow");
        }
        if (Yellowscript.count == 3)
        {
            check.Add("Yellow");
        }
        if (Yellowscript.count == 4)
        {
            check.Add("Yellow");
        }
        if (Yellowscript.count == 5)
        {
            check.Add("Yellow");
        }
        for(int n = 0; n<5; n++)
        {
            if (order[n] == check[n])
            {
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("False");
            }
        }
    }


    public void ReactToClick()
    {
        
        Debug.Log("Objects been clicked");
    }
}
