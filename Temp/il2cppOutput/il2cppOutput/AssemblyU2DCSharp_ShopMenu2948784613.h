#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TabListMenu59239264.h"

// GridUnit
struct GridUnit_t2663860782;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ShopMenu
struct  ShopMenu_t2948784613  : public TabListMenu_t59239264
{
public:
	// GridUnit ShopMenu::selectedGridUnit
	GridUnit_t2663860782 * ___selectedGridUnit_12;
	// System.Boolean ShopMenu::isOpen
	bool ___isOpen_13;

public:
	inline static int32_t get_offset_of_selectedGridUnit_12() { return static_cast<int32_t>(offsetof(ShopMenu_t2948784613, ___selectedGridUnit_12)); }
	inline GridUnit_t2663860782 * get_selectedGridUnit_12() const { return ___selectedGridUnit_12; }
	inline GridUnit_t2663860782 ** get_address_of_selectedGridUnit_12() { return &___selectedGridUnit_12; }
	inline void set_selectedGridUnit_12(GridUnit_t2663860782 * value)
	{
		___selectedGridUnit_12 = value;
		Il2CppCodeGenWriteBarrier(&___selectedGridUnit_12, value);
	}

	inline static int32_t get_offset_of_isOpen_13() { return static_cast<int32_t>(offsetof(ShopMenu_t2948784613, ___isOpen_13)); }
	inline bool get_isOpen_13() const { return ___isOpen_13; }
	inline bool* get_address_of_isOpen_13() { return &___isOpen_13; }
	inline void set_isOpen_13(bool value)
	{
		___isOpen_13 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
