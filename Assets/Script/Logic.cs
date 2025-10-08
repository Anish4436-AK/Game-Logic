using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public TextMeshProUGUI welcome;
    public TextMeshProUGUI result;
    public TextMeshProUGUI successful;
    public TextMeshProUGUI Task;
    public TextMeshProUGUI win;

    public TMP_InputField ValA;
    public TMP_InputField ValB;
    public TMP_InputField ValC;

    public Button Nextvar;

    public int GuessAdd;
    public int GuessMul;

    public int RandA;
    public int RandB;
    public int RandC;

    public int GameComplexity = 1;

    public int RandAdd;
    public int RandMul;

    int GuessA;
    int GuessB;
    int GuessC;

    

    // Start is called before the first frame update
    void Start()
    {
        welcomemsg();
        if (Login.instance.isEasy == true)
        {
            GameComplexity = 0;
        }
        else if (Login.instance.isMedium == true)
        {
            GameComplexity = 1;
        }
        else
        {
            GameComplexity = 2;
        }
            
        RandA=UnityEngine.Random.Range(2,6);
        RandB=UnityEngine.Random.Range(2,6);
        RandC=UnityEngine.Random.Range(2,6);
        RandAdd =RandA+RandB+RandC;
        RandMul=RandA*RandB*RandC;
        Task.text=("Add: "+RandAdd+" Mul: "+RandMul);

        Nextvar.gameObject.SetActive(false);
    }
    public void welcomemsg()
    {
        if (Login.instance.isFemale == true)
        {
            welcome.text = "Welcome " + Login.instance.Name + "/Female";
        }
        else
        {
            welcome.text = "Welcome " + Login.instance.Name + "/Male";
        }
    }

        // Update is called once per frame
    void Update()
    {
    //CheckGuess();
    result.text=("ADD="+GuessAdd+" MUL="+GuessMul);
    if(GameComplexity==4)
      {
          win.text="You Won The Game...";
          Nextvar.gameObject.SetActive(false);
      }      
    }
   
    public void CheckGuess()
    {
        GuessA=Convert.ToInt32(ValA.text);
        GuessB=Convert.ToInt32(ValB.text);
        GuessC=Convert.ToInt32(ValC.text);
        GuessAdd=GuessA+GuessB+GuessC;
        GuessMul=GuessA*GuessB*GuessC;
        if(GuessAdd==RandAdd && GuessMul==RandMul)
        {
            successful.text="Congrtulations!,you pass the test";
            GameComplexity += 1;
            Nextvar.gameObject.SetActive(true);
            //NextLevel();
           
        }
        else
        {
            successful.text="Failed,please try again..";
        }
        Debug.Log("Value of A: "+GuessA+"Value of B: "+GuessB+"Value of C: "+GuessC+" ADD="+GuessAdd+" MUL="+GuessMul);
          
    }
    public void NextLevel()
    {
        //SceneManager.LoadScene(1);
        welcomemsg();
        ValA.text="";
        ValB.text="";
        ValC.text="";
        GuessAdd=0;
        GuessMul=0;
        RandA=UnityEngine.Random.Range(2,6) + GameComplexity;
        RandB=UnityEngine.Random.Range(2,6) + GameComplexity;
        RandC=UnityEngine.Random.Range(2,6) + GameComplexity;
        RandAdd=RandA+RandB+RandC;
        RandMul=RandA*RandB*RandC;
        Task.text=("Add: "+RandAdd+" Mul: "+RandMul);
        Nextvar.gameObject.SetActive(false);
        CheckGuess();
        
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
        welcome.text ="";
    }
}
