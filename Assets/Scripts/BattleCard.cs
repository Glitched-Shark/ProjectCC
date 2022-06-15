using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class BattleCard : MonoBehaviour
{
    //[SerializeField]
    public cardData m_cardData{ get; set; }

    private SpriteRenderer m_spRenderer;
    public SpriteRenderer m_textSPRenderer;
    

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

    public void SetCardData(cardData cData, Sprite indexSprite)
    {
        GetRequiredSPRenderer();
        m_cardData = cData;
        m_spRenderer.sprite = m_cardData.cardSprite;
        m_textSPRenderer.sprite = indexSprite;
        
    }
}
