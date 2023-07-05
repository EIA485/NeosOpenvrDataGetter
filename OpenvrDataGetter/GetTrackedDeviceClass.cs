using Valve.VR;
namespace OpenvrDataGetter
{
    class GetTrackedDeviceClass : TrackedDeviceData<ETrackedDeviceClass>
    {
        public override ETrackedDeviceClass Content => OpenVR.System.GetTrackedDeviceClass(Index.Evaluate());
    }
}
