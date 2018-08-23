using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using C33.Game;
using C33.Solid;

/// <summary>
/// @Author: C33
/// @Version: 0.5x
/// @Summary: Main hook for essential C33 setup/features
/// </summary>

namespace C33.XR
{
    public class Main : MonoBehaviour
    {
        const string MAIN_OBJ = "Main",SCENE_MAIN = "mainHook";
        const string LOG_PRE = "[C33] ";
        const float HARDWARE_CHECK_INTERVAL = 0.25f;
        protected static Main main_;    //main entry point, singleton get
        public static Main main {
            get {
                if( main_ )
                    return main_;
                Main.Log( "[C33] main 0: null Main, searching..." );
                main_ = GameObject.FindObjectOfType<Main>();
                if( main_ )
                    return main_;
                Main.Log( "[C33] main 1: no Main Component, fixing..." );
                GameObject m = GameObject.Find( MAIN_OBJ );
                if( m )
                {
                    main_ = m.AddComponent<Main>();
                    return main_;
                }
                return new GameObject( MAIN_OBJ ).AddComponent<Main>();
            }
        }
        protected int seed_;            //seed for sharing plays/bugs, linear distribution
        public static int seed { get { return main_ ? main_.seed_ : -1; } }
        protected float wyrd_;            //bonus 'fate'
        public static float wyrd { get { return main_ ? main_.wyrd_ : -1; } }

        public Hardware hardware;
        public Location location;
        public LineGradient busyLine;
        public GameObject busyBug;

        public bool debug=true;
        public bool isBooting,isRunning;
        
        public UnityEvent begin;

        private void Awake()
        {
            if( !main_ )
            {
                main_ = this;
                Main[] extras = GameObject.FindObjectsOfType<Main>();
                if( extras.Length > 1)
                {
                    Main.Log( LOG_PRE + "Error : [" + extras.Length + "] Main entry points!" );
                    foreach( Main m in extras )
                    {
                        if(m != this)m.enabled = false;
                    }
                }
            }
            else
            {
                StartCoroutine( "ListenForMain");
            }
        }
        IEnumerator ListenForMain()
        {
            while(main.isBooting || !main.isRunning)
                yield return new WaitForEndOfFrame();
            begin.AddListener( BootComplete );
            begin.Invoke();
        }

        private void Start()
        {
            if( this != main_ )
                return;
            if( Application.isPlaying )
                DontDestroyOnLoad( this.gameObject );
            BootCycle();
        }

        private void BootCycle(int aSeed=-1,int bWyrd=-1)
        {
            isRunning = false;
            isBooting = true;
            //busyLine = Instantiate( busyLine, transform, true );
            Busy( true );
            transform.parent = null;//topmost visibility
            Random.InitState( seed_ = aSeed > 0 ? aSeed : ( Mathf.Abs( ( int ) System.DateTime.Now.Ticks ) ) % 768 );
            wyrd_ = bWyrd > 0 ? bWyrd : Dice.RollNormal(3,6);
            Main.Log( "Hardware scan..." );
            StartCoroutine( "HardwareCycle" );
        }

        IEnumerator HardwareCycle()
        {
            if( !hardware ) hardware = gameObject.GetComponent<Hardware>();
            if( !hardware ) hardware = gameObject.AddComponent<Hardware>();
            while( !hardware.scanHardware() )
            {
                yield return new WaitForSeconds( HARDWARE_CHECK_INTERVAL );
                Main.Log( "scan...", true );
            }
            HardwareRespond();
            yield return null;
        }

        void HardwareRespond()
        {
            isRunning = true;
            Main.Log( "Hardware present, ready to proceed." );



            begin.AddListener( BootComplete );
            begin.Invoke();
        }
            /*StartCoroutine( "DeviceCycle" );
        }
        IEnumerator DeviceCycle()
        {
            isRunning = true;
            begin.ad
        }*/

        private void BootComplete()
        {
            if( this != main_ )
                Destroy( this.gameObject );
            isBooting = false;
        }
        public void loadAppScene(string scene)
        {
            if( !isRunning )
                return;
            if( hardware.isEdit )
            {
                Main.Log( "EditorMode: no scene loading...", true );
            }
            else
            {
                SceneManager.sceneLoaded += ReadySetGone;
                SceneManager.LoadSceneAsync( scene );
            }
        }
        private void ReadySetGone( Scene scene, LoadSceneMode mode )
        {
            Busy( false );
        }

        public static void Busy(bool isBusy)
        {
            try
            {
                main?.busyBug?.SetActive( isBusy );
            }catch{}
            //main.busyLine.gameObject.SetActive( isBusy );
        }

        public static void Log(string msg,bool urgent=false)
        {
            if( main.debug || urgent)
                Debug.Log( LOG_PRE + msg );
        }
        
    }
}