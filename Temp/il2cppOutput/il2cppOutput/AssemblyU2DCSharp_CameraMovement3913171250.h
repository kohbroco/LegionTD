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





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CameraMovement
struct  CameraMovement_t3913171250  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Vector3 CameraMovement::oldTouchPosition
	Vector3_t2243707580  ___oldTouchPosition_2;
	// System.Boolean CameraMovement::cameraMovementControlOn
	bool ___cameraMovementControlOn_3;
	// System.Single CameraMovement::zoomFactor
	float ___zoomFactor_4;
	// System.Single CameraMovement::heightUpperLimit
	float ___heightUpperLimit_5;
	// System.Single CameraMovement::lowerUpperLimit
	float ___lowerUpperLimit_6;

public:
	inline static int32_t get_offset_of_oldTouchPosition_2() { return static_cast<int32_t>(offsetof(CameraMovement_t3913171250, ___oldTouchPosition_2)); }
	inline Vector3_t2243707580  get_oldTouchPosition_2() const { return ___oldTouchPosition_2; }
	inline Vector3_t2243707580 * get_address_of_oldTouchPosition_2() { return &___oldTouchPosition_2; }
	inline void set_oldTouchPosition_2(Vector3_t2243707580  value)
	{
		___oldTouchPosition_2 = value;
	}

	inline static int32_t get_offset_of_cameraMovementControlOn_3() { return static_cast<int32_t>(offsetof(CameraMovement_t3913171250, ___cameraMovementControlOn_3)); }
	inline bool get_cameraMovementControlOn_3() const { return ___cameraMovementControlOn_3; }
	inline bool* get_address_of_cameraMovementControlOn_3() { return &___cameraMovementControlOn_3; }
	inline void set_cameraMovementControlOn_3(bool value)
	{
		___cameraMovementControlOn_3 = value;
	}

	inline static int32_t get_offset_of_zoomFactor_4() { return static_cast<int32_t>(offsetof(CameraMovement_t3913171250, ___zoomFactor_4)); }
	inline float get_zoomFactor_4() const { return ___zoomFactor_4; }
	inline float* get_address_of_zoomFactor_4() { return &___zoomFactor_4; }
	inline void set_zoomFactor_4(float value)
	{
		___zoomFactor_4 = value;
	}

	inline static int32_t get_offset_of_heightUpperLimit_5() { return static_cast<int32_t>(offsetof(CameraMovement_t3913171250, ___heightUpperLimit_5)); }
	inline float get_heightUpperLimit_5() const { return ___heightUpperLimit_5; }
	inline float* get_address_of_heightUpperLimit_5() { return &___heightUpperLimit_5; }
	inline void set_heightUpperLimit_5(float value)
	{
		___heightUpperLimit_5 = value;
	}

	inline static int32_t get_offset_of_lowerUpperLimit_6() { return static_cast<int32_t>(offsetof(CameraMovement_t3913171250, ___lowerUpperLimit_6)); }
	inline float get_lowerUpperLimit_6() const { return ___lowerUpperLimit_6; }
	inline float* get_address_of_lowerUpperLimit_6() { return &___lowerUpperLimit_6; }
	inline void set_lowerUpperLimit_6(float value)
	{
		___lowerUpperLimit_6 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
