using UnityEngine;
using UnityEngine.UI;
using TMPro;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite cardSprite;
    [TextArea(1, 3)]
    public string cardDesc;

}

[System.Serializable]
public class CardPrefab
{
    public TMP_Text card_name;
    public Image card_image;
    public GameObject CardDisplay;
    public TMP_Text card_description;

}