using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace C33.Solid
{
    public class RayTracy : MonoBehaviour
    {
        public string resultName;
        float alpha_ = 0;
        LineRenderer line_;
        
        private void Start()
        {
            line_ = gameObject.AddComponent<LineRenderer>();
            InvokeRepeating( "Fire", 2.3f, 1 );
        }

        private void LateUpdate()
        {
            if(alpha_ > 0)
            {
                alpha_ = Mathf.Clamp01( alpha_ - Time.deltaTime );
            }
        }

        void Fire()
        {
            Ray ray_ = new Ray(transform.position,transform.forward);
            RaycastHit hitInfo;
            if( Physics.Raycast( ray_, out hitInfo ) )
            {
                resultName = hitInfo.collider.gameObject.name;
                alpha_ = 1;
                line_.SetPosition(0, ray_.origin);
                line_.SetPosition(1, hitInfo.point);
            }
        }
    }
}