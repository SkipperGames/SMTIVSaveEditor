using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using SMTIV.Skills;

namespace SMTIV.Items
{
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

    public enum Resistance : short
    {
        Weak = -1,
        Neutral,
        Resist,
        Null,
        Repel,
        Drain,
    }

    class Item : INotifyPropertyChanged
    {
        private short _amount = 0;
        private string _name = "---";
        public string Name
        {
            get { return _name; }
            set { if (!string.IsNullOrEmpty(value)) _name = value; }
        }
        public short Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged("Amount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class Weapon : Item
    {
        public int Power;
        public int HitsMin;
        public int HitsMax = 0;
        public Target Targets;
    }

    class Sword : Weapon
    {
        public bool IsInaccurate = false;
        public StatusCondition Effect = StatusCondition.None;
        public WeaponType WeaponType;
    }

    class Bullet : Item
    {
        public int Power;
        public SkillType Type;
        public StatusCondition Effect;
    }

    class Equip : Item
    {
        public int Hp;
    }

    class Armor : Equip
    {
        public int[] Stats = new int[5];
    }

    class UpperArmor : Equip
    {
        public Dictionary<string, Resistance> Elements;
    }

    class Accessory : Item
    {
        public int Mp;
        public Dictionary<string, Resistance> Elements;
        public string Effect;
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

    public class Demon
    {
        public int Id { get; set; } = 0;
        public Race Race { get; set; } = Race.None;
        public string Name { get; set; } = "";
        public Dictionary<SkillType, Resistance> Elements;
        public Dictionary<StatusCondition, Resistance> StatusResistance;
        public bool IsGunAttackType { get; set; } = false;
        public int AttackHitsMin = 1;
        public int AttackHitsMax = 1;
        public Target Targets = Target.Single;
    }
}