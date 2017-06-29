#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Camera
struct Camera_t189460977;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// SemiCircleMenu
struct SemiCircleMenu_t2035937149;
// GridUnit
struct GridUnit_t2663860782;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GridMenu
struct  GridMenu_t3282212385  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Camera GridMenu::mainCamera
	Camera_t189460977 * ___mainCamera_2;
	// UnityEngine.GameObject GridMenu::semiCircleMenuGroup
	GameObject_t1756533147 * ___semiCircleMenuGroup_3;
	// SemiCircleMenu GridMenu::semiCircleMenuScript
	SemiCircleMenu_t2035937149 * ___semiCircleMenuScript_4;
	// System.Boolean GridMenu::ignoreMenuClose
	bool ___ignoreMenuClose_5;
	// System.Boolean GridMenu::ignoreMenuOpen
	bool ___ignoreMenuOpen_6;
	// GridUnit GridMenu::selectedGridUnit
	GridUnit_t2663860782 * ___selectedGridUnit_7;
	// GridUnit GridMenu::proposedMoveToGridUnit
	GridUnit_t2663860782 * ___proposedMoveToGridUnit_8;
	// System.Boolean GridMenu::isMovingTower
	bool ___isMovingTower_9;

public:
	inline static int32_t get_offset_of_mainCamera_2() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___mainCamera_2)); }
	inline Camera_t189460977 * get_mainCamera_2() const { return ___mainCamera_2; }
	inline Camera_t189460977 ** get_address_of_mainCamera_2() { return &___mainCamera_2; }
	inline void set_mainCamera_2(Camera_t189460977 * value)
	{
		___mainCamera_2 = value;
		Il2CppCodeGenWriteBarrier(&___mainCamera_2, value);
	}

	inline static int32_t get_offset_of_semiCircleMenuGroup_3() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___semiCircleMenuGroup_3)); }
	inline GameObject_t1756533147 * get_semiCircleMenuGroup_3() const { return ___semiCircleMenuGroup_3; }
	inline GameObject_t1756533147 ** get_address_of_semiCircleMenuGroup_3() { return &___semiCircleMenuGroup_3; }
	inline void set_semiCircleMenuGroup_3(GameObject_t1756533147 * value)
	{
		___semiCircleMenuGroup_3 = value;
		Il2CppCodeGenWriteBarrier(&___semiCircleMenuGroup_3, value);
	}

	inline static int32_t get_offset_of_semiCircleMenuScript_4() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___semiCircleMenuScript_4)); }
	inline SemiCircleMenu_t2035937149 * get_semiCircleMenuScript_4() const { return ___semiCircleMenuScript_4; }
	inline SemiCircleMenu_t2035937149 ** get_address_of_semiCircleMenuScript_4() { return &___semiCircleMenuScript_4; }
	inline void set_semiCircleMenuScript_4(SemiCircleMenu_t2035937149 * value)
	{
		___semiCircleMenuScript_4 = value;
		Il2CppCodeGenWriteBarrier(&___semiCircleMenuScript_4, value);
	}

	inline static int32_t get_offset_of_ignoreMenuClose_5() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___ignoreMenuClose_5)); }
	inline bool get_ignoreMenuClose_5() const { return ___ignoreMenuClose_5; }
	inline bool* get_address_of_ignoreMenuClose_5() { return &___ignoreMenuClose_5; }
	inline void set_ignoreMenuClose_5(bool value)
	{
		___ignoreMenuClose_5 = value;
	}

	inline static int32_t get_offset_of_ignoreMenuOpen_6() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___ignoreMenuOpen_6)); }
	inline bool get_ignoreMenuOpen_6() const { return ___ignoreMenuOpen_6; }
	inline bool* get_address_of_ignoreMenuOpen_6() { return &___ignoreMenuOpen_6; }
	inline void set_ignoreMenuOpen_6(bool value)
	{
		___ignoreMenuOpen_6 = value;
	}

	inline static int32_t get_offset_of_selectedGridUnit_7() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___selectedGridUnit_7)); }
	inline GridUnit_t2663860782 * get_selectedGridUnit_7() const { return ___selectedGridUnit_7; }
	inline GridUnit_t2663860782 ** get_address_of_selectedGridUnit_7() { return &___selectedGridUnit_7; }
	inline void set_selectedGridUnit_7(GridUnit_t2663860782 * value)
	{
		___selectedGridUnit_7 = value;
		Il2CppCodeGenWriteBarrier(&___selectedGridUnit_7, value);
	}

	inline static int32_t get_offset_of_proposedMoveToGridUnit_8() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___proposedMoveToGridUnit_8)); }
	inline GridUnit_t2663860782 * get_proposedMoveToGridUnit_8() const { return ___proposedMoveToGridUnit_8; }
	inline GridUnit_t2663860782 ** get_address_of_proposedMoveToGridUnit_8() { return &___proposedMoveToGridUnit_8; }
	inline void set_proposedMoveToGridUnit_8(GridUnit_t2663860782 * value)
	{
		___proposedMoveToGridUnit_8 = value;
		Il2CppCodeGenWriteBarrier(&___proposedMoveToGridUnit_8, value);
	}

	inline static int32_t get_offset_of_isMovingTower_9() { return static_cast<int32_t>(offsetof(GridMenu_t3282212385, ___isMovingTower_9)); }
	inline bool get_isMovingTower_9() const { return ___isMovingTower_9; }
	inline bool* get_address_of_isMovingTower_9() { return &___isMovingTower_9; }
	inline void set_isMovingTower_9(bool value)
	{
		___isMovingTower_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
