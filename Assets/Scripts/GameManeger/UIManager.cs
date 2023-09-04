using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text hptxt, magtxt, ammotxt, moneytxt, wavetxt, ability1CD, ability2CD, ability3CD;
    [SerializeField] FloatVariable wave, money, playerHealth;
    [SerializeField] AbilityData ability1, ability2, ability3;
    [SerializeField] BoolVariable isImmortal;
    [SerializeField] GunData gunData;
    [SerializeField] Texture timeStop, invisible, tp, timeSlow, immortal, oni, boost, turret, drop;
    [SerializeField] RawImage ability1Image,ability2Image, ability3Image;
    [SerializeField] Transform ability1Shade, ability2Shade, ability3Shade;
    bool a = false, b = false,c = false;
    void Start()
    {
        ability1Shade.localScale = new Vector3(0.35f, 0, 0.35f);
        ability2Shade.localScale = new Vector3(0.5f, 0, 0.5f);
        ability3Shade.localScale = new Vector3(0.35f, 0, 0.35f);
        ability1CD.text = "";
        ability2CD.text = "";
        ability3CD.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        IconsUpdate();
        TextUpdate();
    }

    void IconsUpdate()
    {
        if (ability1.value == 1)
        {
            ability1Image.texture = timeStop;
            ability1Image.color = new Color(0.990566f, 0.1822268f, 0.1822268f);
        }
        else if (ability1.value == 2)
        {
            ability1Image.texture = invisible;
            ability1Image.color = new Color(1, 1, 1);
        }
        else if (ability1.value == 3)
        {
            ability1Image.texture = tp;
            ability1Image.color = new Color(0, 0.6283614f, 0.7607843f);
        }

        if (ability2.value == 1)
        {
            ability2Image.texture = timeSlow;
            ability2Image.color = new Color(0.2584563f, 0.8018868f, 0.117257f);
        }
        else if (ability2.value == 2)
        {
            ability2Image.texture = immortal;
            ability2Image.color = new Color(1f, 0.9349554f, 0.08962262f);
        }
        else if (ability2.value == 3)
        {
            ability2Image.texture = oni;
            ability2Image.color = new Color(1, 0, 0.3811417f);
        }

        if (ability3.value == 1)
        {
            ability3Image.texture = boost;
            ability3Image.color = new Color(1, 0.499525f, 0);
        }
        else if (ability3.value == 2)
        {
            ability3Image.texture = turret;
            ability3Image.color = new Color(0.5582843f, 0, 1);
        }
        else if (ability3.value == 3)
        {
            ability3Image.texture = drop;
            ability3Image.color = new Color(0.639955f, 1, 0);
        }
    }

    void TextUpdate()
    {
        if (isImmortal.value)
        {
            hptxt.text = "?";

        }
        else
        {
            hptxt.text = playerHealth.value.ToString();
        }
        magtxt.text = gunData.magazine.ToString();
        ammotxt.text = gunData.ammo.ToString();
        moneytxt.text = "$" + money.value.ToString();
        wavetxt.text = "Wave " + wave.value.ToString();

        if(ability1.coolDown > 0)
        {
            if (a)
            {
                ability1Shade.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                a = false;
            }
                float y= ability1Shade.localScale.y;
            y -= (Time.deltaTime * 0.35f) / 30;
            ability1Shade.localScale = new Vector3(0.35f, y, 0.35f);
            ability1CD.text = Mathf.Round(ability1.coolDown).ToString();
        }
        else
        {
            ability1CD.text = "";
            a = true;
        }

        if (ability2.coolDown > 0)
        {
            if (b)
            {
                ability2Shade.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                b = false;
            }
            float y = ability2Shade.localScale.y;
            y -= (Time.deltaTime * 0.5f) / 90;
            ability2Shade.localScale = new Vector3(0.5f, y, 0.5f);
            ability2CD.text = Mathf.Round(ability2.coolDown).ToString();
        }
        else
        {
            ability2CD.text = "";
            b = true;

        }

        if (ability3.coolDown > 0)
        {
            if (c)
            {
                ability3Shade.localScale = new Vector3(0.35f, 0.35f, 0.35f);
                c = false;
            }
            float y = ability3Shade.localScale.y;
            y -= (Time.deltaTime * 0.35f) / 60;
            ability3Shade.localScale = new Vector3(0.35f, y, 0.35f);
            ability3CD.text = Mathf.Round(ability3.coolDown).ToString();
        }
        else
        {
            ability3CD.text = "";
            c=true;
        }
    }
}
