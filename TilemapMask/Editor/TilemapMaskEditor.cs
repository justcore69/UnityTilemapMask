using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TilemapMask))]
public class TilemapMaskEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        TilemapMask tilemapMask = (TilemapMask)target;

        if (GUILayout.Button("Generate Mask"))
        {
            tilemapMask.GenerateMask();
        }
    }
}
