using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public string[] colors = { "Red", "Green", "Yellow", "Blue" };
    public List<string> order = new List<string>();
    public List<string> check = new List<string>();
    public List<string> orderUp = new List<string>() { "Red", "Blue", "Green", "Yellow" };
    public List<string> rainbow = new List<string>() { "Red", "Yellow", "Green", "Blue" };
    public List<string> orderDown = new List<string>();



    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject yellow;

    AudioManager audioManager;

    public int step = 0;
    public bool playerTurn = false;
    public int round = 1;
    public int amount = 4;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
       
        orderDown = new List<string>(orderUp);
        orderDown.Reverse();
        GenerateSequence(amount);
        StartCoroutine(PlaySequence());

    }

    void GenerateSequence(int length)
    {
      
        Debug.Log("Current round:" + round.ToString());
        order.Clear();
        for (int i = 0; i < length; i++)
        {
            order.Add(colors[Random.Range(0, colors.Length)]);
        }
        if(order == rainbow)
        {
            round -= 1;
            ResetGame();
        }
        else if(order == orderDown)
        {
            round -= 1;
            ResetGame();
        }
        else if(order == orderUp)
        {
            round -= 1;
            ResetGame();
        }
    }
    IEnumerator PlaySequence()
    {
        playerTurn = false;
        yield return new WaitForSeconds(2f);

        foreach (string color in order)
        {
            if(color == "Red")
            {
                red.SetActive(true);
                audioManager.PlayBeep(audioManager.red);
                yield return new WaitForSeconds(1f);
                red.SetActive(false);

            }
            if (color == "Green")
            {
                green.SetActive(true);
                audioManager.PlayBeep(audioManager.green);
                yield return new WaitForSeconds(1f);
                green.SetActive(false);


            }
            if (color == "Blue")
            {
                blue.SetActive(true);
                audioManager.PlayBeep(audioManager.blue);
                yield return new WaitForSeconds(1f);
                blue.SetActive(false);


            }
            if (color == "Yellow")
            {
                yellow.SetActive(true);
                audioManager.PlayBeep(audioManager.yellow);
                yield return new WaitForSeconds(1f);
                yellow.SetActive(false);


            }
            yield return new WaitForSeconds(0.5f);

        }

        playerTurn = true;
        step = 0;
        check.Clear();
    }


    public void OnColorClicked(string color)
    {
        if (!playerTurn) return;


        check.Add(color);
        Debug.Log("Player clicked: " + color);
        bool isCorrectColor = false;


        if (check[step] == order[step])
        {
            isCorrectColor = true;
        }
        else if (check[step] == orderUp[step])
        {
            isCorrectColor = true;
        }
        else if (check[step] == orderDown[step])
        {
            isCorrectColor = true;
        }
        else if(check[step] == rainbow[step])
        {
            isCorrectColor = true;
        }

    
        if (!isCorrectColor)
        {
            Debug.Log("? Game over");
            step = 0; 
            check.Clear(); 
            return; 
        }


        step++;

        if (step == order.Count)
        {
            Debug.Log("Done");
            ResetGame();
        }
    }

    public void OnShowAgainClicked()
    {
        StartCoroutine(PlaySequence());
        step = 0;
        check.Clear();

    }
    void ResetGame()
    {
        step = 0;
        check.Clear();
        round += 1;
        GenerateSequence(amount);
        StartCoroutine(PlaySequence());
    }


    // Update is called once per frame
    void Update()
    {
       

        
    }

}
