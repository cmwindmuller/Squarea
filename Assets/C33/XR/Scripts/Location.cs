using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.XR
{
    public class Location : MonoBehaviour
    {
        public void locateSelf()
        {
            Input.location.Start();
            LocationInfo ls = Input.location.lastData;
            Input.location.Stop();
        }
    }
}