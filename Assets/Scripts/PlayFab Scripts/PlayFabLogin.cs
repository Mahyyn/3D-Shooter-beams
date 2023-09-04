using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabLogin : MonoBehaviour
{
    public InputField Username, Password;
    public Text Message;
    public GameObject Login_System, Register_System;
    public string scene_Name;


    public void Login()
    {
        if (!Login_System.active)
        {
            return;
        }
        var request = new LoginWithPlayFabRequest
        {
            Username = Username.text,
            Password = Password.text,
        };
        PlayFabClientAPI.LoginWithPlayFab(request, Login_Succes, Failure);

    }

    void Login_Succes(LoginResult result)
    {
        Message.text = "Succesfully Logged In";
        SceneManager.LoadScene(scene_Name);
    }
    void Failure(PlayFabError error)
    {
        Message.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    public void Switch()
    {
        Login_System.SetActive(true);
        Register_System.SetActive(false);
    }
 
}
