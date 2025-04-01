using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public string[] colors = { "Red", "Green", "Yellow", "Blue" };
    public List<string> order = new List<string>();
    public List<string> check = new List<string>();

    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject yellow;



    public int step = 0;
    public bool playerTurn = false;
    void Start()
    {
        GenerateSequence(4);
        StartCoroutine(PlaySequence());

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
    IEnumerator PlaySequence()
    {
        playerTurn = false;
        yield return new WaitForSeconds(1f);

        foreach (string color in order)
        {
            if(color == "Red")
            {
                red.SetActive(true);
                yield return new WaitForSeconds(1f);
                red.SetActive(false);

            }
            if (color == "Green")
            {
                green.SetActive(true);
                yield return new WaitForSeconds(1f);
                green.SetActive(false);


            }
            if (color == "Blue")
            {
                blue.SetActive(true);
                yield return new WaitForSeconds(1f);
                blue.SetActive(false);


            }
            if (color == "Yellow")
            {
                yellow.SetActive(true);
                yield return new WaitForSeconds(1f);
                yellow.SetActive(false);


            }
            yield return new WaitForSeconds(0.5f);

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
            Debug.Log("Game over");
            ResetGame();
            return;
        }

        step++;

        if (step == order.Count)
        {
            Debug.Log("Done");
            ResetGame();
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

}
