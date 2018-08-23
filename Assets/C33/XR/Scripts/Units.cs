using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units {

    public const float METER_2_CM = 100, METER_2_FOOT = 3.28084f, METER_2_INCH = 39.3701f;
    public const float FOOT_2_INCH = 12, FOOT_2_METER = 0.3048f;
    public const float DECIMAL = 10^0,SQMETER_2_SQFOOT = 10.7639111056f;

    public static bool isMetric
    {
        get { return isMetric_; }
        set
        {
            isMetric_ = value;
            if( isMetric )
            {
                alphaFactor = 1;
                betaFactor = METER_2_CM;
                sqUnit = "m";
            }
            else
            {
                alphaFactor = METER_2_FOOT;
                betaFactor = FOOT_2_INCH;
                sqUnit = "ft";
            }
        }
    }
    protected static bool isMetric_=false;
    public static float alphaFactor,betaFactor;
    public static string alphaUnit { get { return isMetric ? "." : "'"; } }
    public static string betaUnit { get { return isMetric ? "m" : "\""; } }
    public static string sqUnit;

    const char sqrd = '\u00B2';
    public static string convert(float uunit,bool isArea=false)
    {
        float aUnit,bUnit,scaledUnits;
        string s = "";
        scaledUnits = uunit * alphaFactor * ( !isArea ? 1 : alphaFactor );
        if( !isArea )
        {
            aUnit = Mathf.Floor( scaledUnits );
            bUnit = Mathf.Round( ( scaledUnits - aUnit ) * betaFactor );
            s = aUnit.ToString() + alphaUnit + bUnit.ToString() + betaUnit;
        }
        else
            s = ( Mathf.Round( scaledUnits * 100 ) / 100f ).ToString() + sqUnit + sqrd;
        return s;
    }

}
