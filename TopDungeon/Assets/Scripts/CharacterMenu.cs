using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text LevelText, hitpointText, pesosText, upgradecostText, xpText;

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



}
