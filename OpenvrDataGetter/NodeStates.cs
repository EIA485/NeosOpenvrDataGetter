using BaseX;
using FrooxEngine;
using FrooxEngine.LogiX;
using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

namespace OpenvrDataGetter
{
    [Category(new string[] { "LogiX/Add-Ons/OpenvrDataGetter" })]
    public class NodeStates : LogixNode
    {
        public readonly Input<int> Index;
        public readonly Output<ulong> uniqueID;
        public readonly Output<XRNode> nodeType;
        public readonly Output<bool> tracked;
        public readonly Output<float3> position;
        public readonly Output<floatQ> rotation;
        public readonly Output<float3> velocity;
        public readonly Output<float3> angularVelocity;
        public readonly Output<float3> acceleration;
        public readonly Output<float3> angularAcceleration;
        public readonly Output<int> Length;
        protected override void OnCommonUpdate()
        {
            var index = Index.Evaluate(-1);
            if (index < 0)
            {
                ResetOutputs();
                return;
            }
            List<XRNodeState> list = new List<XRNodeState>();
            InputTracking.GetNodeStates(list);
            Length.Value = list.Count;
            if (Length.Value <= index) 
            {
                ResetOutputs();
                return;
            };
            XRNodeState node = list[index];
            uniqueID.Value = node.uniqueID;
            nodeType.Value = node.nodeType;
            tracked.Value = node.tracked;
            Vector3 vec3;
            if (node.TryGetPosition(out vec3)) position.Value = Converter.UnityVec3ToFLoat3(vec3); else position.Value = float3.Zero;
            Quaternion quat;
            if (node.TryGetRotation(out quat)) rotation.Value = Converter.UnityQuatToFloatQ(quat); else rotation.Value = default(floatQ);
            if (node.TryGetVelocity(out vec3)) velocity.Value = Converter.UnityVec3ToFLoat3(vec3); else velocity.Value = float3.Zero;
            if (node.TryGetAngularVelocity(out vec3)) angularVelocity.Value = Converter.UnityVec3ToFLoat3(vec3); else angularVelocity.Value = float3.Zero;
            if (node.TryGetAcceleration(out vec3)) acceleration.Value = Converter.UnityVec3ToFLoat3(vec3); else acceleration.Value = float3.Zero;
            if (node.TryGetAngularAcceleration(out vec3)) angularAcceleration.Value = Converter.UnityVec3ToFLoat3(vec3); else angularAcceleration.Value = float3.Zero;
        }
        void ResetOutputs()
        {
            uniqueID.Value = 0;
            nodeType.Value = (XRNode)(-1);
            tracked.Value =  false;
            position.Value = float3.Zero;
            rotation.Value = default(floatQ);
            velocity.Value = float3.Zero;
            angularVelocity.Value = float3.Zero;
            acceleration.Value = float3.Zero;
            angularAcceleration.Value = float3.Zero;
        }
    }
}
