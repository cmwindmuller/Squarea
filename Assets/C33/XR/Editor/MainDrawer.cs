using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace C33.XR
{
    [CustomEditor( typeof( Main ) )]
    public class MainDrawer : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUI.BeginDisabledGroup( true );
            EditorGUILayout.IntField( "Seed:", Main.seed );
            EditorGUILayout.FloatField( "Wyrd:", Main.wyrd );
            EditorGUI.EndDisabledGroup();
            base.OnInspectorGUI();
        }
    }
}