using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SMTIV
{
    class AppInfo
    {
        public string Name { get; set; }
        public bool Unlocked { get; set; }
    }
    
    class Player : INotifyPropertyChanged
    {
        const int PLAYER_SAVESTATS_OFFSET = 0x92;
        const int MACCA_OFFSET = 0x10C;
        const int PLAYER_STATS_OFFSET = 0x110;

        int macca = 0;
        short[] stats = new short[14];
        int exp = 0;
        short[] skills = new short[8];
        byte[] skilllevels = new byte[8];
        byte level = 1;

        public byte[] Data
        {
            set
            {
                macca = BitConverter.ToInt32(value, MACCA_OFFSET);

                stats[0] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x0);
                stats[1] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x2);
                stats[2] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x4);
                stats[3] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x6);
                stats[4] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x8);
                stats[5] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0xa);
                stats[6] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0xc);

                stats[7] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x12);
                stats[8] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x14);
                stats[9] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x16);
                stats[10] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x18);
                stats[11] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x1a);
                stats[12] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x1c);
                stats[13] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x1e);

                exp = BitConverter.ToInt32(value, PLAYER_STATS_OFFSET + 0x30);

                for (int i = 0; i < 8; i++)
                {
                    skills[i] = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x34 + i * 2);
                    skilllevels[i] = value[PLAYER_STATS_OFFSET + 0x44 + i];
                }

                level = value[0x76];
            }
            get
            {
                return null;
            }
        }

        public int Macca
        {
            get { return macca; }
            set { macca = value; NotifyPropertyChanged("Macca"); }
        }

        public short Sword
        {
            get { return stats[0]; }
            set { stats[0] = value; NotifyPropertyChanged("Sword"); }
        }

        public short Gun
        {
            get { return stats[1]; }
            set { stats[1] = value; NotifyPropertyChanged("Gun"); }
        }

        public short Ammo
        {
            get { return stats[2]; }
            set { stats[2] = value; NotifyPropertyChanged("Ammo"); }
        }

        public short Helm
        {
            get { return stats[3]; }
            set { stats[3] = value; NotifyPropertyChanged("Helm"); }
        }

        public short Top
        {
            get { return stats[4]; }
            set { stats[4] = value; NotifyPropertyChanged("Top"); }
        }

        public short Bottom
        {
            get { return stats[5]; }
            set { stats[5] = value; NotifyPropertyChanged("Bottom"); }
        }

        public short Accessory
        {
            get { return stats[6]; }
            set { stats[6] = value; NotifyPropertyChanged("Accessory"); }
        }

        public short St
        {
            get { return stats[7]; }
            set { stats[7] = value; NotifyPropertyChanged("St"); }
        }

        public short Dx
        {
            get { return stats[8]; }
            set { stats[8] = value; NotifyPropertyChanged("Dx"); }
        }

        public short Ma
        {
            get { return stats[9]; }
            set { stats[9] = value; NotifyPropertyChanged("Ma"); }
        }

        public short Ag
        {
            get { return stats[10]; }
            set { stats[10] = value; NotifyPropertyChanged("Ag"); }
        }

        public short Lu
        {
            get { return stats[11]; }
            set { stats[11] = value; NotifyPropertyChanged("Lu"); }
        }

        public short Hp
        {
            get { return stats[12]; }
            set { stats[12] = value; NotifyPropertyChanged("Hp"); }
        }

        public short Mp
        {
            get { return stats[13]; }
            set { stats[13] = value; NotifyPropertyChanged("Mp"); }
        }

        public int Exp
        {
            get { return exp; }
            set { exp = value; NotifyPropertyChanged("Exp"); }
        }

        public short[] Skills
        {
            get { return skills; }
            set { skills = value; NotifyPropertyChanged("Skills"); }
        }

        public byte[] SkillLevels
        {
            get { return skilllevels; }
            set { skilllevels = value; NotifyPropertyChanged("SkillLevels"); }
        }

        public byte Level
        {
            get { return level; }
            set { level = value; NotifyPropertyChanged("Level"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //sword
        //gun
        //ammo
        //helm
        //top
        //bottom
        //accessory
        //?
        //hp
        //mp
        //max hp
        //max mp
        //st
        //dx
        //ma
        //ag
        //lu
        //?
        //?
        //base st
        //base dx
        //base ma
        //base ag
        //base lu
        //level
        //?
        //?

        //sword
        //gun
        //ammo
        //helm
        //top
        //bottom
        //accessory
        //?
        //?
        //base st
        //base dx
        //base ma
        //base ag
        //base lu
        //max hp
        //max mp
        //st
        //dx
        //ma
        //ag
        //lu
        //hp
        //mp
        //xp
        //skills 1~8
        //skills 1~8 levels
        //level
    }
}
