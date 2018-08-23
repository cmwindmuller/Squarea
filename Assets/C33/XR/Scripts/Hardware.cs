using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace C33.XR
{
    public enum Device { None, AR, VR, PC, Edit };
    [System.Serializable]
    public class DeviceInfo
    {
        public Device prefer,active;
        public DeviceInfo(Device prefer)
        {
            this.prefer = prefer;
        }
    }
    public class Hardware : MonoBehaviour
    {
        const Device DEFAULT_DEVICE = Device.AR;
        protected static Hardware main_;
        public static Hardware main { get { return main_; } }
        public bool isAR,isVR,isPC,isEdit;
        public bool isReady;
        public DeviceInfo deviceInfo;

        private void Awake()
        {
            deviceInfo = new DeviceInfo(DEFAULT_DEVICE);
            insureSingleton(this);
        }

        void insureSingleton(Hardware hdw)
        {
            if( !main_ )
                main_ = hdw;
        }

        public bool scanHardware(bool reset=true)
        {
            bool prepared = false;
            if( reset )
            {
                insureSingleton( this );
                isAR = isVR = isPC = isEdit = false;
            }
            //TODO: check if hardware is running, async needed
            ReadyCheck();
            var platform = Application.platform;
            switch( platform )
            {
                case RuntimePlatform.Android:
                    isAR = true;
                    deviceInfo.active = Device.AR;
                    break;
                case RuntimePlatform.WindowsPlayer:
                case RuntimePlatform.WebGLPlayer:
                    isPC = true;
                    deviceInfo.active = Device.PC;
                    break;
                case RuntimePlatform.WindowsEditor:
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.LinuxEditor:
                    isEdit = true;
                    deviceInfo.active = Device.Edit;
                    break;
                default:
                    break;
            }
            prepared = deviceInfo.active == deviceInfo.prefer;
            return ( prepared || isEdit );
        }

        public bool ReadyCheck()
        {
            //do something, here?
            return true;
        }
    }
}