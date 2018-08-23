using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.Solid
{
    public class AnimationShelf : MonoBehaviour
    {
        const string OPEN="open",CLOSE="close";
        const float DURATION = 1.27f;

        public int index;
        int index_;

        public Animator[] shelf;

        public void OnValidate()
        {
            index = Mathf.Clamp( index, 0, shelf.Length - 1 );
            if(index != index_)
            {
                shelf[index_].gameObject.SetActive( false );
                shelf[index].gameObject.SetActive( true );
                index_ = index;
            }
        }

        public void openDrawer(int i )
        {
            i = Mathf.Clamp( i, 0, shelf.Length );
            Animator drawer = shelf[i];
            drawer.gameObject.SetActive( true );
            drawer.Play( OPEN );
            CanvasGroup cg = drawer.GetComponent<CanvasGroup>();
            if( cg ) cg.blocksRaycasts = cg.interactable = true;
        }
        public void closeDrawer( int i )
        {
            i = Mathf.Clamp( i, 0, shelf.Length );
            Animator drawer = shelf[i];
            drawer.Play( CLOSE );
            CanvasGroup cg = drawer.GetComponent<CanvasGroup>();
            if( cg ) cg.blocksRaycasts = cg.interactable = false;
        }
    }
}