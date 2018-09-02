using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SMTIV
{
    
    class Player : INotifyPropertyChanged
    {
        public class SkillAndLevel
        {
            public short id { get; set; }
            public byte lv { get; set; }
            public SkillAndLevel(short i, byte l) { id = i; lv = l; }
        }
       
        const int MACCA_OFFSET = 0x10C;
        const int PLAYER_EQUIPS_OFFSET = 0x110;
        const int PLAYER_STATS_OFFSET = 0x122;
        const int PLAYER_XP_OFFSET = 0x140;
        const int PLAYER_SKILLS_OFFSET = 0x144;
        const int STATUS_FLAGS_OFFSET = 0x182; // player and demons
        const int STORY_ALIGNMENT_OFFSET = 0x184; // for player
        const int PLAYER_LEVEL_OFFSET = 0x186;
        
        short[] equips = new short[7] { 0x3d, 0xb5, 0x30d, 0x12d, 0x1a5, 0x21d, 0x295 };
        short[] stats = new short[7];
        int exp = 0;
        SkillAndLevel[] skills = new SkillAndLevel[8]
            {
                new SkillAndLevel(1, 1), new SkillAndLevel(2, 2),
                new SkillAndLevel(3, 3), new SkillAndLevel(4, 4),
                new SkillAndLevel(5, 5), new SkillAndLevel(6, 6),
                new SkillAndLevel(7, 7), new SkillAndLevel(8, 8)
            };
        short status = 0;
        short alignment = 0;
        byte level = 1;
        int macca = 0;

        public static Player Instance { get; private set; }
        static Player() { Instance = new Player(); }

        public byte[] Data
        {
            get
            {
                byte[] arr = new byte[0x200];
                byte[] a4 = new byte[4];
                byte[] a2 = new byte[2];
                a2 = BitConverter.GetBytes(Sword);
                a2.CopyTo(arr, 0x092);
                a2.CopyTo(arr, 0x110);
                a2 = BitConverter.GetBytes(Gun);
                a2.CopyTo(arr, 0x094);
                a2.CopyTo(arr, 0x112);
                a2 = BitConverter.GetBytes(Ammo);
                a2.CopyTo(arr, 0x096);
                a2.CopyTo(arr, 0x114);
                a2 = BitConverter.GetBytes(Helm);
                a2.CopyTo(arr, 0x098);
                a2.CopyTo(arr, 0x116);
                a2 = BitConverter.GetBytes(Top);
                a2.CopyTo(arr, 0x09a);
                a2.CopyTo(arr, 0x118);
                a2 = BitConverter.GetBytes(Bottom);
                a2.CopyTo(arr, 0x09c);
                a2.CopyTo(arr, 0x11a);
                a2 = BitConverter.GetBytes(Accessory);
                a2.CopyTo(arr, 0x09e);
                a2.CopyTo(arr, 0x11c);
                a4 = BitConverter.GetBytes(exp);
                a4.CopyTo(arr, 0x0a0);
                a4.CopyTo(arr, 0x140);
                a2 = BitConverter.GetBytes(Hp);
                a2.CopyTo(arr, 0x0a4);
                a2.CopyTo(arr, 0x0b0);
                a2.CopyTo(arr, 0x12c);
                a2.CopyTo(arr, 0x13a);
                a2 = BitConverter.GetBytes(Mp);
                a2.CopyTo(arr, 0x0a6);
                a2.CopyTo(arr, 0x0b2);
                a2.CopyTo(arr, 0x12e);
                a2.CopyTo(arr, 0x13c);
                a2 = BitConverter.GetBytes(St);
                a2.CopyTo(arr, 0x0b4);
                a2.CopyTo(arr, 0x0c2);
                a2.CopyTo(arr, 0x122);
                a2.CopyTo(arr, 0x130);
                a2 = BitConverter.GetBytes(Dx);
                a2.CopyTo(arr, 0x0b6);
                a2.CopyTo(arr, 0x0c4);
                a2.CopyTo(arr, 0x124);
                a2.CopyTo(arr, 0x132);
                a2 = BitConverter.GetBytes(Ma);
                a2.CopyTo(arr, 0x0b8);
                a2.CopyTo(arr, 0x0c6);
                a2.CopyTo(arr, 0x126);
                a2.CopyTo(arr, 0x134);
                a2 = BitConverter.GetBytes(Ag);
                a2.CopyTo(arr, 0x0ba);
                a2.CopyTo(arr, 0x0c8);
                a2.CopyTo(arr, 0x128);
                a2.CopyTo(arr, 0x136);
                a2 = BitConverter.GetBytes(Lu);
                a2.CopyTo(arr, 0x0bc);
                a2.CopyTo(arr, 0x0ca);
                a2.CopyTo(arr, 0x12a);
                a2.CopyTo(arr, 0x138);
                arr[0x0cc] = arr[0x186] = level;
                BitConverter.GetBytes(macca).CopyTo(arr, MACCA_OFFSET);                
                for (int i = 0; i < 8; i++) { BitConverter.GetBytes(skills[i].id).CopyTo(arr, PLAYER_SKILLS_OFFSET + (i * 2)); }
                for (int i = 0; i < 8; i++) { arr[PLAYER_SKILLS_OFFSET + 0x10 + i] = skills[i].lv; }
                BitConverter.GetBytes(status).CopyTo(arr, STATUS_FLAGS_OFFSET);
                BitConverter.GetBytes(alignment).CopyTo(arr, STORY_ALIGNMENT_OFFSET);
                return arr;
            }
            set
            {
                Macca = BitConverter.ToInt32(value, MACCA_OFFSET);

                Sword = BitConverter.ToInt16(value, PLAYER_EQUIPS_OFFSET + 0x00);
                Gun = BitConverter.ToInt16(value, PLAYER_EQUIPS_OFFSET + 0x02);
                Ammo = BitConverter.ToInt16(value, PLAYER_EQUIPS_OFFSET + 0x04);
                Helm = BitConverter.ToInt16(value, PLAYER_EQUIPS_OFFSET + 0x06);
                Top = BitConverter.ToInt16(value, PLAYER_EQUIPS_OFFSET + 0x08);
                Bottom = BitConverter.ToInt16(value, PLAYER_EQUIPS_OFFSET + 0x0a);
                Accessory = BitConverter.ToInt16(value, PLAYER_EQUIPS_OFFSET + 0x0c);

                St = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x0);
                Dx = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x2);
                Ma = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x4);
                Ag = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x6);
                Lu = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0x8);
                Hp = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0xa);
                Mp = BitConverter.ToInt16(value, PLAYER_STATS_OFFSET + 0xc);

                Exp = BitConverter.ToInt32(value, PLAYER_XP_OFFSET);

                for (int i = 0; i < 8; i++)
                {
                    skills[i].id = BitConverter.ToInt16(value, PLAYER_SKILLS_OFFSET + i * 2);
                    skills[i].lv = value[PLAYER_SKILLS_OFFSET + 0x10 + i];
                }

                Status = BitConverter.ToInt16(value, STATUS_FLAGS_OFFSET);
                Alignment = BitConverter.ToInt16(value, STORY_ALIGNMENT_OFFSET);
                Level = value[PLAYER_LEVEL_OFFSET];
            }
        }

        public int Macca
        {
            get { return macca; }
            set { macca = value; NotifyPropertyChanged("Macca"); }
        }
        
        public short Sword
        {
            get { return equips[0]; }
            set { equips[0] = value; NotifyPropertyChanged("Sword"); }
        }

        public short Gun
        {
            get { return equips[1]; }
            set { equips[1] = value; NotifyPropertyChanged("Gun"); }
        }

        public short Ammo
        {
            get { return equips[2]; }
            set { equips[2] = value; NotifyPropertyChanged("Ammo"); }
        }

        public short Helm
        {
            get { return equips[3]; }
            set { equips[3] = value; NotifyPropertyChanged("Helm"); }
        }

        public short Top
        {
            get { return equips[4]; }
            set { equips[4] = value; NotifyPropertyChanged("Top"); }
        }

        public short Bottom
        {
            get { return equips[5]; }
            set { equips[5] = value; NotifyPropertyChanged("Bottom"); }
        }

        public short Accessory
        {
            get { return equips[6]; }
            set { equips[6] = value; NotifyPropertyChanged("Accessory"); }
        }

        public short St
        {
            get { return stats[0]; }
            set { stats[0] = value; NotifyPropertyChanged("St"); }
        }

        public short Dx
        {
            get { return stats[1]; }
            set { stats[1] = value; NotifyPropertyChanged("Dx"); }
        }

        public short Ma
        {
            get { return stats[2]; }
            set { stats[2] = value; NotifyPropertyChanged("Ma"); }
        }

        public short Ag
        {
            get { return stats[3]; }
            set { stats[3] = value; NotifyPropertyChanged("Ag"); }
        }

        public short Lu
        {
            get { return stats[4]; }
            set { stats[4] = value; NotifyPropertyChanged("Lu"); }
        }

        public short Hp
        {
            get { return stats[5]; }
            set { stats[5] = value; NotifyPropertyChanged("Hp"); }
        }

        public short Mp
        {
            get { return stats[6]; }
            set { stats[6] = value; NotifyPropertyChanged("Mp"); }
        }

        public int Exp
        {
            get { return exp; }
            set { exp = value; NotifyPropertyChanged("Exp"); }
        }

        public SkillAndLevel[] Skills
        {
            get { return skills; }
            set { skills = value; NotifyPropertyChanged("Skills"); }
        }

        public byte Level
        {
            get { return level; }
            set { level = value; NotifyPropertyChanged("Level"); }
        }

        public short Status
        {
            get { return status; }
            set { status = value; NotifyPropertyChanged("Status"); }
        }

        public short Alignment
        {
            get { return alignment; }
            set { alignment = value; NotifyPropertyChanged("Alignment"); }
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
        //xp
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
        //status conditions
        //story alignment
        //level
    }
}
