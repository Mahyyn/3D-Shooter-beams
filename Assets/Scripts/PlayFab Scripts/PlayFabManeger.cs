using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayFabManeger : MonoBehaviour
{
    public TMP_InputField LUsername, LPassword, RUsername, RPassword,RPasswordC, REmail;
    public TMP_Text Message;
    public GameObject login_System, register_System;
    public void Resgister()
    {
        if (!register_System.active)
        {
            Message.text = "";
            return;
        }
        if (RPassword.text != RPasswordC.text)
        {
            Message.text = "Passwords do not match.";
            return;
        }
        if (RPassword.text.Length >= 8)
        {
            var request = new RegisterPlayFabUserRequest
            {
                Email = REmail.text,
                Password = RPassword.text,
                Username = RUsername.text,

            };
            PlayFabClientAPI.RegisterPlayFabUser(request,Register_Succes,Failure);
        }
        else
        {
            Message.text = "Password to short. Minimum 8 charecters";
        }
    }


    public void Login()
    {
        if (!login_System.active)
        {
            Message.text = "";
            return;
            
        }
        var request = new LoginWithPlayFabRequest
        {
            Username = LUsername.text,
            Password = LPassword.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithPlayFab(request, Login_Succes, Failure);

    }

    void Login_Succes(LoginResult result)
    {
        CheckName(result.InfoResultPayload.PlayerProfile.DisplayName);
        
        SceneManager.LoadScene("MainMenu");

    }



    void Register_Succes(RegisterPlayFabUserResult result)
    {
        Message.text = "Registerd Succesfully";
    }
    void Failure(PlayFabError error)
    {
        Message.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    void CheckName(string name)
    {
        if (name == null)
        {
            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = LUsername.text
            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnNameChanged, Failure);
        }
    }
    void OnNameChanged(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Name Created");
    }
    public void SwitchToRegister()
    {
        login_System.SetActive(false);
        register_System.SetActive(true);
    }
    public void SwitchToLogin()
    {
        login_System.SetActive(true);
        register_System.SetActive(false);
    }
}
