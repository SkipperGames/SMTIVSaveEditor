using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
    class Item : INotifyPropertyChanged
    {
        private int _amount;
        public string Name { get; set; }
        public int Amount
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