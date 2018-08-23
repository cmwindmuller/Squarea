using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using GoogleARCore;
using C33.XR;

namespace C33.Squarea
{
    public class Squarea : MonoBehaviour
    {
        protected static Squarea main_;
        public static Squarea main { get { return main_; } }

        const string START_UX = "Launch";

        public Anchor mainAnchor;
        public Text areaText;
        public Marker markerPrefab;
        public Material areaMaterial;

        public static bool isAnchored;
        bool showAR;
        WebCamTexture wct;

        Stack<GeoData> rooms;
        GeoData roomNow;

        SaveFile sf_access;

        private void Awake()
        {
            showAR = isAnchored = false;
            mainAnchor = null;
            if( !main_ )
            {
                main_ = this;
            }
            Units.isMetric = false;
            rooms = new Stack<GeoData>();
        }
        
        public void startApp()
        {
            //loading is completely complete
        }

        public void setFloor()
        {
            if(showAR)
            {
                mainAnchor = ARTouch.ARScreencast( true )?.transform.parent.GetComponent<Anchor>();
                if(mainAnchor != null)
                {
                    ARTouch.main.floor = new Plane( mainAnchor.transform.up, mainAnchor.transform.position );
                    isAnchored = true;
                    showAR = false;
                }
            }
            else
            {
                showAR = true;
            }
            ARControl.visualizeAR( showAR );
        }
        public bool startRoom()
        {
            if( !isAnchored ) return false;

            ARControl.visualizeAR( showAR = false );
            roomNow = new GameObject("Room"+(rooms.Count+1).ToString()).AddComponent<GeoData>();
            roomNow.setup( mainAnchor, markerPrefab );
            rooms.Push( roomNow );
            areaText.text = "";

            return true;
        }
        public void endRoom()
        {
            clearRooms();
        }
        public void addMarker()
        {
            if( rooms.Count == 0 )
                if( !startRoom() )
                    return;
            Vector3 tap = ARTouch.Floorcast();
            if( tap.sqrMagnitude == 0 )
                return;
            roomNow.addMarker( tap );
            areaText.text = roomNow.evalArea();
        }
        public void undoMarker()
        {
            if( rooms.Count == 0 ) return;
            areaText.text = rooms.Peek().undoMarker();
        }
        public void swapUnits()
        {
            Units.isMetric = !Units.isMetric;
            areaText.text = rooms.Peek().reEval();
        }
        public void clearRooms()
        {
            while(rooms.Count > 0)
            {
                Destroy( rooms.Pop().gameObject );
            }
        }
    }
}