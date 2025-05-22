using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Kontrol : MonoBehaviour
{
    [Header("--------Lists--------")]
    public string[] colors = { "Red", "Green", "Yellow", "Blue" };
    public List<string> order = new List<string>();
    public List<string> check = new List<string>();
    public List<string> orderUp = new List<string>() { "Red", "Blue", "Green", "Yellow" };
    public List<string> rainbow = new List<string>() { "Red", "Yellow", "Green", "Blue" };
    public List<string> orderDown = new List<string>();
    public List<string> melody = new List<string>() { "Red", "Green", "Blue", "Red", "Blue", "Yellow" };
    List<string> outputs = new List<string>() {
        "Subjektet vaknade enligt protokoll.Förvirrad men stabil.De första testerna visade lovande respons.Intelligensnivå, relativt hög.Fortsättning sektion B" , 
        "Du är inte ensam. Någon iakttar allt. Tänk på vad du hör – vissa budskap vill hjälpa, andra vill ta kontroll.", 
        "Du har redan gått längre än de flesta. Fascinerande. Jag undrar… vad blir kvar av dig när vi är färdiga?", 
        "Han kallar det “Det perfekta sinnet” men vi vet inte vad han tänker göra med det. Du måste ta dig ur innan fas 3", 
        "Projektet skulle rädda mänskligheten. Men han förändrades. Började prata om evolution, om en ny ordning. De flesta av oss stängdes ner. Jag gömde mig. Jag är rädd" };

    [Header("--------Game Objects--------")]
    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject yellow;
    public GameObject canvas;

    AudioManager audioManager;
    ChangeSound changeSound;

    public TMP_Text story;

    [Header("--------Ints--------")]
    public int step = 0;
    public int round = 1;
    public int amount = 4;
    public int melodyStep;
    int postit = 0;
    int postit2 = 0;
    int postit3 = 0;
    int whatText = 0;

    [Header("--------Bools--------")]
    public bool canvasActive;
    public bool playerTurn = false;
    bool melodyOrder = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        changeSound = GameObject.FindGameObjectWithTag("Sound").GetComponent<ChangeSound>();
    }

    void Start()
    {
        orderDown = new List<string>(orderUp);
        orderDown.Reverse();
        canvasActive = false;
        GenerateSequence(amount);
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
        StartCoroutine(PlaySequence());
    }
    IEnumerator PlaySequence()
    {
        if (canvasActive == false)
        {
            yield return new WaitForSeconds(2f);
            changeSound.MelodyOn();
            audioManager.PlayMusic(audioManager.Melody);
            playerTurn = false;
            yield return new WaitForSeconds(6f);
            changeSound.MelodyOff();

            foreach (string color in order)
            {
                if (color == "Red")
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
        
    }


    public void OnColorClicked(string color)
    {
        if (!playerTurn) return;


        check.Add(color);
        Debug.Log("Player clicked: " + color);
        bool isCorrectColor = false;
        if (step < melody.Count && check[step] == melody[step])
        {
            isCorrectColor = true;
            melodyStep += 1;
        }

        
        
        if ( step < order.Count && check[step] == order[step])
        {
            isCorrectColor = true;
        }
        else if (step < orderUp.Count && check[step] == orderUp[step])
        {
            isCorrectColor = true;
        }
        else if (step < orderDown.Count && check[step] == orderDown[step])
        {
            isCorrectColor = true;
        }
        else if (step < rainbow.Count && check[step] == rainbow[step])
        {
            isCorrectColor = true;
        }
        
        else
        {
            Debug.Log("MELODY");
        }

        if(melodyStep == 4)
        {
            melodyOrder = true;
        }
        if(melodyOrder == false)
        {
            if (check.Count == order.Count)
            {
                for(int h = 0; h<4; h++)
                {
                    Debug.Log("Inside for loop");
                    if (orderUp[h] == check[h])
                    {
                        postit += 1;
                       
                    }
                    if (orderDown[h] == check[h])
                    {
                        postit2 += 1;
                    }
                    if (rainbow[h] == check[h])
                    {
                        postit3 += 1;
                    }

                }
                if (postit == 4 || postit2 == 4 || postit3 == 4)
                {
                    whatText += 1;
                    canvas.SetActive(true);
                    story.text = outputs[whatText - 1];
                    postit = 0;
                    postit2 = 0;
                    postit3 = 0;
                }
                else
                {
                    Debug.Log("Done");
                    melodyOrder = false;
                    ResetGame();
                }
                
            }
        }
        if(melodyOrder == true )
        {
            if(check.Count == melody.Count)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (check[y] == melody[y])
                    {
                        whatText += 1;
                        canvas.SetActive(true);
                        story.text = outputs[whatText - 1];
                    }
                }
            }
           
            
        }
    
        if (!isCorrectColor)
        {
            Debug.Log("? Game over");
            step = 0; 
            check.Clear();
            melodyOrder = false;
            return;
        }


        step++;

        
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
