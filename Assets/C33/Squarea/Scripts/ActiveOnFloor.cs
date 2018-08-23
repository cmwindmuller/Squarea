using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace C33.Squarea
{

    public class ActiveOnFloor : MonoBehaviour {

        bool isFloored;

        void Update() {
            if( !isFloored && Squarea.isAnchored)
            {
                isFloored = true;
                GetComponent<Button>().interactable = true;
            }
            else if(isFloored && !Squarea.isAnchored)
            {
                isFloored = false;
                GetComponent<Button>().interactable = false;
            }
        }
    }
}