# OpenvrDataGetter

A plugin for [Neos VR](https://neos.com/) that allows you get Gyro and Accel data from openvr devices.

all nodes under Add-Ons/OpenvrDataGetter
## adds
- ImuReader
	- `DevicePath` string input
	- `OnOpened` impulse
	- `isOpened` bool output
	- `OnFail` impulse
	- `FailReason` ErrorCode output
	- `OnData` impulse
	- `fSampleTime` double output
	- `vAccel` double3 output
	- `vGyro` double3 output
	- `unOffScaleFlags` Imu_OffScaleFlags output

- DeviceProperty[Bool, Float, Float3, Int, Matrix3x4, String, Ulong]
	- `Prop` [type]DeviceProperty input
	- `Index` uint input
	- [type] output

- IsIndexConnected
	- `Index` uint input
	- EDeviceActivityLevel output

- ActivityLevelOfIndex
	- `Index` uint input
	- bool output

- ClassOfIndex
	- `Index` uint input
	- ETrackedDeviceClass output

- RoleOfIndex
	- `Index` uint input
	- ETrackedControllerRole output

- IndexOfRole
	- `Role` ETrackedControllerRole input
	- output uint

## Installation
1. Place [OpenvrDataGetter.dll](https://github.com/eia485/NeosOpenvrDataGetter/releases/latest/download/OpenvrDataGetter.dll) into your `Libraries` folder. This folder should be at `C:\Program Files (x86)\Steam\steamapps\common\NeosVR\Libraries` for a default install.
1. Ether use the neos launcher and select OpenvrDataGetter.dll from the list or add `-LoadAssembly Libraries\OpenvrDataGetter.dll` to your launch arguments