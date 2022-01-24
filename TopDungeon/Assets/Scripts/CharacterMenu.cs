using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text levelText, hitpointText, pesosText, upgradecostText, xpText;

    //logic
    private int currentCharacterSelection;
    public Image CharacterSelectionSprite;
    public Image WeaponSprite;
    public RectTransform xpBar;

    public void onArrowClick(bool right)
    {
        if(right)
        {
            currentCharacterSelection++;

            if(currentCharacterSelection == GameManager.instance.playerSprites.Count)

            {
                OnSelectionChanged();
            }
            else
            {
                currentCharacterSelection--;

                if (currentCharacterSelection < 0)
                    currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

                {
                    OnSelectionChanged();
                }
            }


        }
    }
    private void OnSelectionChanged()
    {
        CharacterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }

    public void onUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }
    public void UpdateMenu()
    {
        WeaponSprite.sprite = GameManager.instance.weaponSprite[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradecostText.text = "MAX";
        else
            upgradecostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();



        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();

        levelText.text = "NOT IMPLEMENTED";



        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5f, 0, 0);

    }


}
