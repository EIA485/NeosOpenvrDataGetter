using Valve.VR;

namespace OpenvrDataGetter
{
    public class DevicePropertyArrayBool : DevicePropertyArray<bool, BoolArrayDeviceProperty>
    {
    }

    public enum BoolArrayDeviceProperty
    {
        Prop_DisplayMCImageData = ETrackedDeviceProperty.Prop_DisplayMCImageData_Binary,
        Prop_DisplayHiddenArea_Start = ETrackedDeviceProperty.Prop_DisplayHiddenArea_Binary_Start,
        Prop_DisplayHiddenArea_End = ETrackedDeviceProperty.Prop_DisplayHiddenArea_Binary_End,
    }
}
