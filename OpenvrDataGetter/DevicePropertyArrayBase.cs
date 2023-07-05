using FrooxEngine.LogiX;
using Valve.VR;
using System;
using System.Runtime.InteropServices;

namespace OpenvrDataGetter
{
    public abstract class DevicePropertyArrayBase<T, P, R> : DeviceProperty<R, P> where T : unmanaged where P : Enum
    {
        public readonly Input<long> ArrIndex;
        protected P DefaultValue = (P)Enum.GetValues(typeof(P)).GetValue(0);
        int structSize = Marshal.SizeOf<T>();
        protected virtual R Caster(T apiVal) => (R)(object)apiVal;
        public override R Content
        {
            get
            {
                var arrindex = ArrIndex.Evaluate();
                if (arrindex < 0) return default(R);
                var length = arrindex + 1;
                var devindex = Index.Evaluate();
                var prop = (ETrackedDeviceProperty)(object)Prop.Evaluate(DefaultValue);
                ETrackedPropertyError error = ETrackedPropertyError.TrackedProp_Success;

                var arr = new T[length];
                unsafe
                {
                    fixed (T* ptr = arr)
                    {
                        OpenVR.System.GetArrayTrackedDeviceProperty(devindex, prop, 0, (IntPtr)ptr, (uint)(length * structSize), ref error);
                    }
                }
                return Caster(arr[arrindex]);
            }
        }
    }
}
