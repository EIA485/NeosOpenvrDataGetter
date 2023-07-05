using BaseX;
using Valve.VR;

namespace OpenvrDataGetter
{
    internal static class Converter
    {
        public static double3 HmdVector3ToDobble3(HmdVector3d_t vec) //they are both the same struct. i should do some trickery with mem so i dont need to aloc a new double3
        {
            return new(vec.v0, vec.v1, vec.v2);
        }

        public static float4x4 HmdMatrix34ToFloat4x4(HmdMatrix34_t matrix)
        {
            return new(matrix.m0, matrix.m1, matrix.m2, matrix.m3,
                        matrix.m4, matrix.m5, matrix.m6, matrix.m7,
                        matrix.m8, matrix.m9, matrix.m10, matrix.m11,
                        0, 0, 0, 0);
        }
    }
}
