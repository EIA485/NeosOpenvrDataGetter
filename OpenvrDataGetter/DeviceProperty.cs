using FrooxEngine.LogiX;

namespace OpenvrDataGetter
{
    public abstract class DeviceProperty<T, P> : TrackedDeviceData<T>
    {
        public readonly Input<P> Prop;
    }
}
