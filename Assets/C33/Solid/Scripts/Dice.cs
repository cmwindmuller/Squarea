using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.Game
{
    public class Dice
    {
        public static float Min( int count = 1, int sides = 6 )
        {
            return count;
        }
        public static float Max( int count = 1, int sides = 6 )
        {
            return count * sides;
        }
        public static float RollNormal( int count = 1, int sides = 6 )
        {
            return Mathf.InverseLerp( Min( count, sides ), Max( count, sides ), Roll( count, sides ) );
        }
        public static int Roll( int count = 1, int sides = 6 )
        {
            int totalPips = 0;
            sides = sides > 1 ? sides : 2;
            for( int i = 0; i < count; i++ )
            {
                totalPips += Random.Range( 1, sides + 1 );
            }
            return totalPips;
        }
    }
}