using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.Solid
{
    public class LookAt : MonoBehaviour
    {

        public bool late=true,reverse=false;
        public Transform target;
        Transform target_;

        public void Update()
        {
            if( !late ) Look();
        }
        public void LateUpdate()
        {
            if( late ) Look();
        }

        void Look()
        {
            if( target && !target_) target_ = target;
            else target = target_ = Camera.main.transform;
            transform.LookAt( target_ );
        }

    }
}