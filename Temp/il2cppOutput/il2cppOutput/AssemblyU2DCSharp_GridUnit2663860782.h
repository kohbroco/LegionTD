#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GridUnit
struct  GridUnit_t2663860782  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Vector2 GridUnit::gridCoordinate
	Vector2_t2243707579  ___gridCoordinate_2;
	// UnityEngine.GameObject GridUnit::currentTowerObject
	GameObject_t1756533147 * ___currentTowerObject_3;

public:
	inline static int32_t get_offset_of_gridCoordinate_2() { return static_cast<int32_t>(offsetof(GridUnit_t2663860782, ___gridCoordinate_2)); }
	inline Vector2_t2243707579  get_gridCoordinate_2() const { return ___gridCoordinate_2; }
	inline Vector2_t2243707579 * get_address_of_gridCoordinate_2() { return &___gridCoordinate_2; }
	inline void set_gridCoordinate_2(Vector2_t2243707579  value)
	{
		___gridCoordinate_2 = value;
	}

	inline static int32_t get_offset_of_currentTowerObject_3() { return static_cast<int32_t>(offsetof(GridUnit_t2663860782, ___currentTowerObject_3)); }
	inline GameObject_t1756533147 * get_currentTowerObject_3() const { return ___currentTowerObject_3; }
	inline GameObject_t1756533147 ** get_address_of_currentTowerObject_3() { return &___currentTowerObject_3; }
	inline void set_currentTowerObject_3(GameObject_t1756533147 * value)
	{
		___currentTowerObject_3 = value;
		Il2CppCodeGenWriteBarrier(&___currentTowerObject_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
