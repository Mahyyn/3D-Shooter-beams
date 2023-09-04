using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilitiesMenu : MonoBehaviour
{
    bool timeStop, invisble, tp, timeSlow, immortal, oni, boost, turret, drop;
    [SerializeField] AbilityData ability1, ability2, ability3;
    [SerializeField] FloatVariable money;
    [SerializeField] TMP_Text descriptionTxt, priceTxt;
    [SerializeField] GameObject buy, equip;
    float price;
    string sellectedAbility;


    public void TimeStop()
    {
        descriptionTxt.text = "Description: None can move including you. However you can still shoot.\nDuration: 10 seconds \nCooldown: 30 seconds";
        price = 50;
        priceTxt.text = "Price: $"+price.ToString();
        sellectedAbility = "timestop";
        if (timeStop)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void Invisible()
    {
        descriptionTxt.text = "Description: You are invisible. None can see you, however you can not shoot.\nDuration: 10 seconds\nCooldown: 30 seconds";
        price = 50;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "invisible";
        if (invisble)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void TP()
    {
        descriptionTxt.text = "Description: You will teleport where your bullet hits.\nDuration: 1 bullet\nCooldown: 30 seconds";
        price = 50;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "tp";
        if (tp)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void TimeSlow()
    {
        descriptionTxt.text = "Description: Time is slowed down. You also can shoot and move faster.\nDuration: 25 seconds \nCooldown: 90 seconds";
        price = 200;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "timeslow";
        if (timeSlow)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void Immortal()
    {
        descriptionTxt.text = "Description: You achive immortality. You have infinite health.\nDuration: 25 seconds\nCooldown: 90 seconds";
        price = 200;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "immortal";
        if (immortal)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void Oni()
    {
        descriptionTxt.text = "Description: You are possessed by a Oni. You will shoot and move faster. You will take less damage. You will deal more damage.\nDuration: 25 seconds\nCooldown: 90 seconds";
        price = 200;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "oni";
        if (oni)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void Boost()
    {
        descriptionTxt.text = "Description: You can shoot faster and run faster.\nDuration: 20 seconds\nCooldown: 60 seconds";
        price = 100;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "boost";
        if (boost)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void Turret()
    {
        descriptionTxt.text = "Description: A Turret will be spwaned. It will lock onto the closest enemy and fire at them.\nDuration: 20 seconds\nCooldown: 60 seconds";
        price = 100;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "turret";
        if (turret)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }
    public void Drop()
    {
        descriptionTxt.text = "\"Description: You will recover HP and Ammo.\nDuration: N/A\nCooldown: 60 seconds";
        price = 100;
        priceTxt.text = "Price: $" + price.ToString();
        sellectedAbility = "drop";
        if (drop)
        {
            equip.SetActive(true);
            buy.SetActive(false);
        }
        else
        {
            equip.SetActive(false);
            buy.SetActive(true);
        }
    }

    public void Buy()
    {
        if (money.value < price)
        {
            return;
        }

        if(sellectedAbility == "timestop") { timeStop = true; }
        else if (sellectedAbility == "invisible") { invisble = true; }
        else if (sellectedAbility == "tp") { tp = true; }
        else if (sellectedAbility == "timeslow") { timeSlow = true; }
        else if (sellectedAbility == "immortal") { immortal = true; }
        else if (sellectedAbility == "oni") { oni = true; }
        else if (sellectedAbility == "boost") { boost = true; }
        else if (sellectedAbility == "turret") { turret = true; }
        else if (sellectedAbility == "drop") { drop = true; }
        money.value -= price;
        equip.SetActive(true);
        buy.SetActive(false);

    }
    public void Equip()
    {
        if (sellectedAbility == "timestop") { ability1.value = 1; }
        else if (sellectedAbility == "invisible") { ability1.value = 2; }
        else if (sellectedAbility == "tp") { ability1.value = 3; }
        else if (sellectedAbility == "timeslow") { ability2.value = 1; }
        else if (sellectedAbility == "immortal") { ability2.value = 2; }
        else if (sellectedAbility == "oni") { ability2.value = 3; }
        else if (sellectedAbility == "boost") { ability3.value = 1; }
        else if (sellectedAbility == "turret") { ability3.value = 2; }
        else if (sellectedAbility == "drop") { ability3.value = 3; }
    }

}
