using System;
using System.Collections.Generic;
using System.Linq;

using SMTIV.Skills;
using SMTIV.Items;

namespace SMTIV
{
    static class Utils
    {
        public static string resistShorthand(Resistance res)
        {
            string temp = "";

            switch (res)
            {
                case Resistance.Resist: temp = "rs|"; break;
                case Resistance.Null: temp = "nu|"; break;
                case Resistance.Repel: temp = "rp|"; break;
                case Resistance.Drain: temp = "dr|"; break;
                case Resistance.Weak: temp = "wk|"; break;
                default: temp = "--|"; break;
            }
            return temp;
        }

        public static Dictionary<string, Resistance> elementsToDictionary(string input)
        {
            //Gun:Repel Light/Dark:Null
            if (string.IsNullOrEmpty(input)) return null;

            Dictionary<string, Resistance> temp = new Dictionary<string, Resistance>();
            string[] line = input.Split(' ');
            foreach (string s in line)
            {
                var sts = s.Remove(s.IndexOf(':')).Split('/');
                var res = s.Split(':')[1];

                if (string.IsNullOrEmpty(res))
                {

                }

                foreach (string st in sts)
                {
                    temp.Add(st, (Resistance)Enum.Parse(typeof(Resistance), res));
                }
            }

            return temp;
        }

        public static Dictionary<StatusCondition, Resistance> statusToDictionary(string input)
        {
            //Gun:Repel Light/Dark:Null          
            Dictionary<StatusCondition, Resistance> temp = new Dictionary<StatusCondition, Resistance>();
            if (string.IsNullOrEmpty(input)) return temp;

            string[] line = input.Split(' ');
            foreach (string s in line)
            {
                var sts = s.Remove(s.IndexOf(':')).Split('/');
                var res = s.Split(':')[1];

                if (string.IsNullOrEmpty(res))
                {

                }

                foreach (string st in sts)
                {
                    temp.Add(
                        (StatusCondition)Enum.Parse(typeof(StatusCondition), st, true),
                        (Resistance)Enum.Parse(typeof(Resistance), res, true));
                }
            }

            return temp;
        }

        public static Dictionary<SkillType, Resistance> skilltypesToDictionary(string input)
        {
            Dictionary<SkillType, Resistance> temp = new Dictionary<SkillType, Resistance>();
            temp.Add(SkillType.Phys, Resistance.Neutral);
            temp.Add(SkillType.Gun, Resistance.Neutral);
            temp.Add(SkillType.Fire, Resistance.Neutral);
            temp.Add(SkillType.Ice, Resistance.Neutral);
            temp.Add(SkillType.Elec, Resistance.Neutral);
            temp.Add(SkillType.Force, Resistance.Neutral);
            temp.Add(SkillType.Light, Resistance.Neutral);
            temp.Add(SkillType.Dark, Resistance.Neutral);

            // rp/wk/nu//nu/rs
            if (string.IsNullOrEmpty(input)) return temp;
            var ele = input.Split('/');
            bool reverse = input[input.Length - 1] != '/';
            if (reverse)
            {
                temp = temp.Reverse().ToDictionary(x => x.Key, x => x.Value);
                ele = ele.Reverse().ToArray();
            }
            var num = temp.GetEnumerator();
            var temp1 = temp.ToDictionary(x => x.Key, y => y.Value);

            for (int i = 0; num.MoveNext() && i < ele.Length; i++)
            {
                string s = ele[i];
                Resistance res = Resistance.Neutral;

                if (!string.IsNullOrEmpty(s))
                {
                    switch (s)
                    {
                        case "wk":
                            res = Resistance.Weak;
                            break;
                        case "rs":
                            res = Resistance.Resist;
                            break;
                        case "nu":
                            res = Resistance.Null;
                            break;
                        case "rp":
                            res = Resistance.Repel;
                            break;
                        case "dr":
                            res = Resistance.Drain;
                            break;
                        default:
                            throw new Exception(s);
                    }

                    temp1[num.Current.Key] = res;
                }
            }

            return (reverse ? temp1 = temp1.Reverse().ToDictionary(x => x.Key, y => y.Value) : temp1);
        }

        public static int[] statsToArray(string input)
        {
            //Gun:Repel Light/Dark:Null
            if (string.IsNullOrEmpty(input)) return null;

            int[] temp = new int[5];
            string[] line = input.Split('/');

            temp[0] = int.Parse(line[0]);
            temp[1] = int.Parse(line[1]);
            temp[2] = int.Parse(line[2]);
            temp[3] = int.Parse(line[3]);
            temp[4] = int.Parse(line[4]);

            return temp;
        }
    }
}
