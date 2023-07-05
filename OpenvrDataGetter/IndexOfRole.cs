using FrooxEngine;
using FrooxEngine.LogiX;
using Valve.VR;

namespace OpenvrDataGetter
{
    [Category(new string[] { "LogiX/Add-Ons/OpenvrDataGetter" })]
    public class IndexOfRole : LogixOperator<uint>
    {
        public readonly Input<ETrackedControllerRole> Role;
        public override uint Content => OpenVR.System.GetTrackedDeviceIndexForControllerRole(Role.Evaluate());
    }
}
