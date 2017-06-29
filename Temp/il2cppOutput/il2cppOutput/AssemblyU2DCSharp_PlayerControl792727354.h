#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector32243707580.h"

// UnityEngine.Camera
struct Camera_t189460977;
// PlayerControl/PlayerControlDelegate
struct PlayerControlDelegate_t3362226240;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayerControl
struct  PlayerControl_t792727354  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Camera PlayerControl::camera
	Camera_t189460977 * ___camera_2;
	// System.Single PlayerControl::mouseDownTime
	float ___mouseDownTime_3;
	// UnityEngine.Vector3 PlayerControl::lastTouchPosition
	Vector3_t2243707580  ___lastTouchPosition_4;
	// System.Boolean PlayerControl::wasLastFrameZooming
	bool ___wasLastFrameZooming_5;
	// System.Single PlayerControl::lastZoomDistance
	float ___lastZoomDistance_6;
	// PlayerControl/PlayerControlDelegate PlayerControl::longTouchEvent
	PlayerControlDelegate_t3362226240 * ___longTouchEvent_7;
	// PlayerControl/PlayerControlDelegate PlayerControl::touchEndEvent
	PlayerControlDelegate_t3362226240 * ___touchEndEvent_8;
	// PlayerControl/PlayerControlDelegate PlayerControl::touchBeginEvent
	PlayerControlDelegate_t3362226240 * ___touchBeginEvent_9;
	// PlayerControl/PlayerControlDelegate PlayerControl::touchMovedEvent
	PlayerControlDelegate_t3362226240 * ___touchMovedEvent_10;
	// PlayerControl/PlayerControlDelegate PlayerControl::touchZoomEvent
	PlayerControlDelegate_t3362226240 * ___touchZoomEvent_11;

public:
	inline static int32_t get_offset_of_camera_2() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___camera_2)); }
	inline Camera_t189460977 * get_camera_2() const { return ___camera_2; }
	inline Camera_t189460977 ** get_address_of_camera_2() { return &___camera_2; }
	inline void set_camera_2(Camera_t189460977 * value)
	{
		___camera_2 = value;
		Il2CppCodeGenWriteBarrier(&___camera_2, value);
	}

	inline static int32_t get_offset_of_mouseDownTime_3() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___mouseDownTime_3)); }
	inline float get_mouseDownTime_3() const { return ___mouseDownTime_3; }
	inline float* get_address_of_mouseDownTime_3() { return &___mouseDownTime_3; }
	inline void set_mouseDownTime_3(float value)
	{
		___mouseDownTime_3 = value;
	}

	inline static int32_t get_offset_of_lastTouchPosition_4() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___lastTouchPosition_4)); }
	inline Vector3_t2243707580  get_lastTouchPosition_4() const { return ___lastTouchPosition_4; }
	inline Vector3_t2243707580 * get_address_of_lastTouchPosition_4() { return &___lastTouchPosition_4; }
	inline void set_lastTouchPosition_4(Vector3_t2243707580  value)
	{
		___lastTouchPosition_4 = value;
	}

	inline static int32_t get_offset_of_wasLastFrameZooming_5() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___wasLastFrameZooming_5)); }
	inline bool get_wasLastFrameZooming_5() const { return ___wasLastFrameZooming_5; }
	inline bool* get_address_of_wasLastFrameZooming_5() { return &___wasLastFrameZooming_5; }
	inline void set_wasLastFrameZooming_5(bool value)
	{
		___wasLastFrameZooming_5 = value;
	}

	inline static int32_t get_offset_of_lastZoomDistance_6() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___lastZoomDistance_6)); }
	inline float get_lastZoomDistance_6() const { return ___lastZoomDistance_6; }
	inline float* get_address_of_lastZoomDistance_6() { return &___lastZoomDistance_6; }
	inline void set_lastZoomDistance_6(float value)
	{
		___lastZoomDistance_6 = value;
	}

	inline static int32_t get_offset_of_longTouchEvent_7() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___longTouchEvent_7)); }
	inline PlayerControlDelegate_t3362226240 * get_longTouchEvent_7() const { return ___longTouchEvent_7; }
	inline PlayerControlDelegate_t3362226240 ** get_address_of_longTouchEvent_7() { return &___longTouchEvent_7; }
	inline void set_longTouchEvent_7(PlayerControlDelegate_t3362226240 * value)
	{
		___longTouchEvent_7 = value;
		Il2CppCodeGenWriteBarrier(&___longTouchEvent_7, value);
	}

	inline static int32_t get_offset_of_touchEndEvent_8() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___touchEndEvent_8)); }
	inline PlayerControlDelegate_t3362226240 * get_touchEndEvent_8() const { return ___touchEndEvent_8; }
	inline PlayerControlDelegate_t3362226240 ** get_address_of_touchEndEvent_8() { return &___touchEndEvent_8; }
	inline void set_touchEndEvent_8(PlayerControlDelegate_t3362226240 * value)
	{
		___touchEndEvent_8 = value;
		Il2CppCodeGenWriteBarrier(&___touchEndEvent_8, value);
	}

	inline static int32_t get_offset_of_touchBeginEvent_9() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___touchBeginEvent_9)); }
	inline PlayerControlDelegate_t3362226240 * get_touchBeginEvent_9() const { return ___touchBeginEvent_9; }
	inline PlayerControlDelegate_t3362226240 ** get_address_of_touchBeginEvent_9() { return &___touchBeginEvent_9; }
	inline void set_touchBeginEvent_9(PlayerControlDelegate_t3362226240 * value)
	{
		___touchBeginEvent_9 = value;
		Il2CppCodeGenWriteBarrier(&___touchBeginEvent_9, value);
	}

	inline static int32_t get_offset_of_touchMovedEvent_10() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___touchMovedEvent_10)); }
	inline PlayerControlDelegate_t3362226240 * get_touchMovedEvent_10() const { return ___touchMovedEvent_10; }
	inline PlayerControlDelegate_t3362226240 ** get_address_of_touchMovedEvent_10() { return &___touchMovedEvent_10; }
	inline void set_touchMovedEvent_10(PlayerControlDelegate_t3362226240 * value)
	{
		___touchMovedEvent_10 = value;
		Il2CppCodeGenWriteBarrier(&___touchMovedEvent_10, value);
	}

	inline static int32_t get_offset_of_touchZoomEvent_11() { return static_cast<int32_t>(offsetof(PlayerControl_t792727354, ___touchZoomEvent_11)); }
	inline PlayerControlDelegate_t3362226240 * get_touchZoomEvent_11() const { return ___touchZoomEvent_11; }
	inline PlayerControlDelegate_t3362226240 ** get_address_of_touchZoomEvent_11() { return &___touchZoomEvent_11; }
	inline void set_touchZoomEvent_11(PlayerControlDelegate_t3362226240 * value)
	{
		___touchZoomEvent_11 = value;
		Il2CppCodeGenWriteBarrier(&___touchZoomEvent_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
