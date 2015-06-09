using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;



namespace Skills
{

    public enum Skill_Type : byte
    {
        Fire        = 0,
        Ice         = 1,
        Elec        = 2,
        Force       = 3,
        Almighty    = 4,
        Dark        = 5,
        Light       = 6,
        Ailment     = 7,
        Healing     = 8,
        Status      = 9,
        Support     = 10,
        Phys        = 11,
        Gun         = 12,
        Auto        = 13,
        Dummy       = 14,
    }

    public enum Damage : byte
    {
        Zero        = 0,
        Weak        = 1,
        Medium      = 2,
        Heavy       = 3,
        Severe      = 4,
        KO          = 5,
        Fixed       = 6,
        Unknown     = 7,
        Mega        = 8,
    }

    public enum Target : byte
    {
        Single  = 0,
        Multi   = 1,
        Enemies = 2,
        Self    = 3,
        Ally    = 4,
        Allies  = 5,
        All     = 6,
        Unknown = 7,
    }

    public class Skill
    {
        public short    ID          { get; set; }
        public string   Name        { get; set; }
        public string   Type        { get; set; }
        public int      Cost        { get; set; }
        public string   Damage      { get; set; }
        public string   Target      { get; set; }
        public string   Desc        { get; set; }


        public Skill()
        {
            ID = 0;
            Name = "";
            Type = "";
            Cost = 0;
            Damage = "";
            Target = "";
            Desc = "";
        }

        public Skill(short id, string name, byte type, int cost, byte damage, byte target)
        {
            this.ID     = id;
            this.Name   = name;
            this.Cost   = cost;

            try
            {
                this.Type   = Enum.Parse(typeof(Skill_Type),    type.ToString()).ToString();
                this.Damage = Enum.Parse(typeof(Damage),        damage.ToString()).ToString();
                this.Target = Enum.Parse(typeof(Target),        target.ToString()).ToString();
            }
            catch
            {
                this.Type   = "Skill Type Exception";
                this.Damage = "Skill Damage Exception";
                this.Target = "Skill Target Exception";
            }

            this.Desc = "";
        }

        public Skill(short id, string name, byte type, int cost, byte damage, byte target, string desc)
        {
            this.ID = id;
            this.Name = name;
            this.Cost = cost;

            try
            {
                this.Type = Enum.Parse(typeof(Skill_Type), type.ToString()).ToString();
                this.Damage = Enum.Parse(typeof(Damage), damage.ToString()).ToString();
                this.Target = Enum.Parse(typeof(Target), target.ToString()).ToString();
            }
            catch
            {
                this.Type = "Skill Type Exception";
                this.Damage = "Skill Damage Exception";
                this.Target = "Skill Target Exception";
            }

            this.Desc = desc;
        }
    }

    public static class SkillCollection
    {


