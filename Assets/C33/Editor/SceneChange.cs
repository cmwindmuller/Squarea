using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Nito.Collections;

/// <summary>
/// @Author: C33
/// @Summary: Recall recently opened scenes, with shortcuts and menu items.
/// </summary>

namespace C33
{
    [InitializeOnLoad]
    public static class SceneChange
    {
        const int SCENE_COUNT = 16;
        public static int index;
        public static bool isUndo,isRedo;

        const string ROM_SCENE = "sc3n3_d3ck";
        public static Deque<string> sceneDeck;

        // constructor
        static SceneChange()
        {
            Debug.Log( "Scene Init" );
            isUndo = isRedo = false;
            index = -1;
            sceneDeck = new Deque<string>( SCENE_COUNT );
            if( ROM.contains( ROM_SCENE ) )
            {
                sceneDeck = ROM.read<Deque<string>>( ROM_SCENE );
                index = sceneDeck.Count - 1;
            }
            EditorSceneManager.sceneOpened +=
                 SceneOpenedCallback;
        }

        static void SceneOpenedCallback(
            Scene _scene,
            UnityEditor.SceneManagement.OpenSceneMode _mode )
        {
            if( isUndo )
            {
                index--;
                isUndo = false;
            }
            else if( isRedo )
            {
                index++;
                isRedo = false;
                ROM.write<Deque<string>>( ROM_SCENE, sceneDeck );
            }
            else
            {
                index++;
                int diff = sceneDeck.Count - index;
                if( diff > 0 )
                    sceneDeck.RemoveRange( index, sceneDeck.Count - index );
                sceneDeck.AddToBack( _scene.path );
                if( sceneDeck.Count > SCENE_COUNT )
                {
                    sceneDeck.RemoveFromFront();
                    index--;
                }
            }
        }

        [MenuItem("Tools/SC3N3/Last %g")]
        static void OpenLastScene()
        {
            int nextIndex = index - 1;
            if( nextIndex < 0 )
                return;
            isUndo = true;
            EditorSceneManager.OpenScene( sceneDeck[ nextIndex ] );
        }

        [MenuItem( "Tools/SC3N3/Next %h" )]
        static void OpenNextScene()
        {
            int nextIndex = index + 1;
            if( nextIndex >= sceneDeck.Count )
                return;
            isRedo = true;
            EditorSceneManager.OpenScene( sceneDeck[nextIndex] );
        }
    }
}