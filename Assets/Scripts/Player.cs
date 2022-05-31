using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public enum PlayerPhase
{
    Idle = 0,
    Draw,
    Play,
    End
}

public class Player : MonoBehaviour
{
    protected const int startingHandCount = 3;
    protected int drawAmtEachTurn = 1; 
    public PlayerPhase m_phase;
    public int maxHealth;
    public int currentHealth;

    //Cards
    public SO_CardsLibary cardLibary;
    public List<int> m_deckCardIndex = new List<int>();
    public List<GameObject> m_hand = new List<GameObject>();
    //public List<cardData> m_discarded = new List<cardData>();

    //Hands Position
    protected Vector3 handStartPosition { get; set; }
    protected float handXOffset = 1.0f;
    protected float handZOffset = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Init()
    {
        InitPlayerProperties();
        ShuffleDeck();
        DrawCard(startingHandCount,false);
    }

    public virtual void InitPlayerProperties()
    {
        maxHealth = 20;
        currentHealth = maxHealth;
        m_phase = PlayerPhase.Idle; 
        m_deckCardIndex.Clear();
    }

    public void ShuffleDeck()
    {
        //using System.Linq to use OrderBy 
        //Unity has its own random generator
        var tempDeck = m_deckCardIndex.OrderBy(item => Random.Range(0, int.MaxValue));
        m_deckCardIndex = tempDeck.ToList<int>(); 
    }

    public void DrawCard(int amount, bool frontView)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject drawnCard = Instantiate(cardLibary.battleCardPrefab, handStartPosition, Quaternion.identity,this.gameObject.transform);
            BattleCard cardScript = drawnCard.GetComponent<BattleCard>();

            if (cardScript != null)
            {
                cardScript.SetCardData(cardLibary, m_deckCardIndex[i], frontView);
                m_hand.Add(drawnCard);
                m_deckCardIndex.RemoveAt(0);
            }
        }
        AdjustHandsPosition();
    }

    public void AdjustHandsPosition()
    {
        if (m_hand.Count > 0)
        {
            Vector3 cardPos = handStartPosition;
            cardPos.z = (m_hand.Count - 1) * handZOffset + handStartPosition.z;

            if (m_hand.Count == 1)
            {
                m_hand[0].transform.position = cardPos;
                return;
            }

            cardPos.x = (m_hand.Count - 1)*handXOffset/-2.0f;
            m_hand[0].transform.position = cardPos;

            for (int i = 1; i < m_hand.Count; i++)
            {
                cardPos.x += handXOffset;
                cardPos.z -= handZOffset;
                m_hand[i].transform.position = cardPos;

            }
        }
    }
}
