using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMTIV
{
    class EquippedStats
    {
        public short CurrentHp;
        public short CurrentMp;
        public short MaxHp;
        public short MaxMp;
        public short St;
        public short Dx;
        public short Ma;
        public short Ag;
        public short Lu;
    }

    class BaseStats
    {
        public short Sword;
        public short Gun;
        public short Ammo;
        public short Helm;
        public short UpperArmor;
        public short LowerArmor;
        public short Accessory;
        public short St;
        public short Dx;
        public short Ma;
        public short Ag;
        public short Lu;
        public byte Level;
    }

    class Player
    {        
        public int CurrentXp;
        public EquippedStats StatsEquipped;
        public BaseStats StatsBasic;
        //public int TotalXp;
        public BaseStats BattleStatsBasic;
        public EquippedStats BattleStatsEquipped;
        public short[] Skills;
        public byte[] SkillLevels;

        //sword
        //gun
        //ammo
        //helm
        //top
        //bottom
        //accessory
        //current xp
        //current hp
        //current mp
        //max hp
        //max mp
        //st
        //dx
        //ma
        //ag
        //lu
        //?
        //?
        //base 
    }
}
