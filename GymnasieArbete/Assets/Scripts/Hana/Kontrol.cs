using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public string[] colors = { "Red", "Green", "Yellow", "Blue" };
    public List<string> order = new List<string>();
    public List<string> check = new List<string>();


    public int step = 0;
    public bool playerTurn = false;
    void Start()
    {
        GenerateSequence(4); 
        
    }

    // Generate a random sequence
    void GenerateSequence(int length)
    {
        order.Clear();
        for (int i = 0; i < length; i++)
        {
            order.Add(colors[Random.Range(0, colors.Length)]);
        }
    }
    System.Collections.IEnumerator PlaySequence()
    {
        playerTurn = false;
        yield return new WaitForSeconds(1f);

        foreach (string color in order)
        {
            Debug.Log("Simon Says: " + color);
            yield return new WaitForSeconds(1f);
        }

        playerTurn = true;
        step = 0;
        check.Clear();
    }

    // Call this when a color button is clicked
    public void OnColorClicked(string color)
    {
        if (!playerTurn) return;

        check.Add(color);
        Debug.Log("Player clicked: " + color);

        if (check[step] != order[step])
        {
            Debug.Log("Wrong Color! Game Over.");
            ResetGame();
            return;
        }

        step++;

        if (step == order.Count)
        {
            Debug.Log("Correct Sequence! Next Round.");
            StartCoroutine(PlaySequence());
        }
    }

    void ResetGame()
    {
        step = 0;
        check.Clear();
        GenerateSequence(4);
        StartCoroutine(PlaySequence());
    }


    // Update is called once per frame
    void Update()
    {
       

        
    }


    public void ReactToClick()
    {
        
        Debug.Log("Objects been clicked");
    }
}
