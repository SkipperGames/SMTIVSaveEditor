using System;
using System.Collections.Generic;
using System.Linq;

using SMTIV.Skills;

namespace SMTIV.Items
{
    enum StatusAilment
    {
        None, Bind, Poison, KO, Sleep, Panic, Sick, Lost
    }

    enum WeaponType
    {
        Sword, Blunt, Dagger, Spear, Ammo, Firearm
    }

    class Item
    {
        public string Name { get; set; }
        public int Amount { get; set; }
    }

    class Weapon : Item
    {
        public int Power;
        public int HitsMin;
        public int HitsMax;
        public bool IsInaccurate;
        public Target Targets;
        public StatusAilment Effect;
        public WeaponType Wep;
    }

    class Accessory : Item
    {
        public int Mp;
        public Dictionary<string, string> Stats;
        public string Effect;
    }
}