#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GridManager
struct  GridManager_t4027472533  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.GameObject GridManager::gridUnitPrefab
	GameObject_t1756533147 * ___gridUnitPrefab_2;
	// System.Int32 GridManager::gridWidth
	int32_t ___gridWidth_3;
	// System.Int32 GridManager::gridLength
	int32_t ___gridLength_4;

public:
	inline static int32_t get_offset_of_gridUnitPrefab_2() { return static_cast<int32_t>(offsetof(GridManager_t4027472533, ___gridUnitPrefab_2)); }
	inline GameObject_t1756533147 * get_gridUnitPrefab_2() const { return ___gridUnitPrefab_2; }
	inline GameObject_t1756533147 ** get_address_of_gridUnitPrefab_2() { return &___gridUnitPrefab_2; }
	inline void set_gridUnitPrefab_2(GameObject_t1756533147 * value)
	{
		___gridUnitPrefab_2 = value;
		Il2CppCodeGenWriteBarrier(&___gridUnitPrefab_2, value);
	}

	inline static int32_t get_offset_of_gridWidth_3() { return static_cast<int32_t>(offsetof(GridManager_t4027472533, ___gridWidth_3)); }
	inline int32_t get_gridWidth_3() const { return ___gridWidth_3; }
	inline int32_t* get_address_of_gridWidth_3() { return &___gridWidth_3; }
	inline void set_gridWidth_3(int32_t value)
	{
		___gridWidth_3 = value;
	}

	inline static int32_t get_offset_of_gridLength_4() { return static_cast<int32_t>(offsetof(GridManager_t4027472533, ___gridLength_4)); }
	inline int32_t get_gridLength_4() const { return ___gridLength_4; }
	inline int32_t* get_address_of_gridLength_4() { return &___gridLength_4; }
	inline void set_gridLength_4(int32_t value)
	{
		___gridLength_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
