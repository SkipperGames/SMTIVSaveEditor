using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json;

using SMTIV.Items;
using SMTIV.Skills;
using SMTIV.Enums;


namespace SMTIV
{
    public class Appdata
    {
        public string Name { get; set; }
        public bool Unlocked { get; set; }
    }

    static class SMTIV
    {
        public static Dictionary<short, Item> Expendables { get; private set; } =  new Dictionary<short, Item>();//60
        public static Dictionary<short, Item> Relics { get; private set; } =  new Dictionary<short, Item>();//700
        public static Dictionary<short, Item> Valuables { get; private set; } =  new Dictionary<short, Item>();//120
        public static Dictionary<short, Sword> Swords { get; private set; } =  new Dictionary<short, Sword>();//120
        public static Dictionary<short, Weapon> Guns { get; private set; } =  new Dictionary<short, Weapon>();//120
        public static Dictionary<short, Bullet> Bullets { get; private set; } =  new Dictionary<short, Bullet>();//50
        public static Dictionary<short, Armor> Helms { get; private set; } =  new Dictionary<short, Armor>();//120
        public static Dictionary<short, UpperArmor> UpperArmor { get; private set; } =  new Dictionary<short, UpperArmor>();//120
        public static Dictionary<short, Armor> LowerArmor { get; private set; } =  new Dictionary<short, Armor>();//120
        public static Dictionary<short, Accessory> Accessories { get; private set; } =  new Dictionary<short, Accessory>();//120
        public static Skill[] Skills { get; private set; }//500
        //public static List<Demon> Demons { get; private set; } = new List<Demon>();//1124
        public static BindingList<Appdata> Apps { get; private set; }

        static SMTIV()
        {
            short id = 0x00;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Expendables.csv")))
            {
                while (!sr.EndOfStream)
                {
                    Expendables.Add(id, new Item() { Name = sr.ReadLine() });
                    id++;
                }

                sr.Close();
            }

            id = 0x00;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Relics.csv")))
            {
                while (!sr.EndOfStream)
                {
                    var n = sr.ReadLine();
                    if (!string.IsNullOrEmpty(n))
                    {
                        Relics.Add(id, new Item() { Name = n });
                    }
                    id++;
                }

                sr.Close();
            }

            id = 0x00;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Valuables.csv")))
            {
                while (!sr.EndOfStream)
                {
                    Valuables.Add(id, new Item() { Name = sr.ReadLine() });
                    id++;
                }

                sr.Close();
            }

            id = 0x3d;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Swords.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Sword temp = new Sword();
                    temp.Name = line[0];
                    temp.Power = int.Parse(line[1]);
                    temp.HitsMin = int.Parse(line[2]);
                    int.TryParse(line[3], out temp.HitsMax);
                    temp.IsInaccurate = line[4].Length > 0;
                    temp.Targets = (Target)Enum.Parse(typeof(Target), line[5]);
                    Enum.TryParse(line[6], out temp.Effect);
                    temp.WeaponType = (WeaponType)Enum.Parse(typeof(WeaponType), line[7]);
                    Swords.Add(id, temp);
                    id++;
                }

                sr.Close();
            }

            id = 0xb5;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Guns.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Weapon temp = new Weapon();
                    temp.Name = line[0];
                    temp.Power = int.Parse(line[1]);
                    temp.HitsMin = int.Parse(line[2]);
                    int.TryParse(line[3], out temp.HitsMax);
                    temp.Targets = (Target)Enum.Parse(typeof(Target), line[4]);
                    Guns.Add(id, temp);
                    id++;
                }

                sr.Close();
            }

            id = 0x12d;//helms
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Helms.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Armor temp = new Armor();
                    temp.Name = line[0];
                    temp.Hp = int.Parse(line[1]);
                    temp.Stats = Utils.statsToArray(line[2]);
                    Helms.Add(id, temp);
                    id++;
                }

                sr.Close();
            }

            id = 0x1a5;//tops            
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Upper Body.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    UpperArmor temp = new UpperArmor();
                    temp.Name = line[0];
                    temp.Hp = int.Parse(line[1]);
                    temp.Elements = Utils.elementsToDictionary(line[2]);
                    UpperArmor.Add(id, temp);
                    id++;
                }

                sr.Close();
            }

            id = 0x21d;//bottoms
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Lower Body.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Armor temp = new Armor();
                    temp.Name = line[0];
                    temp.Hp = int.Parse(line[1]);
                    temp.Stats = Utils.statsToArray(line[2]);
                    LowerArmor.Add(id, temp);
                    id++;
                }

                sr.Close();
            }

            id = 0x295;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Accessories.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Accessory temp = new Accessory();
                    temp.Name = line[0];
                    temp.Mp = int.Parse(line[1]);
                    temp.Elements = Utils.elementsToDictionary(line[2]);
                    temp.Effect = line[3];
                    Accessories.Add(id, temp);
                    id++;
                }

                sr.Close();
            }
            
            id = 0x30D;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Bullets.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Bullet temp = new Bullet();
                    temp.Name = line[0];
                    temp.Power = int.Parse(line[1]);
                    temp.Type = (SkillType)Enum.Parse(typeof(SkillType), line[2]);
                    temp.Effect = StatusCondition.None;
                    Enum.TryParse(line[3], out temp.Effect);
                    Bullets.Add(id, temp);
                    id++;
                }

                sr.Close();
            }

            Skills = JsonConvert.DeserializeObject<Skill[]>(File.ReadAllText(
                Application.StartupPath + "/skills.json"));

            id = 1;
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Demon List - IV.csv")))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');

                    Demon temp = new Demon();
                    temp.Id = id;
                    temp.Race = string.IsNullOrEmpty(line[0]) ? Race.None :
                        line[0] == "???" ? Race.Unknown :
                        (Race)Enum.Parse(typeof(Race), line[0], true);
                    if (!string.IsNullOrEmpty(line[1]))
                    {
                        temp.Name = line[1][0].ToString().ToUpper() + line[1].Substring(1);
                    }
                    else temp.Name = "---";
                    temp.Elements = Utils.skilltypesToDictionary(line[2]);
                    temp.StatusResistance = Utils.statusToDictionary(line[3]);
                    temp.IsGunAttackType = line[4].Length > 0;
                    int.TryParse(line[5], out temp.AttackHitsMin);
                    int.TryParse(line[6], out temp.AttackHitsMax);
                    switch (line[7])
                    {
                        case "m":
                            temp.Targets = Target.Multi; break;
                        case "a":
                            temp.Targets = Target.All; break;
                        case "s":
                        case "":
                            break;
                        default:
                            throw new Exception(id.ToString());
                    }
                    id++;
                }

                sr.Close();
            }

            Apps = new BindingList<Appdata>(
                (from s in File.ReadAllLines(Application.StartupPath + "/apps.txt")
                 select new Appdata() { Name = s, Unlocked = false }).ToList());
        }
    }
}
