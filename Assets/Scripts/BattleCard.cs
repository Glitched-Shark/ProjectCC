using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class BattleCard : MonoBehaviour
{
    [SerializeField]
    public cardData m_cardData{ get; set; }

    bool isFront = false;
    public SO_CardsLibary m_cardsLibrary;
    private SpriteRenderer m_spRenderer;
    public SpriteRenderer m_textSPRenderer;
    public Sprite m_cardBackView;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetRequiredSPRenderer()
    {
        SpriteRenderer[] sprs = gameObject.GetComponentsInChildren<SpriteRenderer>();


        if(m_spRenderer == null && sprs[0] != null)
            m_spRenderer = sprs[0];

        if (m_textSPRenderer == null && sprs[1] != null)
            m_textSPRenderer = sprs[1];
        
    }

    public void ChangeCardView(bool front)
    {
        isFront = front;

        if (front)
        {
            m_spRenderer.sprite = m_cardData.cardFrontView;
            m_textSPRenderer.enabled = true;
        }
        else
        {
            m_spRenderer.sprite = m_cardBackView;
            m_textSPRenderer.enabled = false;
        }
            
    }

    public void SetCardData(SO_CardsLibary library,int cardIndex, bool frontView)
    {
        GetRequiredSPRenderer();
        if (library != null)
        {
            m_cardsLibrary = library;
            m_cardData = m_cardsLibrary.cards[cardIndex];
            m_cardBackView = m_cardsLibrary.cardBackView;
            m_textSPRenderer.sprite = m_cardsLibrary.numberFont[m_cardData.atk_power-1];
           ChangeCardView(frontView);
        }
    }
}
