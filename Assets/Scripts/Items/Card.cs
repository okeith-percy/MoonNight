using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite cardSprite;
    public string desc;


    public void PlayCard()
    {
        Debug.Log("Damn this card");
    }


}