        #region skill list
        /*
        static readonly List<Skill> skills = new List<Skill>() 
        {

            //          id      name                    type    mp      dmg     target  desc
            
            // fire
            new Skill(  0x1,    "Agi",                  0,      1,      1,      0,      "Weak Fire damage. 1 enemy."),
            new Skill(  0x2,    "Agilao",               0,      4,      2,      0,      "Medium Fire damage. 1 enemy."),
            new Skill(  0x3,    "Agidyne",              0,      10,     3,      0,      "Heavy Fire damage. 1 enemy."),
            new Skill(  0x4,    "Maragi",               0,      7,      1,      2,      "Weak Fire damage. All enemies."),
            new Skill(  0x5,    "Maragion",             0,      16,     2,      2,      "Medium Fire damage. All enemies."),
            new Skill(  0x6,    "Maragidyne",           0,      28,     3,      2,      "Heavy Fire damage. All enemies."),
            new Skill(  0x7,    "Fire Breath",          0,      17,     1,      1,      "1~4 hits weak Fire damage. Multiple enemies."),
            new Skill(  0x8,    "Trisagion",            0,      18,     4,      0,      "Severe Fire damage. 1 enemy"),
            new Skill(  0x9,    "Ragnarok",             0,      31,     2,      1,      "1~4 hits medium Fire damage. Muliple enemies."),
            new Skill(  0x102,  "Sunny Ray",            0,      1,      1,      2,      "Weak Fire damage. 70% Poison. All enemies."),
            new Skill(  0x138,  "Inferno of God",       0,      46,     3,      2,      "Heavy Fire damage. Pierce enemy Fire Resist/Null/Drain. All enemies."),

            // ice
            new Skill(  0xa,    "Bufu",                 1,      1,      1,      0,      "Weak Ice damage. 1 enemy."),
            new Skill(  0xb,    "Bufula",               1,      4,      2,      0,      "Medium Ice damage. 1 enemy."),
            new Skill(  0xc,    "Bufudyne",             1,      10,     3,      0,      "Heavy Ice damage. 1 enemy."),
            new Skill(  0xd,    "Mabufu",               1,      7,      1,      2,      "Weak Ice damage. All enemies."),
            new Skill(  0xe,    "Mabufula",             1,      16,     2,      2,      "Medium Ice damage. All enemies."),
            new Skill(  0xf,    "Mabufudyne",           1,      28,     3,      2,      "Heavy Ice damage. All enemies."),
            new Skill(  0x10,   "Ice Breath",           1,      17,     1,      1,      "1~4 hits weak Ice damage. Muliple enemies."),
            new Skill(  0x11,   "Glacial Blast",        1,      18,     2,      1,      "1~4 hits medium Ice damage. Multiple enemies."),
            new Skill(  0x12,   "Cold World",           1,      46,     3,      2,      "Heavy Ice damage. 15% KO. All enemies."),
            new Skill(  0x4c,   "Breath",               1,      20,     2,      1,      "1~5 hits medium Ice damage. Multiple enemies."),
            new Skill(  0x134,  "Hailstorm of God",     1,      46,     3,      2,      "Heavy Ice damage. Pierce enemy Ice Resist/Null/Drain. All enemies."),
            new Skill(  0x13b,  "Refrigerate",          9,      22,     1,      1,      "1~8 hits weak Ice damage. Multiple enemies."),

            // elec
            new Skill(  0x13,   "Zio",                  2,      1,      1,      0,      "Weak Elec damage. 1 enemy."),
            new Skill(  0x14,   "Zionga",               2,      4,      2,      0,      "Medium Elec damage. 1 enemy."),
            new Skill(  0x15,   "Ziodyne",              2,      10,     3,      0,      "Heavy Elec damage. 1 enemy."),
            new Skill(  0x16,   "Mazio",                2,      7,      1,      2,      "Weak Elec damage. All enemies."),
            new Skill(  0x17,   "Mazionga",             2,      16,     2,      2,      "Medium Elec damage. All enemies."),
            new Skill(  0x18,   "Maziodyne",            2,      28,     3,      2,      "Heavy Elec damage. All enemies."),
            new Skill(  0x19,   "Shock",                2,      17,     1,      1,      "1~4 hits weak Elec damage. Muliple enemies."),
            new Skill(  0x1a,   "Thunder Reign",        2,      18,     4,      2,      "Severe Elec damage. All enemies."),
            new Skill(  0x1b,   "Charming Bolt",        2,      41,     3,      2,      "Heavy Elec damage. 25% Panic. All enemies."),
            new Skill(  0x12e,  "Lightning of God",     2,      46,     3,      2,      "Heavy Elec damage. Pierce enemy Elec Resist/Null/Drain. All enemies."),
            new Skill(  0x139,  "Plasma Discharge",     2,      18,     1,      1,      "1~8 hits weak Elec damage. Multiple enemies."),

            // force
            new Skill(  0x1c,   "Zan",                  3,      1,      1,      0,      "Weak Force damage. 1 enemy."),
            new Skill(  0x1d,   "Zanma",                3,      4,      2,      0,      "Medium Force damage. 1 enemy."),
            new Skill(  0x1e,   "Zandyne",              3,      10,     3,      0,      "Heavy Force damage. 1 enemy."),
            new Skill(  0x1f,   "Mazan",                3,      7,      1,      2,      "Weak Force damage. All enemies."),
            new Skill(  0x20,   "Mazanma",              3,      16,     2,      2,      "Medium Force damage. All enemies."),
            new Skill(  0x21,   "Mazandyne",            3,      28,     3,      2,      "Heavy Force damage. All enemies."),
            new Skill(  0x22,   "Wind Breath",          3,      17,     1,      1,      "1~4 hits weak Force damage. Muliple enemies."),
            new Skill(  0x23,   "Deadly Wind",          3,      18,     4,      0,      "Severe Force damage. 1 enemy."),
            new Skill(  0x24,   "Floral Gust",          3,      31,     2,      1,      "1~4 hits medium Force damage. Muliple enemies."),
            new Skill(  0x132,  "Tornado of God",       3,      46,     3,      2,      "Heavy Force damage. Pierce enemy Force Resist/Null/Drain. All enemies."),

            // almighty
            new Skill(  0x25,   "Megido",               4,      21,     1,      2,      "Weak Almighty damage. All enemies."),
            new Skill(  0x26,   "Megidola",             4,      36,     2,      2,      "Medium Almighty damage. All enemies."),
            new Skill(  0x27,   "Megidolaon",           4,      56,     3,      2,      "Heavy Almighty damage. All enemies."),
            new Skill(  0x28,   "Great Logos",          4,      66,     4,      2,      "Severe Almighty damage. All enemies."),
            new Skill(  0x29,   "Antichthon",           4,      76,     4,      2,      "Severe Almighty damage. Debilitate. All enemies."),
            new Skill(  0x2a,   "Babylon Goblet",       4,      61,     2,      2,      "Medium Almighty damage. 25% Panic."),
            new Skill(  0x2b,   "Holy Wrath",           4,      41,     2,      2,      "50% additional damage VS Chaos."), // + 50% vs chaos
            new Skill(  0x2c,   "Judgement",            4,      41,     2,      2,      "50% additional damage VS Neutral."), // + 50% vs neutral
            new Skill(  0x2d,   "Sea of Chaos",         4,      41,     1,      2,      "50% additional damage VS Law."), // + 50% vs law
            new Skill(  0x2e,   "Life Drain",           4,      1,      1,      0,      "Weak Almighty damage. Drain HP. 1 enemy."),
            new Skill(  0x2f,   "Spirit Drain",         4,      1,      1,      0,      "Weak Almighty damage. Drain MP. 1 enemy."),
            new Skill(  0x30,   "Energy Drain",         4,      1,      1,      0,      "Weak Almighty damage. Drain HP/MP. 1 enemy."),
            new Skill(  0x47,   "Strange Ray",          4,      1,      6,      0,      "Almighty attack reduce target MP to 50%."),
            new Skill(  0x48,   "Enigmatic Ray",        4,      6,      6,      2,      "???"),
            new Skill(  0x49,   "Macca Beam",           4,      1,      6,      0,      "Almighty attack reduce target Macca to 20%."), // targets single or all?
            new Skill(  0x4a,   "Wastrel Beam",         4,      6,      6,      0,      "Almighty attack reduce target Macca to 50%"), // targets single or all?
            new Skill(  0x4b,   "Crushing Wave",        4,      6,      6,      0,      "Almighty attack reduce target HP to 1."),
            new Skill(  0x4d,   "Death's Door",         4,      6,      6,      2,      "All Sick enemies' HP reduced to 1."),
            new Skill(  0xc2,   "Desperate Hit",        4,      36,     1,      1,      "1~5 hits Almighty damage. Multiple enemies."),
            new Skill(  0xfd,   "Queen's Feast",        4,      1,      2,      2,      "Medium Almighty damage. Drain HP."),
            new Skill(  0x100,  "Ameno Murakumo",       4,      1,      2,      2,      "Medium Almighty damage. Tarunda."),
            new Skill(  0x101,  "Homeland Song",        4,      1,      3,      1,      "2~3 hits weak Almighty damage. Multiple enemies."),
            new Skill(  0x103,  "Vulnera",              4,      1,      2,      2,      "Medium Almighty damage. 50% Bind. All enemies."),
            new Skill(  0x105,  "Deceit Chain",         4,      1,      2,      1,      "Medium Almighty damage. 50% Bind. All enemies."),
            new Skill(  0x106,  "Naughty Wave",         4,      1,      2,      2,      "Medium Almighty damage. 10% KO."),
            new Skill(  0x109,  "Evil Shine",           4,      1,      3,      2,      "Heavy Almighty damage. 70% Panic. All enemies."),
            new Skill(  0x10b,  "Morning Star",         4,      1,      6,      2,      "Almighty attack reduce target HP by 50%."),
            new Skill(  0x10c,  "Chariot",              4,      1,      2,      2,      "Medium Almighty damage. Sukunda. All enemies."),
            new Skill(  0x10d,  "Shalt Not Resist",     4,      1,      8,      1,      "2 hits mega Almighty damage. Rakunda. All enemies."),
            new Skill(  0x10e,  "Hexagram",             4,      1,      5,      0,      "Almighty attack. 100% KO."),
            new Skill(  0x10f,  "Hell's Torment",       4,      1,      6,      2,      "Almighty attack reduce target HP by 66%."),
            new Skill(  0x131,  "Serpent of Sheol",     4,      41,     4,      2,      "Severe Almighty damage. Drain HP/MP."),
            new Skill(  0x137,  "Fallen Grace",         4,      40,     6,      0,      "666 Almighty damage to 1 enemy."),
            new Skill(  0x13a,  "Megidoplasma",         4,      37,     3,      2,      "Heavy Almighty damage to all enemies."),
            new Skill(  0x13d,  "Punishment",           4,      1,      6,      2,      "Hits 333 Almighty damage per enemy resistance. All enemies."),
            new Skill(  0x140,  "Curse Thy Enemy",      4,      76,     3,      2,      "Heavy Almighty damage. Gurantees weakness. All enemies."),
            new Skill(  0x143,  "Damnation",            4,      61,     3,      2,      "Heavy Almighty damage. 70% Poison. All enemies."),
            new Skill(  0x144,  "Stigmatic Gleam",      4,      71,     3,      2,      "Heavy Almighty damage. 25% Brand. All enemies."),
            new Skill(  0x146,  "Gaea Rage",            4,      58,     3,      2,      "Heavy Almighty damage. 30% Lost. All enemies."),
            new Skill(  0x184,  "Assist (1)",           4,      1,      7,      2,      "1 hit ??? Almighty damage. All enemies."),
            new Skill(  0x185,  "Assist (2)",           4,      1,      7,      2,      "2 hits ??? Almighty damage. All enemies."),
            new Skill(  0x186,  "Assist (3)",           4,      1,      7,      2,      "3 hits ??? Almighty damage. All enemies."),
            new Skill(  0x187,  "Assist (4)",           4,      1,      7,      2,      "4 hits ??? Almighty damage. All enemies."),
            new Skill(  0x188,  "Assist (5)",           4,      1,      7,      2,      "5 hits ??? Almighty damage. All enemies."),
            new Skill(  0x189,  "Assist (6)",           4,      1,      7,      2,      "6 hits ??? Almighty damage. All enemies."),
            new Skill(  0x18a,  "Assist (7)",           4,      1,      7,      2,      "7 hits ??? Almighty damage. All enemies."),
            new Skill(  0x18b,  "Assist (8)",           4,      1,      7,      2,      "8 hits ??? Almighty damage. All enemies."),
            new Skill(  0x18c,  "Assist (9)",           4,      1,      7,      2,      "9 hits ??? Almighty damage. All enemies."),
            new Skill(  0x18d,  "Assist Rush (1)",      4,      1,      7,      2,      "10 hits ??? Almighty damage. All enemies."),
            new Skill(  0x18e,  "Assist Rush (2)",      4,      1,      7,      2,      "11 hits ??? Almighty damage. All enemies."),
            new Skill(  0x18f,  "Assist Rush (3)",      4,      1,      7,      2,      "12 hits ??? Almighty damage. All enemies."),

            // dark
            new Skill(  0x31,   "Mudo",                 5,      2,      5,      0,      "Dark magic. 30% KO 1 enemy."),
            new Skill(  0x32,   "Mudoon",               5,      6,      5,      0,      "Dark magic. 55% KO 1 enemy."),
            new Skill(  0x33,   "Mamudo",               5,      14,     5,      2,      "Dark magic. 30% KO all enemies."),
            new Skill(  0x34,   "Mamudoon",             5,      26,     5,      2,      "Dark magic. 55% KO all enemies."),
            new Skill(  0x35,   "Die for Me!",          5,      41,     5,      2,      "Dark magic. 80% KO all enemies."),

            // light
            new Skill(  0x36,   "Hama",                 6,      2,      5,      0,      "Light magic. 30% KO 1 enemy."),
            new Skill(  0x37,   "Hamaon",               6,      6,      5,      0,      "Light magic. 55% KO 1 enemy."),
            new Skill(  0x38,   "Mahama",               6,      14,     5,      2,      "Light magic. 30% KO all enemies."),
            new Skill(  0x39,   "Mahamaon",             6,      26,     5,      2,      "Light magic. 55% KO all enemies."),
            new Skill(  0x3a,   "Judgement Light",      6,      41,     5,      2,      "Light magic. 80% KO all enemies."),

            // ailment
            new Skill(  0x3b,   "Dormina",              7,      1,      0,      0,      "90% Sleep. 1 enemy."),
            new Skill(  0x3c,   "Lullaby",              7,      7,      0,      2,      "70% Sleep. All enemies."),
            new Skill(  0x3d,   "Poisma",               7,      1,      0,      0,      "90% Poison. 1 enemy."),
            new Skill(  0x3e,   "Poison Breath",        7,      7,      0,      2,      "70% Poison. All enemies."),
            new Skill(  0x3f,   "Shibaboo",             7,      1,      0,      0,      "50% Bind an enemy."),
            new Skill(  0x40,   "Bind Voice",           7,      11,     0,      2,      "50% Bind all enemies."),
            new Skill(  0x41,   "Pulpina",              7,      1,      0,      0,      "90% Panic. 1 enemy."),
            new Skill(  0x42,   "Panic Voice",          7,      11,     0,      2,      "70% Panic. All enemies."),
            new Skill(  0x43,   "Cough",                7,      14,     0,      0,      "90% Sick. 1 enemy."),
            new Skill(  0x44,   "Pandemic Bomb",        7,      7,      0,      2,      "70% Sick. All Enemies."),
            new Skill(  0x45,   "Ancient Curse",        7,      36,     0,      2,      "80% random ailment. All enemies."),
            new Skill(  0x46,   "Shivering Taboo",      7,      36,     0,      2,      "70% random ailment. All enemies."),
            new Skill(  0x133,  "Lamentation",          7,      41,     0,      2,      "45% random ailment. 100% Brand. All enemies."),
            
            // healing
            new Skill(  0x51,   "Dia",                  8,      1,      0,      4,      "Heal HP for ally. Low."),
            new Skill(  0x52,   "Diarama",              8,      5,      0,      4,      "Heal HP for ally. Medium."),
            new Skill(  0x53,   "Diarahan",             8,      12,     0,      4,      "Heal HP for ally. High."),
            new Skill(  0x54,   "Media",                8,      8,      0,      5,      "Heal HP for party. Low."),
            new Skill(  0x55,   "Mediarama",            8,      18,     0,      5,      "Heal HP for party. Medium."),
            new Skill(  0x56,   "Mediarahan",           8,      36,     0,      5,      "Heal HP for party. High."),
            new Skill(  0x57,   "Salvation",            8,      46,     0,      5,      "Heal full HP and cure ailments for party."),
            new Skill(  0x58,   "Patra",                8,      1,      0,      4,      "Cure Sleep/Panic/Bind for ally."),
            new Skill(  0x59,   "Me Patra",             8,      11,     0,      5,      "Cure Sleep/Panic/Bind for party."),
            new Skill(  0x5a,   "Posumudi",             8,      1,      0,      4,      "Cure Poison/Sick for ally."),
            new Skill(  0x5b,   "Nervundi",             8,      1,      7,      7,      "???"),
            new Skill(  0x5c,   "Amrita",               8,      16,     0,      4,      "Cure all ailments for ally."),
            new Skill(  0x5d,   "Recarm",               8,      16,     0,      4,      "Revive ally with little starting HP."),
            new Skill(  0x5e,   "Samerecarm",           8,      36,     0,      4,      "Revive ally with full starting HP."),
            new Skill(  0x5f,   "Recarmdra",            8,      1,      0,      5,      "User dies. Revive all allies with full HP."),

            // status
            new Skill(  0x65,   "Tarukaja",             9,      11,     0,      5,      "Increase Attack. All allies."),
            new Skill(  0x66,   "Sukukaja",             9,      11,     0,      5,      "Increase Hit/Evade. All allies."),
            new Skill(  0x67,   "Rakukaja",             9,      11,     0,      5,      "Increase Defense. All allies."),
            new Skill(  0x68,   "Luster Candy",         9,      46,     0,      5,      "Increase all stats. All allies."),
            new Skill(  0x69,   "Dekaja",               9,      6,      0,      2,      "Neutralize -kaja effects. All enemies."),
            new Skill(  0x6a,   "Tarunda",              9,      11,     0,      2,      "Decrease Attack. All enemies."),
            new Skill(  0x6b,   "Sukunda",              9,      11,     0,      2,      "Decrease Hit/Evade. All enemies."),
            new Skill(  0x6c,   "Rakunda",              9,      11,     0,      2,      "Decrease Defense. All enemies."),
            new Skill(  0x6d,   "Debilitate",           9,      46,     0,      2,      "Decrease all stats. All enemies."),
            new Skill(  0x6e,   "Dekunda",              9,      6,      0,      5,      "Neutralize -unda effects. All allies."),
            new Skill(  0x6f,   "Silent Prayer",        9,      11,     0,      6,      "Neutralize stat modifications for all."),
            new Skill(  0x70,   "War Cry",              9,      41,     0,      2,      "Decrease Attack/Defense. All enemies"),
            new Skill(  0x71,   "Fog Breath",           9,      41,     0,      2,      "Decrease Attack/Hit/Evade. All enemies"),
            new Skill(  0x72,   "Acid Breath",          9,      41,     0,      2,      "Decrease Defense/Hit/Evade. All enemies"),
            new Skill(  0x73,   "Taunt",                9,      16,     0,      2,      "Decrease Defense. Increase Attack. All enemies."),
            new Skill(  0x75,   "Panic Caster",         9,      46,     0,      3,      "User Panic. Temporary increase in magic damage."),
            new Skill(  0x76,   "Tetrakarn",            9,      46,     0,      5,      "Reflect Phys/Gun damage once."),
            new Skill(  0x77,   "Makarakarn",           9,      46,     0,      5,      "Reflect magic damage once."),
            new Skill(  0x78,   "Tetraja",              9,      11,     0,      5,      "Nullify Light/Dark magic once."),
            new Skill(  0x79,   "Charge",               9,      5,      0,      3,      "User's next Phys/Gun damage 250%."),
            new Skill(  0x7a,   "Concentrate",          9,      7,      0,      3,      "User's next magic damage 250%."),
            new Skill(  0x7b,   "Blood Ritual",         9,      21,     0,      3,      "Luster Candy. Reduce user's HP to 1."),
            new Skill(  0x8a,   "Doping",               9,      41,     0,      5,      "All allies' HP 133%"),
            new Skill(  0x8b,   "Angelic Order",        9,      21,     0,      4,      "Bestows Smirk. 1 ally."),
            new Skill(  0xfe,   "Orchard Guardian",     9,      1,      0,      3,      "Luster Candy."),
            new Skill(  0x10a,  "Kingly One",           9,      1,      0,      1,      "Return 1 demon to player's stock at random."),
            new Skill(  0x110,  "Light Wing (Fire)",    9,      1,      0,      3,      "Repel all attacks except Almight/Fire."),
            new Skill(  0x111,  "Light Wing (Ice)",     9,      1,      0,      3,      "Repel all attacks except Almight/Ice."),
            new Skill(  0x112,  "Light Wing (Elec)",    9,      1,      0,      3,      "Repel all attacks except Almight/Elec."),
            new Skill(  0x113,  "Light Wing (Force)",   9,      1,      0,      3,      "Repel all attacks except Almight/Force."),
            new Skill(  0x12f,  "Tetracoerce",          9,      31,     0,      2,      "Nullifies enemy Tetrakarn effect."),
            new Skill(  0x135,  "Makaracoerce",         9,      31,     0,      2,      "Nullifies enemy Makarakarn effect."),
            new Skill(  0x136,  "Archangel's Law",      9,      46,     0,      4,      "Bestows Smirk. 1 ally."),
            new Skill(  0x13e,  "I Have Dr. Pepper",    9,      1,      0,      0,      "Maximizes user's stats. Minimizes 1 enemy's stats."),
            new Skill(  0x145,  "Spirit Focus",         9,      31,     0,      3,      "User's next magic damage 300%."),
            new Skill(  0x148,  "Dark Energy",          9,      31,     0,      3,      "User's next Phys/Gun damage 300%."),
            
            // support
            new Skill(  0x7c,   "Sabbatma",             10,     16,     0,      4,      "Summon/return 1 ally to stock."),
            new Skill(  0x7d,   "Invitation",           10,     41,     0,      4,      "Summon/return 1 ally to stock and revive if dead."),
            new Skill(  0x7f,   "Bad Company",          10,     11,     0,      5,      "Summon highest level allies from stock."),
            new Skill(  0x89,   "Trafuri",              10,     1,      0,      5,      "Guaranteed escape from random battles."),
            new Skill(  0x8c,   "Estoma Sword",         10,     21,     0,      7,      "Used in maps. Hit enemies to banish them."),
            new Skill(  0x8d,   "Call Ally",            10,     1,      0,      3,      "Dummy"),
            new Skill(  0x141,  "Guardian's Eye",       10,     251,    0,      5,      "Bestows 3 Turn Press icons."),

            // phys
            new Skill(  0x97,   "Lunge",                11,     2,      1,      0,      "Weak Phys damage. High Crit. Low Acc. 1 enemy."),
            new Skill(  0x98,   "Oni-Kagura",           11,     5,      2,      0,      "Medium Phys damage. High Crit. Low Acc. 1 enemy."),
            new Skill(  0x99,   "Mortal Jihad",         11,     9,      3,      0,      "Heavy Phys damage. High Crit. Low Acc. 1 enemy."),
            new Skill(  0x9a,   "Critical Wave",        11,     6,      1,      2,      "Weak Phys damage. High Crit. Low Acc. All enemies."),
            new Skill(  0x9b,   "Megaton Press",        11,     13,     2,      2,      "Medium Phys damage. High Crit. Low Acc. All enemies."),
            new Skill(  0x9c,   "Titanomachia",         11,     26,     3,      2,      "Heavy Phys damage. High Crit. Low Acc. All enemies."),
            new Skill(  0x9d,   "Gram Slice",           11,     1,      1,      0,      "Weak Phys damage. 1 enemy."),
            new Skill(  0x9e,   "Fatal Sword",          11,     4,      2,      0,      "Medium Phys damage. 1 enemy."),
            new Skill(  0x9f,   "Berserker God",        11,     8,      3,      0,      "Heavy Phys damage. 1 enemy."),
            new Skill(  0xa0,   "Heat Wave",            11,     7,      1,      2,      "Weak Phys damage. All enemies."),
            new Skill(  0xa1,   "Javelin Rain",         11,     17,     2,      2,      "Medium Phys damage. All enemies."),
            new Skill(  0xa2,   "Hades Blast",          11,     28,     3,      2,      "Heavy Phys damage. All enemies."),
            new Skill(  0xa3,   "Bouncing Claw",        11,     1,      1,      1,      "1~3 hits weak Phys damage. 1 enemy."),
            new Skill(  0xa4,   "Damascus Claw",        11,     3,      2,      1,      "1~3 hits medium Phys damage. 1 enemy."),
            new Skill(  0xa5,   "Nihil Claw",           11,     7,      3,      1,      "1~3 hits heavy Phys damage. 1 enemy."),
            new Skill(  0xa6,   "Scratch Dance",        11,     5,      1,      1,      "1~3 hits weak Phys damage. Multiple enemies."),
            new Skill(  0xa7,   "Axel Claw",            11,     11,     2,      1,      "1~3 hits medium Phys damage. Multiple enemies."),
            new Skill(  0xa8,   "Madness Nails",        11,     22,     3,      1,      "1~3 hits heavy Phys damage. Multiple enemies."),
            new Skill(  0xa9,   "Fang Breaker",         11,     8,      1,      0,      "Weak Phys damage. Tarunda. 1 enemy."),
            new Skill(  0xaa,   "Dream Fist",           11,     5,      1,      0,      "Weak Phys damage. 70% Sleep. 1 enemy."),
            new Skill(  0xab,   "Purple Smoke",         11,     10,     2,      1,      "1~3 hits medium Phys damage. 70% Panic. Multiple enemies."),
            new Skill(  0xac,   "Carol Hit",            11,     11,     1,      0,      "Weak Phys damage. 50% Lost. 1 enemy."),
            new Skill(  0xae,   "Tetanus Cut",          11,     7,      2,      0,      "Medium Phys damage. 70% Sick. 1 enemy."),
            new Skill(  0xb0,   "Blight",               11,     10,     1,      2,      "Weak Phys damage. 60% Poison. All enemies."),
            new Skill(  0xb1,   "Occult Flash",         11,     26,     2,      2,      "Medium Phys damage. 50% KO. All enemies."),
            new Skill(  0xb2,   "Binding Claw",         11,     7,      2,      0,      "Medium Phys damage. 35% Bind. 1 enemy."),
            new Skill(  0xb3,   "Poison Claw",          11,     5,      2,      0,      "Medium Phys damage. 70% Poison. 1 enemy."),
            new Skill(  0xb4,   "Iron Judgement",       11,     4,      2,      0,      "Medium Phys damage. 1 enemy."),
            new Skill(  0xfb,   "Labrys Strike",        11,     1,      8,      1,      "2~3 hits mega Phys damage. Multiple enemies."),
            new Skill(  0x104,  "Conquerer Spirit",     11,     1,      3,      2,      "2 hits heavy Phys damage. All enemies."),
            new Skill(  0x108,  "Impossible Slash",     11,     1,      2,      2,      "2~3 hits medium Phys damage. All enemies."),
            new Skill(  0x12d,  "Kannuki-Throw",        11,     31,     1,      1,      "1~15 weak hits Phys damage. Multiple enemies."),
            new Skill(  0x130,  "Stigma Strike",        11,     16,     3,      0,      "Heavy Phys damage. 250% Brand. 1 enemy."),
            new Skill(  0x147,  "Deadly Fury",          11,     41,     3,      2,      "Heavy Phys damage. 70% Panic. All enemies."),

            // gun
            new Skill(  0xb5,   "Needle Shot",          12,     2,      1,      0,      "Weak Gun damage. 1 enemy."),
            new Skill(  0xb6,   "Tathlum Shot",         12,     5,      2,      0,      "Medium Gun damage. 1 enemy."),
            new Skill(  0xb7,   "Grand Tack",           12,     9,      3,      0,      "Heavy Gun damage. 1 enemy."),
            new Skill(  0xb8,   "Riot Gun",             12,     6,      4,      0,      "Severe Gun damage. 1 enemy."),
            new Skill(  0xb9,   "Rapid Needle",         12,     13,     1,      2,      "Weak Gun damage. All enemies."),
            new Skill(  0xba,   "Blast Arrow",          12,     26,     2,      2,      "Medium Gun damage. All enemies."),
            new Skill(  0xbb,   "Heaven's Bow",         12,     1,      3,      2,      "Heavy Gun damage. All enemies."),
            new Skill(  0xbc,   "Dream Needle",         12,     4,      1,      0,      "Weak Gun damage. 70% Sleep. 1 enemy."),
            new Skill(  0xbd,   "Toxic Sting",          12,     8,      1,      0,      "Weak Gun damage. 70% Poison. 1 enemy."),
            new Skill(  0xbe,   "Stun Needle",          12,     7,      1,      0,      "Weak Gun damage. 60% Bind. 1 enemy."),
            new Skill(  0xbf,   "Madness Needle",       12,     17,     1,      0,      "Weak Gun damage. 70% Panic. 1 enemy."),
            new Skill(  0xc0,   "Stun Needles",         12,     28,     2,      1,      "1~3 hits medium Gun damage. 60% Bind. Muliple enemies."),
            new Skill(  0xc1,   "Myriad Arrows",        12,     26,     1,      1,      "2~4 hits weak Gun damage. Multiple enemies."),
            new Skill(  0xfc,   "Snake's Fangs",        12,     1,      2,      1,      "2~3 hits medium Gun damage. Multiple enemies."),
            new Skill(  0x107,  "Blank Bullet",         12,     1,      2,      2,      "2 hits medium Gun damage. All enemies."),
            new Skill(  0x13c,  "Star Tarantella",      12,     32,     3,      2,      "Heavy Gun damage. 70% Panic. All enemies."),
            new Skill(  0x13f,  "Masenko-Ha",           12,     1,      3,      2,      "Heavy Gun damage. ???. All enemies."),
            new Skill(  0x165,  "Dorn Gift",            12,     2,      2,      0,      "Medium Gun damage. 1 enemy."),
            new Skill(  0x167,  "Barrage",              12,     1,      1,      2,      "Weak Gun damage. All enemies."),

            // auto
            new Skill(  0x191,  "Resist Phys",          13,     0,      0,      3),
            new Skill(  0x192,  "Null Phys",            13,     0,      0,      3),
            new Skill(  0x193,  "Repel Phys",           13,     0,      0,      3),
            new Skill(  0x194,  "Drain Phys",           13,     0,      0,      3),
            new Skill(  0x195,  "Resist Gun",           13,     0,      0,      3),
            new Skill(  0x196,  "Null Gun",             13,     0,      0,      3),
            new Skill(  0x197,  "Repel Gun",            13,     0,      0,      3),
            new Skill(  0x198,  "Drain Gun",            13,     0,      0,      3),
            new Skill(  0x199,  "Resist Fire",          13,     0,      0,      3),
            new Skill(  0x19a,  "Null Fire",            13,     0,      0,      3),
            new Skill(  0x19b,  "Repel Fire",           13,     0,      0,      3),
            new Skill(  0x19c,  "Drain Fire",           13,     0,      0,      3),
            new Skill(  0x19d,  "Resist Ice",           13,     0,      0,      3),
            new Skill(  0x19e,  "Null Ice",             13,     0,      0,      3),
            new Skill(  0x19f,  "Repel Ice",            13,     0,      0,      3),
            new Skill(  0x1a0,  "Drain Ice",            13,     0,      0,      3),
            new Skill(  0x1a1,  "Resist Elec",          13,     0,      0,      3),
            new Skill(  0x1a2,  "Null Elec",            13,     0,      0,      3),
            new Skill(  0x1a3,  "Repel Elec",           13,     0,      0,      3),
            new Skill(  0x1a4,  "Drain Elec",           13,     0,      0,      3),
            new Skill(  0x1a5,  "Resist Force",         13,     0,      0,      3),
            new Skill(  0x1a6,  "Null Force",           13,     0,      0,      3),
            new Skill(  0x1a7,  "Repel Force",          13,     0,      0,      3),
            new Skill(  0x1a8,  "Drain Force",          13,     0,      0,      3),
            new Skill(  0x1a9,  "Resist Dark",          13,     0,      0,      3),
            new Skill(  0x1aa,  "Null Dark",            13,     0,      0,      3),
            new Skill(  0x1ab,  "Resist Light",         13,     0,      0,      3),
            new Skill(  0x1ac,  "Null Light",           13,     0,      0,      3),
            new Skill(  0x1ad,  "Null Mind",            13,     0,      0,      3),
            new Skill(  0x1ae,  "Null Nerve",           13,     0,      0,      3),
            new Skill(  0x1af,  "Phys Pleroma",         13,     0,      0,      3,      "Phsical attacks 125%."),
            new Skill(  0x1b0,  "High Phys Pleroma",    13,     0,      0,      3,      "Phsical attacks 150%."),
            new Skill(  0x1b1,  "Gun Pleroma",          13,     0,      0,      3,      "Gun attacks 125%."),
            new Skill(  0x1b2,  "High Gun Pleroma",     13,     0,      0,      3,      "Gun attacks 125%."),
            new Skill(  0x1b3,  "Fire Pleroma",         13,     0,      0,      3,      "Fire attacks 125%."),
            new Skill(  0x1b4,  "High Fire Pleroma",    13,     0,      0,      3,      "Fire attacks 125%."),
            new Skill(  0x1b5,  "Ice Pleroma",          13,     0,      0,      3,      "Ice attacks 125%."),
            new Skill(  0x1b6,  "High Ice Pleroma",     13,     0,      0,      3,      "Ice attacks 125%."),
            new Skill(  0x1b7,  "Elec Pleroma",         13,     0,      0,      3,      "Elec attacks 125%."),
            new Skill(  0x1b8,  "High Elec Pleroma",    13,     0,      0,      3,      "Elec attacks 125%."),
            new Skill(  0x1b9,  "Force Pleroma",        13,     0,      0,      3,      "Force attacks 125%."),
            new Skill(  0x1ba,  "High Force Pleroma",   13,     0,      0,      3,      "Force attacks 125%."),
            new Skill(  0x1bb,  "Heal Pleroma",         13,     0,      0,      3,      "Heal effects 125%."),
            new Skill(  0x1bc,  "High Heal Pleroma",    13,     0,      0,      3,      "Heal effects 125%."),
            new Skill(  0x1bd,  "Endure",               13,     0,      0,      3,      "Survive a fatal attack with 1 HP."), 
            new Skill(  0x1be,  "Enduring Soul",        13,     0,      0,      3,      "Survive a fatal attack with full HP."),
            new Skill(  0x1bf,  "Counter",              13,     0,      0,      3,      "Chance to counter Phys/Gun attacks with weak blow."),
            new Skill(  0x1c0,  "Retaliate",            13,     0,      0,      3,      "Chance to counter Phys/Gun attacks with heavy blow."),
            new Skill(  0x1c1,  "Ally Counter",         13,     0,      0,      3,      "Chance to counter Phys/Gun attacks for ally with weak blow."),
            new Skill(  0x1c2,  "Ally Retaliate",       13,     0,      0,      3,      "Chance to counter Phys/Gun attacks for ally with heavy blow."),
            new Skill(  0x1c3,  "Life Aid",             13,     0,      0,      3,      "Recover moderate HP after battle."),
            new Skill(  0x1c4,  "Mana Aid",             13,     0,      0,      3,      "Recover moderate MP after battle."),
            new Skill(  0x1c5,  "Victory Cry",          13,     0,      0,      3,      "Recover full HP/MP after battle."),
            new Skill(  0x1c6,  "Spring of Life",       13,     0,      0,      3,      "Gain a little HP while walking."),
            new Skill(  0x1c7,  "Chakra Walk",          13,     0,      0,      3,      "Gain a little MP while walking."),
            new Skill(  0x1cd,  "Life Bonus",           13,     0,      0,      3,      "HP 110%."),
            new Skill(  0x1ce,  "Life Gain",            13,     0,      0,      3,      "HP 120%."),
            new Skill(  0x1cf,  "Life Surge",           13,     0,      0,      3,      "HP 130%."),
            new Skill(  0x1d0,  "Mana Bonus",           13,     0,      0,      3,      "MP 110%."),
            new Skill(  0x1d1,  "Mana Gain",            13,     0,      0,      3,      "MP 120%."),
            new Skill(  0x1d2,  "Mana Surge",           13,     0,      0,      3,      "MP 130%."),
            new Skill(  0x1d7,  "Healing Knowhow",      13,     0,      0,      3,      "Can use healing items in battle."),
            new Skill(  0x1db,  "Attack Knowhow",       13,     0,      0,      3,      "Can use attack items in battle."),
            new Skill(  0x1dd,  "Light Life Aid",       13,     0,      0,      3,      "Recover a little HP after battle."),
            new Skill(  0x1de,  "Light Mana Aid",       13,     0,      0,      3,      "Recover a little MP after battle."),
            new Skill(  0x1df,  "Speed Lesson",         13,     0,      0,      3,      "Raises base AG by 10."),
            new Skill(  0x1e0,  "Haste Lesson",         13,     0,      0,      3,      "Raises base AG by 20."),
            new Skill(  0x1e1,  "Awakening",            13,     0,      0,      3,      "Raises all base stats by 5."),
            new Skill(  0x1e2,  "Hellish Mask",         13,     0,      0,      3,      "Resist all ailments."),
            new Skill(  0x1e3,  "Hard Worker",          13,     0,      0,      3,      "Slightly increases earned EXP from battle."),
            new Skill(  0x1e4,  "Workaholic",           13,     0,      0,      3,      "Greatly increases earned EXP from battle."),
            new Skill(  0x1e5,  "Beastly Reaction",     13,     0,      0,      3,      "Slightly increases Hit/Evade."),
            new Skill(  0x1e6,  "Draconic Reaction",    13,     0,      0,      3,      "Greatly increases Hit/Evade."),
            new Skill(  0x1e7,  "Bloody Glee",          13,     0,      0,      3,      "Increases Crit chance."),
            new Skill(  0x1e8,  "Pierce Physical",      13,     0,      0,      3,      "User's Phys attacks pierce enemy Phys Resist/Null/Drain."),
            new Skill(  0x1e9,  "Pierce Gun",           13,     0,      0,      3,      "User's Gun attacks pierce enemy Gun Resist/Null/Drain."),
            new Skill(  0x1ea,  "Pierce Fire",          13,     0,      0,      3,      "User's Fire attacks pierce enemy Fire Resist/Null/Drain."),
            new Skill(  0x1eb,  "Pierce Ice",           13,     0,      0,      3,      "User's Ice attacks pierce enemy Ice Resist/Null/Drain."),
            new Skill(  0x1ec,  "Pierce Elec",          13,     0,      0,      3,      "User's Elec attacks pierce enemy Elec Resist/Null/Drain."),
            new Skill(  0x1ed,  "Pierce Force",         13,     0,      0,      3,      "User's Force attacks pierce enemy Force Resist/Null/Drain."),

            // dummy (uses various icons)
            new Skill(  0x4e,   "Dummy",                14,     16,     7,      7),
            new Skill(  0x4f,   "Dummy",                14,     14,     7,      7),
            new Skill(  0x50,   "Dummy",                14,     32,     7,      7),
            new Skill(  0x60,   "Dummy",                14,     56,     7,      7),
            new Skill(  0x61,   "Dummy",                14,     2,      7,      7),
            new Skill(  0x62,   "Dummy",                14,     8,      7,      7),
            new Skill(  0x63,   "Dummy",                14,     16,     7,      7),
            new Skill(  0x64,   "Dummy",                14,     14,     7,      7),
            new Skill(  0x74,   "Dummy",                14,     4,      7,      7),
            new Skill(  0x7e,   "Dummy",                14,     6,      7,      7),
            new Skill(  0x80,   "Dummy",                14,     26,     7,      7),
            new Skill(  0x81,   "Dummy",                14,     56,     7,      7),
            new Skill(  0x82,   "Dummy",                14,     26,     7,      7),
            new Skill(  0x83,   "Dummy",                14,     56,     7,      7),
            new Skill(  0x84,   "Dummy",                14,     26,     7,      7),
            new Skill(  0x85,   "Dummy",                14,     56,     7,      7),
            new Skill(  0x86,   "Dummy",                14,     26,     7,      7),
            new Skill(  0x87,   "Dummy",                14,     56,     7,      7),
            new Skill(  0x88,   "Dummy",                14,     21,     7,      7),
            new Skill(  0x8e,   "Dummy",                14,     16,     7,      7),
            new Skill(  0x8f,   "Do Nothing",           14,     1,      7,      7,      ""),
            new Skill(  0x90,   "No Reaction",          14,     1,      7,      7,      ""),
            new Skill(  0x91,   "Consult",              14,     1,      7,      7,      ""),
            new Skill(  0x92,   "Internal Strife",      14,     1,      7,      7,      ""),
            new Skill(  0x93,   "Dummy",                14,     8,      7,      7),
            new Skill(  0x94,   "Dummy",                14,     16,     7,      7),
            new Skill(  0x95,   "Dummy",                14,     14,     7,      7),
            new Skill(  0x96,   "Dummy",                14,     32,     7,      7),
            new Skill(  0xad,   "Dummy",                14,     3,      7,      7),
            new Skill(  0xaf,   "Dummy",                14,     5,      7,      7),
            new Skill(  0xc3,   "Dummy",                14,     46,     7,      7),
            new Skill(  0xc4,   "Dummy",                14,     41,     7,      7),
            new Skill(  0xc5,   "Dummy",                14,     16,     7,      7),
            new Skill(  0xc6,   "Dummy",                14,     21,     7,      7),
            new Skill(  0xc7,   "Dummy",                14,     31,     7,      7),
            new Skill(  0xc8,   "Dummy",                14,     11,     7,      7),
            new Skill(  0xc9,   "Lantern Flame",        14,     1,      7,      7,      ""),
            new Skill(  0xca,   "Gaea Flame",           14,     1,      7,      7,      ""),
            new Skill(  0xcb,   "Titan's Flame",        14,     1,      7,      7,      ""),
            new Skill(  0xcc,   "Beast's Flame",        14,     1,      7,      7,      ""),
            new Skill(  0xcd,   "Feng Huang Fire",      14,     1,      7,      7,      ""),
            new Skill(  0xce,   "Hee-ho Freeze",        14,     1,      7,      7,      ""),
            new Skill(  0xcf,   "Dragon Glacier",       14,     1,      7,      7,      ""),
            new Skill(  0xd0,   "Wicked Ice",           14,     1,      7,      7,      ""),
            new Skill(  0xd1,   "Drake Breath",         14,     1,      7,      7,      ""),
            new Skill(  0xd2,   "Gui Xian Blizzard",    14,     1,      7,      7,      ""),
            new Skill(  0xd3,   "Jirae Bolt",           14,     1,      7,      7,      ""),
            new Skill(  0xd4,   "Thunderbirds",         14,     1,      7,      7,      ""),
            new Skill(  0xd5,   "Black Forest",         14,     1,      7,      7,      ""),
            new Skill(  0xd6,   "Wilder Bolt",          14,     1,      7,      7,      ""),
            new Skill(  0xd7,   "Baihu Lightning",      14,     1,      7,      7,      ""),
            new Skill(  0xd8,   "Flight Flutter",       14,     1,      7,      7,      ""),
            new Skill(  0xd9,   "Flight Tempest",       14,     1,      7,      7,      ""),
            new Skill(  0xda,   "Poison Storm",         14,     1,      7,      7,      ""),
            new Skill(  0xdb,   "Tengu Wind",           14,     1,      7,      7,      ""),
            new Skill(  0xdc,   "Long Storm",           14,     1,      7,      7,      ""),
            new Skill(  0xdd,   "Dragon Glare",         14,     1,      7,      7,      ""),
            new Skill(  0xde,   "Petra Megido",         14,     1,      7,      7,      ""),
            new Skill(  0xdf,   "Death's Lure",         14,     1,      7,      7,      ""),
            new Skill(  0xe0,   "Life Drainage",        14,     1,      7,      7,      ""),
            new Skill(  0xe1,   "Mana Drainage",        14,     1,      7,      7,      ""),
            new Skill(  0xe2,   "Tyrant's Power",       14,     1,      7,      7,      ""),
            new Skill(  0xe3,   "Demonee-ho Smack",     14,     1,      7,      7,      ""),
            new Skill(  0xe4,   "Beast Slice",          14,     1,      7,      7,      ""),
            new Skill(  0xe5,   "Yuletide",             14,     1,      7,      7,      ""),
            new Skill(  0xe6,   "Dragon Rage",          14,     1,      7,      7,      ""),
            new Skill(  0xe7,   "Tooth and Claw",       14,     1,      7,      7,      ""),
            new Skill(  0xe8,   "Truth and Claw",       14,     1,      7,      7,      ""),
            new Skill(  0xe9,   "Rabbit Riser",         14,     1,      7,      7,      ""),
            new Skill(  0xea,   "Altered Fate",         14,     1,      7,      7,      ""),
            new Skill(  0xeb,   "Chakra",               14,     1,      7,      7,      ""),
            new Skill(  0xec,   "Arjuna",               14,     1,      7,      7,      ""),
            new Skill(  0xed,   "Sahasrara",            14,     1,      7,      7,      ""),
            new Skill(  0xee,   "Clear Mind",           14,     1,      7,      7,      ""),
            new Skill(  0xef,   "Total Clarity",        14,     1,      7,      7,      ""),
            new Skill(  0xf0,   "Charge Beacon",        14,     1,      7,      7,      ""),
            new Skill(  0xf1,   "Integrity Wave",       14,     1,      7,      7,      ""),
            new Skill(  0xf2,   "Counter Formation",    14,     1,      7,      7,      ""),
            new Skill(  0xf3,   "Hasty Retreat",        14,     1,      7,      7,      ""),
            new Skill(  0xf4,   "Arcana",               14,     1,      7,      7,      ""),
            new Skill(  0xf5,   "Dummy",                14,     1,      7,      7),
            new Skill(  0xf6,   "Dummy",                14,     1,      7,      7),
            new Skill(  0xf7,   "Dummy",                14,     1,      7,      7),
            new Skill(  0xf8,   "Dummy",                14,     1,      7,      7),
            new Skill(  0xf9,   "Dummy",                14,     1,      7,      7),
            new Skill(  0xfa,   "Dummy",                14,     1,      7,      7),           
            new Skill(  0xff,   "Cross Dressing",       14,     1,      7,      7,      ""),            
            new Skill(  0x114,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x115,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x116,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x117,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x118,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x119,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x11a,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x11b,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x11c,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x11d,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x11e,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x11f,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x120,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x121,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x122,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x123,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x124,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x125,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x126,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x127,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x128,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x129,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x12a,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x12b,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x12c,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x142,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x149,  "Move Slowly",          14,     1,      7,      7,      ""),
            new Skill(  0x14a,  "Aim Carefully",        14,     1,      7,      7,      ""),
            new Skill(  0x14b,  "Clench Fist",          14,     1,      7,      7,      ""),
            new Skill(  0x14c,  "Prayer",               14,     1,      7,      7,      ""),
            new Skill(  0x14d,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x14e,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x14f,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x150,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x151,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x152,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x153,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x154,  "Dummy",                14,     56,     7,      7),
            new Skill(  0x155,  "Dummy",                14,     76,     7,      7),
            new Skill(  0x156,  "Dummy",                14,     2,      7,      7),
            new Skill(  0x157,  "Dummy",                14,     11,     7,      7),
            new Skill(  0x158,  "Dummy",                14,     16,     7,      7),
            new Skill(  0x159,  "Dummy",                14,     12,     7,      7),
            new Skill(  0x15a,  "Dummy",                14,     12,     7,      7),
            new Skill(  0x15b,  "Dummy",                14,     12,     7,      7),
            new Skill(  0x15c,  "Dummy",                14,     12,     7,      7),
            new Skill(  0x15d,  "Dummy",                14,     12,     7,      7),
            new Skill(  0x15e,  "Dummy",                14,     4,      7,      7),
            new Skill(  0x15f,  "Dummy",                14,     21,     7,      7),
            new Skill(  0x160,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x161,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x162,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x163,  "Load Bullets",         14,     1,      7,      7,      ""),
            new Skill(  0x164,  "Myriad Shots",         14,     26,     7,      7,      ""),
            new Skill(  0x166,  "Fear",                 14,     1,      7,      7,      ""),
            new Skill(  0x168,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x169,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x16a,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x16b,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x16c,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x16d,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x16e,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x16f,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x170,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x171,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x172,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x173,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x174,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x175,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x176,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x177,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x178,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x179,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x17a,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x17b,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x17c,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x17d,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x17e,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x17f,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x180,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x181,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x182,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x183,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x190,  "Extra Shot",           14,     1,      7,      7),
            new Skill(  0x1c8,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1c9,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1ca,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1cb,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1cc,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1d3,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1d4,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1d5,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1d6,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1d8,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1d9,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1da,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1dc,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1ee,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1ef,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1f0,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1f1,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1f2,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1f3,  "Dummy",                14,     1,      7,      7),
            new Skill(  0x1f4,  "Dummy",                14,     1,      7,      7),

        };
        */
        #endregion skill list



