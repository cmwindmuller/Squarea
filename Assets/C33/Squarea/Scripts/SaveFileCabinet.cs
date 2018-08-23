using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.Squarea
{
    [System.Serializable]
    public class SaveFile
    {
        public GeoData[] rooms;
    }

    public class SaveFileCabinet : Saveable<SaveFile>
    {
        const string SAVE_KEY = "squarea_tableau";

        public void SaveIt( SaveFile sf )
        {
            //sf_backup = LoadIt();
            PlayerPrefs.SetString( SAVE_KEY, toJson<SaveFile>( sf ) );
        }
        public SaveFile LoadIt()
        {
            SaveFile sf = new SaveFile();
            if( PlayerPrefs.HasKey( SAVE_KEY ) )
            {
                //sf_backup = sf_access;
                sf = fromJson( PlayerPrefs.GetString( SAVE_KEY ) );
            }
            return sf;
        }
        public SaveFile fromJson( string json )
        {
            return JsonUtility.FromJson<SaveFile>( json );
        }

        public string toJson<T>( T obj )
        {
            return JsonUtility.ToJson( obj as Object );
        }
    }

}