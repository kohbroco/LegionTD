#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// SemiCircleMenu/MenuButtonDelegate
struct MenuButtonDelegate_t4066498894;
// UnityEngine.GameObject
struct GameObject_t1756533147;
// UnityEngine.Sprite[]
struct SpriteU5BU5D_t3359083662;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SemiCircleMenu
struct  SemiCircleMenu_t2035937149  : public MonoBehaviour_t1158329972
{
public:
	// SemiCircleMenu/MenuButtonDelegate SemiCircleMenu::menuButtonDown
	MenuButtonDelegate_t4066498894 * ___menuButtonDown_2;
	// SemiCircleMenu/MenuButtonDelegate SemiCircleMenu::menuButtonUp
	MenuButtonDelegate_t4066498894 * ___menuButtonUp_3;
	// UnityEngine.GameObject SemiCircleMenu::buttonPrefab
	GameObject_t1756533147 * ___buttonPrefab_4;
	// UnityEngine.Sprite[] SemiCircleMenu::buttonImages
	SpriteU5BU5D_t3359083662* ___buttonImages_5;
	// System.Single SemiCircleMenu::buttonDistanceFromCenter
	float ___buttonDistanceFromCenter_6;
	// System.Single SemiCircleMenu::buttonHeight
	float ___buttonHeight_7;
	// System.Boolean SemiCircleMenu::isOpen
	bool ___isOpen_8;

public:
	inline static int32_t get_offset_of_menuButtonDown_2() { return static_cast<int32_t>(offsetof(SemiCircleMenu_t2035937149, ___menuButtonDown_2)); }
	inline MenuButtonDelegate_t4066498894 * get_menuButtonDown_2() const { return ___menuButtonDown_2; }
	inline MenuButtonDelegate_t4066498894 ** get_address_of_menuButtonDown_2() { return &___menuButtonDown_2; }
	inline void set_menuButtonDown_2(MenuButtonDelegate_t4066498894 * value)
	{
		___menuButtonDown_2 = value;
		Il2CppCodeGenWriteBarrier(&___menuButtonDown_2, value);
	}

	inline static int32_t get_offset_of_menuButtonUp_3() { return static_cast<int32_t>(offsetof(SemiCircleMenu_t2035937149, ___menuButtonUp_3)); }
	inline MenuButtonDelegate_t4066498894 * get_menuButtonUp_3() const { return ___menuButtonUp_3; }
	inline MenuButtonDelegate_t4066498894 ** get_address_of_menuButtonUp_3() { return &___menuButtonUp_3; }
	inline void set_menuButtonUp_3(MenuButtonDelegate_t4066498894 * value)
	{
		___menuButtonUp_3 = value;
		Il2CppCodeGenWriteBarrier(&___menuButtonUp_3, value);
	}

	inline static int32_t get_offset_of_buttonPrefab_4() { return static_cast<int32_t>(offsetof(SemiCircleMenu_t2035937149, ___buttonPrefab_4)); }
	inline GameObject_t1756533147 * get_buttonPrefab_4() const { return ___buttonPrefab_4; }
	inline GameObject_t1756533147 ** get_address_of_buttonPrefab_4() { return &___buttonPrefab_4; }
	inline void set_buttonPrefab_4(GameObject_t1756533147 * value)
	{
		___buttonPrefab_4 = value;
		Il2CppCodeGenWriteBarrier(&___buttonPrefab_4, value);
	}

	inline static int32_t get_offset_of_buttonImages_5() { return static_cast<int32_t>(offsetof(SemiCircleMenu_t2035937149, ___buttonImages_5)); }
	inline SpriteU5BU5D_t3359083662* get_buttonImages_5() const { return ___buttonImages_5; }
	inline SpriteU5BU5D_t3359083662** get_address_of_buttonImages_5() { return &___buttonImages_5; }
	inline void set_buttonImages_5(SpriteU5BU5D_t3359083662* value)
	{
		___buttonImages_5 = value;
		Il2CppCodeGenWriteBarrier(&___buttonImages_5, value);
	}

	inline static int32_t get_offset_of_buttonDistanceFromCenter_6() { return static_cast<int32_t>(offsetof(SemiCircleMenu_t2035937149, ___buttonDistanceFromCenter_6)); }
	inline float get_buttonDistanceFromCenter_6() const { return ___buttonDistanceFromCenter_6; }
	inline float* get_address_of_buttonDistanceFromCenter_6() { return &___buttonDistanceFromCenter_6; }
	inline void set_buttonDistanceFromCenter_6(float value)
	{
		___buttonDistanceFromCenter_6 = value;
	}

	inline static int32_t get_offset_of_buttonHeight_7() { return static_cast<int32_t>(offsetof(SemiCircleMenu_t2035937149, ___buttonHeight_7)); }
	inline float get_buttonHeight_7() const { return ___buttonHeight_7; }
	inline float* get_address_of_buttonHeight_7() { return &___buttonHeight_7; }
	inline void set_buttonHeight_7(float value)
	{
		___buttonHeight_7 = value;
	}

	inline static int32_t get_offset_of_isOpen_8() { return static_cast<int32_t>(offsetof(SemiCircleMenu_t2035937149, ___isOpen_8)); }
	inline bool get_isOpen_8() const { return ___isOpen_8; }
	inline bool* get_address_of_isOpen_8() { return &___isOpen_8; }
	inline void set_isOpen_8(bool value)
	{
		___isOpen_8 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