        static List<Skill> skills = new List<Skill>(500);
        static List<Skill> currentList = skills;
        public static List<Skill> GetCurrentList { get { return currentList; } }




        public static void SkillSerializeJson()
        {

            using (FileStream fs = File.OpenWrite(Application.StartupPath + "/skills.json"))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {

                
                jw.Formatting = Formatting.Indented;
                
                JsonSerializer js = new JsonSerializer();
                


                foreach (Skill found in skills)
                {
                    js.Serialize(jw, found);
                }


                jw.Close();

            }
        }


        public static void SkillDeserializeJson()
        {


            using (FileStream fs = File.OpenRead(Application.StartupPath + "/skills.json"))
            using (StreamReader sr = new StreamReader(fs))
            using (JsonTextReader jr = new JsonTextReader(sr))
            {

                jr.SupportMultipleContent = true;


                JsonSerializer js = new JsonSerializer();
                js.Formatting = Formatting.Indented;
                js.Error += new EventHandler<Newtonsoft.Json.Serialization.ErrorEventArgs>(js_Error);
                

                while (jr.Read())
                {
                    skills.Add(js.Deserialize<Skill>(jr));
                }


                jr.Close();

            }

        }
        static void js_Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            MessageBox.Show("skills.json data invalid.", "Error getting skills");
        }


