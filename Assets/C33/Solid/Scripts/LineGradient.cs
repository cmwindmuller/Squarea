using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.Solid
{
    public class LineGradient : MonoBehaviour
    {

        public Gradient gradient;
        public LineRenderer line;
        public ParticleSystem particle;
        ParticleSystem.ColorOverLifetimeModule colorLifeMod;
        public float time,delta;
        public float length=0.5f,wrapTime=1;

        // Use this for initialization
        void Start()
        {
            if( !line )
                line = GetComponent<LineRenderer>();
            if( !particle )
                particle = GetComponentInChildren<ParticleSystem>();
            if( particle ) colorLifeMod = particle.colorOverLifetime;
        }

        private void Update()
        {
            time += Time.deltaTime * delta;
            drawLine();
        }

        float adjust( float t )
        {
            t = ( t % 1 ) * ( 1 + wrapTime );
            return t;
        }
        Color adjustHue( float t )
        {
            Color c;
            if( t < 1 )
            {
                t = Mathf.Clamp01( t );
                c = gradient.Evaluate( t );
            }
            else
            {
                c = Color.Lerp( gradient.Evaluate( 1 ), gradient.Evaluate( 0 ), ( t - 1 ) / wrapTime );
            }
            return c;
        }

        void drawLine()
        {
            float s,e;
            s = adjust( time );
            e = adjust( time + length );

            line.startColor = adjustHue( s );
            line.endColor = adjustHue( e );
            if( particle ) colorLifeMod.color = new ParticleSystem.MinMaxGradient( line.startColor, line.endColor );
        }
    }
}