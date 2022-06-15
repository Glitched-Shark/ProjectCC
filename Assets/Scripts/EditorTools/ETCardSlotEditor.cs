using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ETCardSlot))]
[CanEditMultipleObjects]
public class ETCardSlotEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ETCardSlot myscript = (ETCardSlot)target; //cast the target as ETCardSlot

        if (GUILayout.Button("Generate Slot"))
        {
            myscript.GenerateSlotTransform();
        }

        if (GUILayout.Button("Clear Slot"))
        {
            myscript.ClearSlots();
        }
    }
}
