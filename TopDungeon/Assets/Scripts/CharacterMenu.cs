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


        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();


        int currLevel = GameManager.instance.GetCurrentLevel();


        if (currLevel == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + "Total experience points";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLevelXp = GameManager.instance.GetXpToLevel(currLevel - 1);
            int currLevelXp = GameManager.instance.GetXpToLevel(currLevel);

            int diff = currLevelXp - prevLevelXp;
            int currXpIntoLevel = GameManager.instance.experience - prevLevelXp;

            float completionRatio = (float)currLevelXp / (float)diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currXpIntoLevel.ToString() + "/" + diff;
        }    
    }
}
