using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROM : MonoBehaviour {

    public static T read<T>(string key)
    {
        if(PlayerPrefs.HasKey(key))
        {
            return JsonUtility.FromJson<T>( PlayerPrefs.GetString( key ) );
        }
        return default(T);
    }
    public static bool contains(string key)
    {
        return PlayerPrefs.HasKey( key );
    }
    public static void write<T>(string key, T obj)
    {
        PlayerPrefs.SetString( key, JsonUtility.ToJson( obj ) );
    }

}
