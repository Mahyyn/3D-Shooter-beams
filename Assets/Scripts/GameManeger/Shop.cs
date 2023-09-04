using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject abillitiesButton, gunButton;
    [SerializeField] GameObject abilityMenu, gunMenu;


   public void Abilities()
    {
        gunButton.GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        abillitiesButton.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        abilityMenu.SetActive(true);
        gunMenu.SetActive(false);
    }

    public void Gun()
    {
        gunButton.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        abillitiesButton.GetComponent<UnityEngine.UI.Image>().color = Color.grey;
        abilityMenu.SetActive(false);
        gunMenu.SetActive(true);
    }
}
