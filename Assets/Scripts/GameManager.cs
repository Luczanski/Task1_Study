using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI response;
    public TextMeshProUGUI botnum;
   
    public TMP_InputField inputField;
    public GameObject play;


    //Przedia³ liczb poczatkowy
    public int Max;
    public int Min;
    //obecny przedzial liczb
    public int curretnMax ;
    public int curretnMin ;

    //Sprawdzamy, którego przedzialu uzyc czy pierwszego czy juz obecnego zmienionego podanymi wczesniej liczbami np pierwszy 0-20 pozniej 0-12 , 2-12 , 2-8 itp.
    bool firstpickmin;
    bool firstpickmax;

    public int randomNumber;
   

   



    // Start is called before the first frame update
    void Start()
    {
        response.text = "start game";
        gameObject.SetActive(true);

    }
    public void startGame()
    {

        response.text = "Wpisz Liczbe z zakresu " + Min + " do " + Max;
        play.gameObject.SetActive(false);
        
    }
    public void buttonLower(string input) //fukcja przycisku Lower
    {
        input = inputField.text; 
        int.TryParse(input, out int result);
        Debug.Log(result);
        
        Debug.Log(randomNumber);
        curretnMax = randomNumber;

        if (firstpickmax == true || firstpickmin == true) {  //sprawdzamy czy to jest pierwsze "Klikniecie przycisku lower i czy nie jest tez ktores pod rzad i którego przedialu ma urzyc bot przy odgadywaniu dalej.
            firstpickmin = false;
            randomNumber = Random.Range(Min, curretnMax);
        botnum.text = "Bot number: " + randomNumber;
        Debug.Log(curretnMax);
        Debug.Log(curretnMin);
            
    }
        else{ 
            
            randomNumber = Random.Range(curretnMin, curretnMax);
            botnum.text = "Bot number: " + randomNumber;
            Debug.Log(curretnMax);
            Debug.Log(curretnMin);
            firstpickmax = false;
            firstpickmin = false;

        }
        if (result == randomNumber) // sprawdzamy czy komputer zgadl liczbe. 
        {
            botnum.text = "Bot number: " + randomNumber + "\n Win";
            Start();
        }

    }
    public void buttonUpper(string input) //funkcja przycisku higher
    {
        input = inputField.text;
        int.TryParse(input, out int result);
        Debug.Log(result);
        Debug.Log(randomNumber);
         curretnMin= randomNumber;

        if (firstpickmax == true || firstpickmin == true) //sprawdzamy czy to jest pierwsze "Klikniecie przycisku higher i którego przedialu ma urzyc bot przy odgadywaniu dalej.
        {
            firstpickmax = false;
            randomNumber = Random.Range(curretnMin, Max);
            botnum.text = "Bot number: " + randomNumber;
            Debug.Log(curretnMax);
            Debug.Log(curretnMin);
           
        }
        else if(curretnMax !=0)
        {
            
            randomNumber = Random.Range(curretnMin, curretnMax);
            botnum.text = "Bot number: " + randomNumber;
            Debug.Log(curretnMax);
            Debug.Log(curretnMin);
            firstpickmax = false;
            firstpickmin= false;
        }

        if (result == randomNumber) // sprawdzamy czy komputer zgadl liczbe. 
        {
            botnum.text = "Bot number: " + randomNumber + "\n Win";
            Start();
        }

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void GetInput(string input)
    {
        
        Debug.Log(input);
        firstpickmin = true;
        firstpickmax = true;

        response.text = "Your number is: " + input;

        randomNumber = Random.Range(Min, Max);


        botnum.text = "Bot number: " + randomNumber;
        

    }
  
}

