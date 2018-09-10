using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SMTIV.Enums;


namespace SMTIV
{
    public class Demon
    {
        public Demon() { }
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

    public class DemonCollection : List<Demon>
    {
        public static DemonCollection Demons { get; private set; }
        static DemonCollection() { Demons = new DemonCollection(1124); }
        
        public static BindingList<byte> Members { get; private set; } = new BindingList<byte>()
        {
            0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,
            0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff,
            0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff
        };
        public static byte PartyMember1 { get; set; } = 0xff;
        public static byte PartyMember2 { get; set; } = 0xff;
        public static byte PartyMember3 { get; set; } = 0xff;
        public static byte StockLimit { get; set; } = 0x8;

        public DemonCollection(int capacity) : base(capacity) { }
    }
}