using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFabRegister : MonoBehaviour
{
    public InputField Username, Password, PasswordC, Email;
    public Text Message;
    public GameObject Login_System,Register_System;
    public string scene_Name;
    public void Resgister()
    {
        if (!Register_System.active)
        {
            return;
        }
        if (Password.text != PasswordC.text)
        {
            Message.text = "Passwords do not match.";
            return;
        }
        if (Password.text.Length < 8)
        {
            Message.text = "Password to short";
            return ;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = Email.text,
            Password = Password.text,
            Username = Username.text,
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, Register_Succes, Failure);

    }
    void Register_Succes(RegisterPlayFabUserResult result)
    {
        Message.text = "Registered and Logged in";
        SceneManager.LoadScene(scene_Name);
    }
    void Failure(PlayFabError error)
    {
        Message.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    


}
