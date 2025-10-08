using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public TMP_InputField Username;

    public Toggle Male;
    public Toggle Female;
    public Toggle Easy;
    public Toggle Medium;
    public Toggle Hard;

    public string Name;
    public bool isMale;
    public bool isFemale;
    public bool isEasy;
    public bool isMedium;
    public bool isHard;

    public static Login instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerLogin()
    {
        Name = Username.text;
        isMale = Male.isOn;
        isFemale = Female.isOn;

        isEasy = Easy.isOn;
        isMedium = Medium.isOn;
        isHard = Hard.isOn;

        Debug.Log("Username: " + Name);
        Debug.Log("Male is " + isMale);
        Debug.Log("Female is " + isFemale);
        Debug.Log("Easy is " + isEasy);
        Debug.Log("Medium is " + isMedium);
        Debug.Log("Hard is " + isHard);

        SceneManager.LoadScene(1);
    }
}