using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : Player
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_phase == PlayerPhase.Draw)
        {
            DrawCard(drawAmtEachTurn, true);
            m_phase = PlayerPhase.Play;
        }
        else if (m_phase == PlayerPhase.Play)
        {
            /*if (Input.touchCount > 0)
            {
                Debug.Log("Clicking");
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    
                    RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
                    if (hitInfo.collider != null)
                    {
                        Debug.Log("Target Position" + hitInfo.transform.position);
                    }
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    
                    Debug.Log("I am moving");
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("I am done");
                }
            }*/
        }
    }

    public override void InitPlayerProperties()
    {
        handStartPosition = new Vector3(0.0f, -3.8f, 2.0f);
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
        DrawCard(startingHandCount, true);
    }
}
