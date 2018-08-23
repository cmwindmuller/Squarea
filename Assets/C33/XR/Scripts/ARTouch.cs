using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

namespace C33.XR
{
    public class ARTouch : MonoBehaviour
    {
        private static ARTouch main_;
        public static ARTouch main { get { return main_; } }

        public Plane floor;

        public RectTransform aim;
        public GameObject defaultReact;

        bool isDown,isUp,isHeld;

        private void Awake()
        {
            if( !main_ )
                main_ = this;
        }
        private void Start()
        {
            aim.GetComponent<Image>().raycastTarget = false;
        }
        private void Update()
        {
            ProcessTouches();
        }

        public static Vector3 Reticle()
        {
            return main.aim.GetComponent<Graphic>().rectTransform.position;
        }

        public static Vector3 Floorcast()
        {
            Ray camRay = ARControl.main.FirstPersonCamera.ScreenPointToRay( Reticle() );
            float distance = -1;
            Vector3 hit = Vector3.zero;
            if( ARTouch.main.floor.Raycast( camRay, out distance ) )
            {
                hit = camRay.GetPoint( distance );
            }
            return hit;
        }

        public GameObject ARCast( GameObject spawn,bool shallAnchor=false )
        {
            return ARScreencast( ARTouch.Reticle(), spawn, shallAnchor );
        }
        public static GameObject ARScreencast(bool shallAnchor = false )
        {
            return main.ARCast( main.defaultReact, shallAnchor );
        }
        public static GameObject ARScreencast( GameObject spawn, bool shallAnchor = false )
        {
            return main.ARCast( spawn, shallAnchor );
        }
        public static GameObject ARScreencast(Vector2 screenPoint, GameObject reactPrefab,bool shallAnchor=false )
        {
            TrackableHit hit;
            Camera camera = ARControl.main.FirstPersonCamera;
            if( !camera ) camera = ARControl.main.FirstPersonCamera = Camera.main;
            if( ARControl.trackCast( screenPoint, camera.transform, out hit ) )
            {
                //TODO: not Andy, duh
                GameObject go = Instantiate(reactPrefab);
                go.transform.position = hit.Pose.position;
                if(shallAnchor)
                {
                    Anchor anchor = hit.Trackable.CreateAnchor( hit.Pose );
                    go.transform.SetParent( anchor.transform, true );
                }

                return go;
            }
            return null;
        }
        void ProcessTouches()
        {
            Touch touch, t;
            isDown = isUp = isHeld = false;
            for( int i = 0; i < Input.touchCount; i++ )
            {
                t = Input.GetTouch( i );
                switch( t.phase )
                {
                    case TouchPhase.Began:
                        isDown = isHeld = true;
                        touch = t;
                        return;
                    case TouchPhase.Stationary:
                    case TouchPhase.Moved:
                        isHeld = true;
                        touch = t;
                        break;
                    case TouchPhase.Canceled:
                    case TouchPhase.Ended:
                        break;
                }
            }
        }
        public static implicit operator bool(ARTouch me)
        {
            return me != null;
        }
    }
}