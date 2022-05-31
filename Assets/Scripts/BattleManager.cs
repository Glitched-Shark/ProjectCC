using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct boardData
{
    private BattleCard card { get; set;}
    private Vector3 boardPos { get; set;}
}

public class BattleManager : MonoBehaviour
{
    const int cardBoardSize = 5; 
    public Player1 p1;
    public Enemy1 p2;

    //board var
    public Vector3 p1InitialPlayedCardPos;
    public float boardYoffset;
    public float boardXoffset;


    public boardData[] p1Board = new boardData[cardBoardSize];
    public boardData[] p2Board = new boardData[cardBoardSize];

    // Start is called before the first frame update
    void Start()
    {
        p1.Init();
        p2.Init();

        if (isP1StartFirst())
        {
            p1.m_phase = PlayerPhase.Draw;
            p2.m_phase = PlayerPhase.Idle;
        }
        else 
        {
            p1.m_phase = PlayerPhase.Idle;
            p2.m_phase = PlayerPhase.Draw;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isP1StartFirst()
    {
        int rand = Random.Range(0, 1);
        return (rand == 0);
    }

    public void PassTurn(bool passToEnemy)
    {
        if (passToEnemy)
        {
            p2.m_phase = PlayerPhase.Draw;
        }
        else
        {
            p1.m_phase = PlayerPhase.Draw;
        }
    }
}
