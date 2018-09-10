using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SMTIV.Enums
{

    public enum Resistance : short
    {
        Weak = -1,
        Neutral,
        Resist,
        Null,
        Repel,
        Drain,
    }

    public enum SkillType
    {
        Dummy = -1,
        Fire,
        Ice,
        Elec,
        Force,
        Almighty,
        Dark,
        Light,
        Ailment,
        Healing,
        Status,
        Support,
        Phys,
        Gun,
        Auto
    }

    public enum Damage
    {
        Unknown = -1,
        Zero,
        Fixed,
        Weak,
        Medium,
        Heavy,
        Severe,
        Mega,
        KO
    }

    public enum Target
    {
        Unknown,
        Single,
        Multi,
        Enemies,
        Self,
        Ally,
        Allies,
        All
    }

    public enum StatusCondition : short
    {
        None,
        Smirk = 0x10,
        Bind,
        Poison,
        KO,
        Sleep,
        Panic,
        Sick,
        Lost,
        Brand
    }

    public enum WeaponType
    {
        Sword, Blunt, Dagger, Spear
    }

    public enum Race
    {
        Unknown = -1, None,
        Amatsu, Archaic, Avatar, Avian,
        Beast, Brute,
        Chaos, Cyber,
        Deity, Divine, Dragon, Drake,
        Element, Enigma, Entity,
        Fairy, Fallen, Famed, Femme, Fiend, Flight, Food, Foul, Fury,
        Genma, Ghost, Godly,
        Herald, Holy, Horde, Human,
        Jaki, Jirae,
        King, Kishin, Kunitsu,
        Lady,
        Megami, Mitama,
        Night, Nymph,
        Raptor, Reaper,
        Snake, Spirit,
        Tree, Tyrant,
        Undead,
        Vermin, Vile,
        Wilder, Wood,
        Yoma,
        Zealot
    }
}