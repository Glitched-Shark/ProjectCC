using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public struct cardData
{
    public string m_name;
    public int atk_power;
    public Sprite cardFrontView;
}

[CreateAssetMenu(fileName = "Card Library", menuName = "ScriptableObjects/SO_CardLibrary", order = 1)]
public class SO_CardsLibary : ScriptableObject
{
    public List<cardData> cards;
    public Sprite cardBackView;
    public GameObject battleCardPrefab;
    public Sprite[] numberFont = new Sprite[3];
}
