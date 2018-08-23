using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace C33.XR
{
    public class UX : MonoBehaviour
    {
        const string CANVAS_NAME = "Canvas";
        const string DEFAULT_VIEW = "Start";
        protected static UX main_;
        public static UX main {
            get {
                if(main_ == null)
                {
                    Canvas canvas = GameObject.FindObjectOfType<Canvas>();
                    if( !canvas )
                        canvas = new GameObject( CANVAS_NAME ).AddComponent<Canvas>();
                    main_ = canvas.GetComponent<UX>();
                    if( !main_ )
                        main_ = canvas.gameObject.AddComponent<UX>();
                }
                return main_;
            }
        }
        public static bool frozen;
        private bool disabled;

        private string nowViewName,nextViewName,lastViewName;
        public UXView[] viewList;
        private Dictionary<string,UXView> viewLookup;
        private Stack<UXView> viewStack;
        GraphicRaycaster inputRay;

        private void Awake()
        {
            if(!main_)
            {
                main_ = this;
                viewStack = new Stack<UXView>();
                viewLookup = new Dictionary<string, UXView>( viewList.Length );
                foreach( UXView uxv in viewList )
                {
                    viewLookup.Add( uxv.name, uxv );
                    uxv.setup();
                }
                inputRay = GetComponent<GraphicRaycaster>();
            }
            else
            {
                //TODO: merge viewlist and update master? or put UX on a stack, echoing UXV??
            }
        }
        private void Start()
        {
            disabled = !enabled;
            if(disabled)
            {
                hideAllViews();
                toggleInteract();
            }
        }
        private void Update(){}

        void hideAllViews()
        {
            foreach(UXView uxv in viewList)
            {
                uxv.SetActive( false );
            }
        }
        void toggleInteract(bool interactable=false)
        {
            if( viewStack.Count > 0 )
            {
                Selectable[] selects = viewStack.Peek().rect.GetComponentsInChildren<Selectable>();
                foreach( Selectable s in selects )
                {
                    s.interactable = interactable;
                }
            }
        }
        public void openView(int index=0)
        {
            if( disabled ) return;
            openView( viewList[index]?.name );
        }
        public void openView(string name)
        {
            if( disabled ) return;
            if( name == nowViewName )
                return;
            if( !viewLookup.ContainsKey( name ) || viewStack == null || viewLookup == null)
                return;
            inputRay.enabled = false;
            nextViewName = name;
            nextView = viewLookup[nextViewName];
            lastViewName = nowViewName;
            lastView = nowView;
            nowViewName = null;
            nowView = null;
            viewStack.Push( nextView );
            StartCoroutine( "transitionView" );
        }
        UXView nowView,nextView,lastView;
        IEnumerator transitionView()
        {
            //toggleInteract(); 
            
            Vector3 thisExit = nextView.exit;
            thisExit.z -= 1;
            float duration = nextView.time;
            float diagonal = new Vector2(Screen.width,Screen.height).magnitude * 0.5f;
            Vector2 moveExit = new Vector2( thisExit.x, thisExit.y ) * - diagonal;
            nextView.reset(true);
            Vector2 a,b;
            if( lastView?.rect )
            {
                a = lastView.rect.anchoredPosition + moveExit;
                LeanTween.move( lastView.rect.gameObject, a, duration );//, a, duration ).setEase( LeanTweenType.easeInOutCubic );
            }
            b = nextView.rect.anchoredPosition;
            nextView.rect.anchoredPosition -= moveExit;
            LeanTween.moveLocal( nextView.rect.gameObject, b, duration );//move( nextView.rect, b, duration ).setEase( LeanTweenType.easeInOutCubic );
            yield return new WaitForSeconds( duration );
            lastView?.reset( false );
            nextView.reset( true );
            nowView = nextView;
            nowViewName = nextViewName;
            nextViewName = "";
            frozen = false;
            inputRay.enabled = true;
            //toggleInteract( true );
            yield return null;
        }
        public void closeView()
        {
            if( disabled ) return;
            if( viewStack.Count < 2 )
                return;
            frozen = true;
            nextViewName = lastViewName;
            nextView = lastView;
            lastViewName = nowViewName;
            lastView = nowView;
            nowViewName = null;
            nowView = null;
            viewStack.Pop();
            StartCoroutine( "transitionView" );
        }
    }
}
