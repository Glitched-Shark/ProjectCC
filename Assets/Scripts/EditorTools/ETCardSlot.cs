using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETCardSlot : MonoBehaviour
{
    public GameObject cardSlotPrefab;
    public int column;
    public Vector3 slotStartingPos;
    public float xOffset;
    public float yOffset;

    public List<Transform> playerSlotTransform = new List<Transform>();
    public List<Transform> enemySlotTransform = new List<Transform>();

    public void GenerateSlotTransform()
    {
        ClearSlots();
        InstantiateSlots(column, enemySlotTransform);
        InstantiateSlots(column, playerSlotTransform);
        AdjustSlotTransform();
    }

    public void ClearSlots()
    {
        DeleteTransform(enemySlotTransform);
        DeleteTransform(playerSlotTransform);
    }

    void InstantiateSlots(int amount, List<Transform> tList)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject go = Instantiate(cardSlotPrefab, Vector3.zero, Quaternion.identity, this.gameObject.transform);
            //GameObject go = Instantiate(cardSlotPrefab, Vector3.zero, Quaternion.identity);
            if (go != null)
            {
                go.transform.localPosition =new Vector3(0.0f, 0.0f, 0.0f);
                tList.Add(go.transform);
            }
        }
    }

    void DeleteTransform(List<Transform> tList)
    {
        if (tList.Count > 0)
        {
            for (int i = 0; i < tList.Count; i++)
            {
                if(tList[i].gameObject != null)
                    DestroyImmediate(tList[i].gameObject);
            }
        }
        tList.Clear();
    }

    void AdjustSlotTransform()
    {
        Vector3 enemySlotPos = slotStartingPos;
        enemySlotPos.y += yOffset;
        enemySlotTransform[0].transform.localPosition = enemySlotPos;

        Vector3 playerSlotPos = slotStartingPos;
        playerSlotPos.y -= yOffset;
        playerSlotTransform[0].transform.localPosition = playerSlotPos;

        for (int i = 1; i < enemySlotTransform.Count; i++)
        {
            enemySlotPos.x += xOffset;
            enemySlotTransform[i].transform.localPosition = enemySlotPos;
        }

        for (int i = 1; i < playerSlotTransform.Count; i++)
        {
            playerSlotPos.x += xOffset;
            playerSlotTransform[i].transform.localPosition = playerSlotPos;
        }
    }
}
