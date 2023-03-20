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
    [SerializeField]
    Item.MemoryType type;

    public Item.MemoryType GetMemoryType()
    {
        return type;
    }

}

[System.Serializable]
public class CardPrefab
{
    public TMP_Text card_name;
    public Image card_image;
    public GameObject Display;
    public TMP_Text card_description;


}

[System.Serializable]
public class CardGallery
{
    public CardPrefab[] cards;
    public GameObject Display;
}


