using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace C33.Squarea
{
    public class Marker : MonoBehaviour
    {

        const float MIN_DIST = 0.75f;

        public float distance;
        public LineRenderer lineRender;
        public MeshRenderer meshRender;
        public GameObject canvas;
        public Text text;
        public Color color;
        bool shouldRender;

        private void Awake()
        {
            if( !meshRender )
                meshRender = GetComponentInChildren<MeshRenderer>();
            if(!lineRender)
                lineRender = GetComponentInChildren<LineRenderer>();
            if( !text )
                text = GetComponentInChildren<Text>();
            color = Random.ColorHSV( 0, 1, 0.72f, 1, 0.9f, 1 );
        }

        const string COLOR_NAME = "_Color";
        public void setup(Vector3 selfPos,Marker lastMark)
        {
            transform.position = selfPos;
            lineRender.SetPosition( 0, selfPos );
            lineRender.SetPosition( 1, selfPos );
            lineRender.endColor = lineRender.startColor = color;
            meshRender?.material.SetColor( COLOR_NAME, color );
            if(lastMark != null)
            {
                canvas.transform.position = Vector3.Lerp( lastMark.transform.position, selfPos, 0.5f ) + Vector3.up * 0.4f;
                lineRender.startColor = lastMark.color;
                lineRender.SetPosition( 0, lastMark.transform.position );
                setDistance( Vector3.Distance( lastMark.transform.position, selfPos ) );
            }
            else
            {
                canvas.SetActive( false );
                lineRender.enabled = false;
            }
        }
        public void setDistance()
        {
            setDistance( distance );
        }
        public void setDistance( float uunits )
        {
            distance = uunits;
            text.text = Units.convert(uunits);
        }

        private void LateUpdate()
        {
            bool inVisibleZone = Vector3.Distance(text.transform.position, Camera.main.transform.position) >= MIN_DIST;
            if( !shouldRender && inVisibleZone )
            {
                text.CrossFadeAlpha( 1, 0.3f, true );
            }
            else if( shouldRender && !inVisibleZone )
            {
                text.CrossFadeAlpha( 0, 0.3f, true );
            }
            shouldRender = inVisibleZone;
            canvas.transform.LookAt( Camera.main.transform );
        }
    }
}