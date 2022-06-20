using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public enum PlayerPhase
{
    Idle = 0,
    Draw,
    Play,
    End
}

[System.Serializable]
public struct CharacterData
{
    public int health;
    public List<CardType> cardTypes;
}

public class Player : MonoBehaviour
{
    protected const int startingHandCount = 5;
    protected int drawAmtEachTurn = 1; 
    public PlayerPhase m_phase;
    public int maxHealth;
    public int currentHealth;

    //Cards
    public SO_CardsLibary cardLibary;
    public List<int> m_deckCardIndex = new List<int>();
    public List<GameObject> m_hand = new List<GameObject>();
    public List<GameObject> m_deck = new List<GameObject>();
    public List<GameObject> m_discarded = new List<GameObject>();
    public Vector3 deckLocation;
    public Vector3 handMidpoint;

    //Hands Position
    protected Vector3 handStartPosition { get; set; }
    protected float handXOffset = 1.4f;
    protected float handZOffset = 1.5f;

    //PlayerStats
    public CharacterData playerData;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayerData(playerData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializePlayerData(CharacterData pData)
    {
        maxHealth = pData.health;
        currentHealth = maxHealth;
        m_deck.Clear();
        m_deck = GenerateDeck(pData.cardTypes);
        ShuffleDeck();
        LTMoveDrawnCardsToHand(DrawCard(5));
    }

    List<GameObject> GenerateDeck(List <CardType> cTypes)
    {
        List<GameObject> deck = new List<GameObject>();
        int totalCardNumber = cardLibary.cardNumberSprite.Length;
        for (int i = 0; i < cTypes.Count; i++)
        {
            for (int j = 0; j < totalCardNumber; j++)
            {
                GameObject card = Instantiate(cardLibary.battleCardPrefab, deckLocation, Quaternion.identity, this.gameObject.transform);
                if (card != null)
                {
                    BattleCard cardScript = card.GetComponent<BattleCard>();
                    cardScript.SetCardData(cardLibary.cards[(int)cTypes[i]], cardLibary.cardNumberSprite[j]);
                    cardScript.gameObject.SetActive(false);
                    deck.Add(card);
                }
            }
        }
        return deck;
    }

    public void ShuffleDeck()
    {
        //using System.Linq to use OrderBy 
        //Unity has its own random generator
        var tempDeck = m_deck.OrderBy(item => UnityEngine.Random.Range(0, int.MaxValue));
        m_deck = tempDeck.ToList<GameObject>();
    }

    public List<GameObject> DrawCard(int amount)
    {
        List<GameObject> drawn = new List<GameObject>();
        Vector3 cardPos = m_deck[0].transform.position;
        cardPos.z = handZOffset;

        for (int i = 0; i < amount; i++)
        {
            m_deck[0].transform.position = cardPos;
            m_deck[0].SetActive(true);
            m_hand.Add(m_deck[0]);
            drawn.Add(m_deck[0]);
            m_deck.Remove(m_deck[0]);

            cardPos.z -= handZOffset;
        }
        return drawn; 
    }

    public void LTMoveDrawnCardsToHand(List<GameObject> drawnCards)
    {
        if (drawnCards.Count > 0)
        {
            float cardXPos = (drawnCards.Count - 1) * handXOffset / -2.0f;
            for (int i = 0; i < drawnCards.Count; i++)
            {
                LeanTween.moveX(drawnCards[i], cardXPos, 0.5f).setDelay(0.5f * i);
                cardXPos += handXOffset;
            }
        }
    }

}
