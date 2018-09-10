using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using SMTIV.Enums;

namespace SMTIV
{
    public partial class Form2 : Form
    {
        public static Form2 Instance { get; private set; }
        static Form2() { Instance = new Form2(); Instance.Initialize(); }

        public Form2()
        {
            InitializeComponent();

            //button1_Click(this, null);
            //button2_Click(this, null);
        }

        private void Initialize()
        {                
            listBox1.ValueMember = "Name";


            var rac = Enum.GetValues(typeof(Race));
            cbx_race.Items.Add("(any)");
            for (var num = rac.GetEnumerator(); num.MoveNext();)
            {
                cbx_race.Items.Add(num.Current);
            }

            var res = Enum.GetValues(typeof(Resistance));
            for (var num = res.GetEnumerator(); num.MoveNext();)
            {
                cbx_phys.Items.Add(num.Current);
                cbx_gun.Items.Add(num.Current);
                cbx_fire.Items.Add(num.Current);
                cbx_ice.Items.Add(num.Current);
                cbx_elec.Items.Add(num.Current);
                cbx_force.Items.Add(num.Current);
                cbx_light.Items.Add(num.Current);
                cbx_dark.Items.Add(num.Current);
            }

            button1_Click(this, null);
            button2_Click(this, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Demon d = listBox1.SelectedItem as Demon;

            label5.Text = string.Format("{0}d {1}h - [{2}] {3}", 
                d.Id, 
                d.Id.ToString("X"), 
                d.Race, 
                d.Name) + Environment.NewLine;

            foreach (var ele in d.Elements)
            {
                string temp = "";

                switch (ele.Key)
                {
                    case SkillType.Phys:
                        temp += "phys:"; break;
                    case SkillType.Gun:
                        temp += "gun:"; break;
                    case SkillType.Fire:
                        temp += "fire:"; break;
                    case SkillType.Ice:
                        temp += "ice:"; break;
                    case SkillType.Elec:
                        temp += "elec:"; break;
                    case SkillType.Force:
                        temp += "forc:"; break;
                    case SkillType.Light:
                        temp += "ligh:"; break;
                    case SkillType.Dark:
                        temp += "dark:"; break;
                }

                temp += Utils.resistShorthand(ele.Value);

                label5.Text += temp;
            }
            label5.Text += Environment.NewLine;

            foreach (var res in d.StatusResistance)
            {
                label5.Text += res.Key + ":" + Utils.resistShorthand(res.Value);
            }
            label5.Text += Environment.NewLine;

            label5.Text += (d.IsGunAttackType ? "Gun " : "Phys ") + d.AttackHitsMin + (d.AttackHitsMax > 0 ? string.Format("~{0}", d.AttackHitsMax) : string.Empty) + string.Format(" hits {0} enemies", d.Targets);
        }        

        private void b_apply_Click(object sender, EventArgs e)
        {
            IEnumerable<Demon> temp = DemonCollection.Demons;
            
            if (cbx_race.SelectedIndex != 0)
                temp = temp.Where(d => d.Race == (Race)cbx_race.SelectedItem);
            
            //
            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Phys] == (Resistance)cbx_phys.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Phys] >= (Resistance)cbx_phys.SelectedItem);

            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Gun] == (Resistance)cbx_gun.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Gun] >= (Resistance)cbx_gun.SelectedItem);

            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Fire] == (Resistance)cbx_fire.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Fire] >= (Resistance)cbx_fire.SelectedItem);

            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Ice] == (Resistance)cbx_ice.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Ice] >= (Resistance)cbx_ice.SelectedItem);

            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Elec] == (Resistance)cbx_elec.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Elec] >= (Resistance)cbx_elec.SelectedItem);

            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Force] == (Resistance)cbx_force.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Force] >= (Resistance)cbx_force.SelectedItem);

            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Light] == (Resistance)cbx_light.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Light] >= (Resistance)cbx_light.SelectedItem);

            if (rb_equal.Checked) temp = temp.Where(d => d.Elements[SkillType.Dark] == (Resistance)cbx_dark.SelectedItem);
            else temp = temp.Where(d => d.Elements[SkillType.Dark] >= (Resistance)cbx_dark.SelectedItem);
            
            switch (cbx_status.SelectedIndex)
            {
                case 2:
                case 3:
                case 4:
                    temp = temp.Where(d => d.StatusResistance.Count == 5);
                    break;
            }

            switch (cbx_status.SelectedIndex)
            {
                case 1:
                    temp = temp.Where(d => d.StatusResistance.Any(r => r.Value > Resistance.Neutral));
                    break;
                case 2:
                    temp = temp.Where(d => d.StatusResistance.All(r => r.Value == Resistance.Resist));
                    break;
                case 3:
                    temp = temp.Where(d => d.StatusResistance.All(r => r.Value > Resistance.Neutral));
                    break;
                case 4:
                    temp = temp.Where(d => d.StatusResistance.All(r => r.Value > Resistance.Resist));
                    break;
                case 5:
                    temp = temp.Where(d => d.StatusResistance.ContainsKey(StatusCondition.Poison) && d.StatusResistance[StatusCondition.Poison] > Resistance.Neutral);
                    break;
                case 6:
                    temp = temp.Where(d => d.StatusResistance.ContainsKey(StatusCondition.Panic) && d.StatusResistance[StatusCondition.Panic] > Resistance.Neutral);
                    break;
                case 7:
                    temp = temp.Where(d => d.StatusResistance.ContainsKey(StatusCondition.Sleep) && d.StatusResistance[StatusCondition.Sleep] > Resistance.Neutral);
                    break;
                case 8:
                    temp = temp.Where(d => d.StatusResistance.ContainsKey(StatusCondition.Bind) && d.StatusResistance[StatusCondition.Bind] > Resistance.Neutral);
                    break;
                case 9:
                    temp = temp.Where(d => d.StatusResistance.ContainsKey(StatusCondition.Sick) && d.StatusResistance[StatusCondition.Sick] > Resistance.Neutral);
                    break;
                default: break;
            }

            //if (num_hitsmax.Value < num_hitsmin.Value) num_hitsmax.Value = num_hitsmin.Value;
            temp = temp.Where(d => d.AttackHitsMin >= num_hitsmin.Value);
            if (num_hitsmax.Value > 0) temp = temp.Where(d => d.AttackHitsMax >= num_hitsmax.Value);

            if (ch_guntype.CheckState == CheckState.Unchecked) temp = temp.Where(d => !d.IsGunAttackType);

            if (!rb_targetany.Checked)
            {
                temp = temp.Where(d => d.Targets == (rb_targetsingle.Checked ? Target.Single : rb_targetmulti.Checked ? Target.Multi : Target.Single));
            }

            listBox1.DataSource = temp.ToArray();
            rb_sortaz_CheckedChanged(temp, null);            
        }

        private void rb_targetall_CheckedChanged(object sender, EventArgs e)
        {
            num_hitsmax.Enabled = !rb_targetall.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            num_hitsmax.Value =
            cbx_race.SelectedIndex =
                cbx_phys.SelectedIndex =
                cbx_gun.SelectedIndex =
                cbx_fire.SelectedIndex =
                cbx_ice.SelectedIndex =
                cbx_elec.SelectedIndex =
                cbx_force.SelectedIndex =
                cbx_light.SelectedIndex =
                cbx_dark.SelectedIndex = 
                cbx_status.SelectedIndex = 0;
            rb_equalgreater.Checked =
                 rb_targetany.Checked = true;
            num_hitsmin.Value = 1;
            ch_guntype.CheckState = CheckState.Indeterminate;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = DemonCollection.Demons;
            rb_sortaz_CheckedChanged(sender, e);
        }

        private void rb_sortaz_CheckedChanged(object sender, EventArgs e)
        {
            var temp = (IEnumerable<Demon>)listBox1.DataSource;

            if (rb_sortaz.Checked) listBox1.DataSource = temp.OrderBy(d => d.Name).ToArray();
            else listBox1.DataSource = temp.OrderBy(d => d.Id).ToArray();
        }
    }
}
