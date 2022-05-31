using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Player
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void InitPlayerProperties()
    {
        handStartPosition = new Vector3(0.0f, 4.8f, 2.0f);
        maxHealth = 20;
        currentHealth = maxHealth;
        m_phase = PlayerPhase.Idle;

        m_deckCardIndex.Clear();
        m_deckCardIndex.Add(0);
        m_deckCardIndex.Add(0);
        m_deckCardIndex.Add(0);
        m_deckCardIndex.Add(0);
        m_deckCardIndex.Add(0);
        m_deckCardIndex.Add(1);
        m_deckCardIndex.Add(1);
        m_deckCardIndex.Add(1);
        m_deckCardIndex.Add(2);
        m_deckCardIndex.Add(2);
    }

    public override void Init()
    {
        InitPlayerProperties();
        ShuffleDeck();
        DrawCard(startingHandCount, false);
    }
}
