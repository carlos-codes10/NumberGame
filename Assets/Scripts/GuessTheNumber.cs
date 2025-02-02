using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using Unity.Burst.CompilerServices;

public class GuessTheNumber : MonoBehaviour
{
    [SerializeField] TMP_InputField textInput;
    [SerializeField] TMP_Text titleText;
    int Number;
    int Attempts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()  //made void public for 'Reset Game' button.
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void GameSetup()
    {
        Attempts = 3;
        Number = Random.Range(1, 11);
        Debug.Log(Number); //Testing Purposes
        titleText.text = "Guess a number between 1-10! Attempts: 3";
        textInput.text = "";
    }



    public void SubmitGuess()
    {
        
        if (!int.TryParse(textInput.text, out int PlayerGuess))
        {
            return;
        }

        if (PlayerGuess == Number && Attempts >= 1)
        {
            titleText.text = "Correct You Won!";
            Attempts = 0;
        }
        else if (PlayerGuess != Number && Attempts == 3)
        {
            titleText.text = "Wrong! 2 Attempts Remain!";
            Attempts = 2;

        }
        else if (PlayerGuess != Number && Attempts == 2)
        {
            titleText.text = "Wrong! Last Attempt!";
            Attempts = 1;
        }
        else if (PlayerGuess != Number && Attempts == 1)
        {
            titleText.text = "Wrong! You Lose!";
            Attempts = 0;
        }

        

    }
}

