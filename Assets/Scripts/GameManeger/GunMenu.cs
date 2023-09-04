using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunMenu : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] FloatVariable money;
    int frlvl, dmglvl, maglvl, rangelvl;
    [SerializeField] Image[] frLevels = new Image[9];
    [SerializeField] Image[] dmgLevels = new Image[9];
    [SerializeField] Image[] magLevels = new Image[9];
    [SerializeField] Image[] rangeLevels = new Image[9];
    float price = 20;
   public void FireRate()
    {
        if(money.value < price || frlvl >=9)
        {
            return;
        }
        gunData.fireRate -= 0.05f;
        frLevels[frlvl].color = Color.cyan;
        frlvl++;
        money.value -= price;
    }
    public void Damage()
    {
        if (money.value < price || dmglvl >= 9)
        {
            return;
        }
        gunData.damage += 30 ;
        dmgLevels[dmglvl].color = Color.cyan;
        dmglvl++;
        money.value -= price;
    }
    public void Magazine()
    {
        if (money.value < price || maglvl >= 9)
        {
            return;
        }
        gunData.magazineSize +=25;
        magLevels[maglvl].color = Color.cyan;
        maglvl++;
        money.value -= price;
    }
    public void Range()
    {
        if (money.value < price || rangelvl >= 9)
        {
            return;
        }
        gunData.range +=5f;
        rangeLevels[rangelvl].color = Color.cyan;
        rangelvl++;
        money.value -= price;
    }
}
