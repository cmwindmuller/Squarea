using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.XR
{
    [System.Serializable]
    public class UXView
    {
        public string name;
        public RectTransform rect;
        public Vector3 exit=Vector3.forward;
        public float time=1;
        Vector3 position;
        Vector3 scale;
        CanvasRenderer[] renders;
        public void setup()
        {
            position = rect.position;
            scale = rect.localScale;
            renders = rect.GetComponentsInChildren<CanvasRenderer>();
            if( exit.z <= 0 )
                exit.z = 1;
            SetActive( false );
        }
        public void SetActive( bool active )
        {
            rect.gameObject.SetActive( active );
        }
        public void reset(bool active=true)
        {
            rect.position = position;
            rect.localScale = scale;
            rect.gameObject.SetActive( active );
        }
        public void traverse( float alpha, Vector3 slide, bool isEntering = true )
        {
            float diagonal = new Vector2(Screen.width,Screen.height).magnitude * 0.5f;
            float d = diagonal;
            Vector3 startPos,endPos;
            Vector3 startSca,endSca;
            endPos = startPos = position;
            endSca = startSca = scale;
            if( isEntering )
            {
                startPos = position + new Vector3( slide.x, slide.y ) * d;
                startSca = scale * slide.z;
            }
            else
            {
                endPos = position - new Vector3( slide.x, slide.y ) * d;
                endSca = scale / ( slide.z > 0 ? slide.z : 1 );
            }
            foreach(CanvasRenderer cr in renders )
            {
                cr.SetAlpha( Mathf.Clamp01( isEntering ? alpha : 1 - alpha ) );
            }
            rect.position =   Vector3.Lerp( startPos, endPos,  alpha );
            rect.localScale = Vector3.Lerp( startSca, endSca,  alpha );
        }
    }
}