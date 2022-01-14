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
    }

    public void onUpgradeClick()
    {

    }
    public void UpdateMenu()
    {
        WeaponSprite.sprite = GameManager.instance.weaponSprite[0];
        upgradecostText.text = "NOT IMPLEMENTED";


        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        pesosText.text = GameManager.instance.pesos.ToString();

        levelText.text = "NOT IMPLEMENTED";



        xpText.text = "NOT IMPLEMENTED";
        xpBar.localScale = new Vector3(0.5f, 0, 0);

    }


}