        public static string[] GetNames
        {
            get { return currentList.Select(a => a.Name).OrderBy(b => b).ToArray(); }
        }


        public static void OrganizeSkillList(params object[] args)
        {

            currentList = skills;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].GetType() == typeof(Skill_Type))
                {
                    currentList = currentList.Where(a => a.Type == args[i].ToString()).ToList();
                }
                else if (args[i].GetType() == typeof(short))
                {
                    currentList = currentList.Where(a => a.Cost <= (int)args[i]).ToList();
                }
                else if (args[i].GetType() == typeof(Damage))
                {
                    currentList = currentList.Where(a => a.Damage == args[i].ToString()).ToList();
                }
                else if (args[i].GetType() == typeof(Target))
                {
                    currentList = currentList.Where(a => a.Target == args[i].ToString()).ToList();
                }
            }

        }


        public static string GetSkillInfo(string skill, string info)
        {

            Skill temp = skills.Find(a => a.Name == skill);


            switch (info)
            {
                case "Type":
                    return temp.Type;
                case "MP":
                    return temp.Cost.ToString();
                case "Damage":
                    return temp.Damage;
                case "Targets":
                    return temp.Target;
                case "Desc":
                    return temp.Desc;
                default:
                    return "";
            }


        }


        public static Skill GetSurpriseSkill()
        {

            Skill   temp    = null;
            int     id      = 1;
            bool    found   = false;

            Random rand = new Random();

            

            while (!found)
            {
                
                id = rand.Next(1, 0x1f5);

                
                temp = skills.Find(a => a.ID == id);

                if (temp != null)
                {
                    if (temp.Type != "Dummy")
                    {
                        found = true;
                    }
                }
            }


            return temp;
        }
        


    }
}
