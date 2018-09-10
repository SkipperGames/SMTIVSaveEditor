using System;
using System.Collections.Generic;
using System.ComponentModel;

using SMTIV.Enums;

namespace SMTIV.Items
{
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
        public int Power = 0;
        public int HitsMin = 0;
        public int HitsMax = 0;
        public Target Targets = 0;
    }

    class Sword : Weapon
    {
        public bool IsInaccurate = false;
        public StatusCondition Effect = 0;
        public WeaponType WeaponType = 0;
    }

    class Bullet : Item
    {
        public int Power = 0;
        public SkillType Type = SkillType.Dummy;
        public StatusCondition Effect = 0;
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
}