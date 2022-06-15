using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum CardType
{
    Sword = 0,
    PoisonDagger,
    Shield,
    Medicine,
}

[System.Serializable]
public struct cardData
{
    public string m_name;
    public CardType m_type;
    public Sprite cardSprite;
}

[CreateAssetMenu(fileName = "Card Library", menuName = "ScriptableObjects/SO_CardLibrary", order = 1)]
public class SO_CardsLibary : ScriptableObject
{
    public List<cardData> cards;
    public Sprite cardBackView;
    public GameObject battleCardPrefab;
    public Sprite[] cardNumberSprite = new Sprite[5];
}
