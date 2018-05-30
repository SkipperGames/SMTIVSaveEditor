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
        public int Exp;
        public BaseStats StatsBase;
        public EquippedStats StatsEquipped;
        public List<KeyValuePair<short, byte>> Skills;

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
