using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using SMTIV.Items;
using SMTIV.Skills;
namespace SMTIV
{
    public partial class ChangeEquipForm : Form
    {
        public static ChangeEquipForm Instance { get; private set; }
        static ChangeEquipForm() { Instance = new ChangeEquipForm(); Instance.Init(); }

        private void Init()
        {
            InitializeComponent();
            FormClosing += (sender, e) => { Hide(); e.Cancel = true; };

            comboBox1.ValueMember =
                comboBox2.ValueMember =
                comboBox3.ValueMember =
                comboBox4.ValueMember =
                comboBox5.ValueMember =
                comboBox6.ValueMember =
                comboBox7.ValueMember = "Key";

            comboBox1.DisplayMember =
                comboBox2.DisplayMember =
                comboBox3.DisplayMember =
                comboBox4.DisplayMember =
                comboBox5.DisplayMember =
                comboBox6.DisplayMember =
                comboBox7.DisplayMember = "Value";
            
            comboBox1.DataSource = (from x in SMTIV.Swords select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox2.DataSource = (from x in SMTIV.Guns select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox3.DataSource = (from x in SMTIV.Bullets select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox4.DataSource = (from x in SMTIV.Helms select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox5.DataSource = (from x in SMTIV.UpperArmor select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox6.DataSource = (from x in SMTIV.LowerArmor select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox7.DataSource = (from x in SMTIV.Accessories select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();

            comboBox1.DataBindings.Add("SelectedValue", Player.Instance, "Sword");
            comboBox2.DataBindings.Add("SelectedValue", Player.Instance, "Gun");
            comboBox3.DataBindings.Add("SelectedValue", Player.Instance, "Ammo");
            comboBox4.DataBindings.Add("SelectedValue", Player.Instance, "Helm");
            comboBox5.DataBindings.Add("SelectedValue", Player.Instance, "Top");
            comboBox6.DataBindings.Add("SelectedValue", Player.Instance, "Bottom");
            comboBox7.DataBindings.Add("SelectedValue", Player.Instance, "Accessory");

            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
            comboBox2.SelectedValueChanged += ComboBox2_SelectedValueChanged;
            comboBox3.SelectedValueChanged += ComboBox3_SelectedValueChanged;
            comboBox4.SelectedValueChanged += ComboBox4_SelectedValueChanged;
            comboBox5.SelectedValueChanged += ComboBox5_SelectedValueChanged;
            comboBox6.SelectedValueChanged += ComboBox6_SelectedValueChanged;
            comboBox7.SelectedValueChanged += ComboBox7_SelectedValueChanged;
        }

        private void ComboBox7_SelectedValueChanged(object sender, EventArgs e)
        {
            short id = (short)comboBox7.SelectedValue;
            var it = SMTIV.Accessories[id];
            label7.Text = string.Format("id:{0} HP:{1}\n",
                string.Format("{0}d|{1}h", id, id.ToString("X")),
                it.Mp);

            if (it.Elements != null)
            {
                foreach (var r in it.Elements)
                {
                    label7.Text += r.Key + ":" + Utils.resistShorthand(r.Value);
                }
                label7.Text += Environment.NewLine;
            }
            label7.Text += it.Effect;
        }

        private void ComboBox6_SelectedValueChanged(object sender, EventArgs e)
        {
            short id = (short)comboBox6.SelectedValue;
            var it = SMTIV.LowerArmor[id];
            label6.Text = string.Format("id:{0} HP:{1}\nSt|Dx|Ma|Ag|Lu\n{2}|{3}|{4}|{5}|{6}",
                string.Format("{0}d|{1}h", id, id.ToString("X")),
                it.Hp,
                it.Stats[0].ToString("00"), it.Stats[1].ToString("00"), it.Stats[2].ToString("00"),
                it.Stats[3].ToString("00;-#;00"), 
                it.Stats[4].ToString("00"));
        }

        private void ComboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            short id = (short)comboBox5.SelectedValue;
            var it = SMTIV.UpperArmor[id];
            label5.Text = string.Format("id:{0} HP:{1}\n",
                string.Format("{0}d|{1}h", id, id.ToString("X")), it.Hp);

            foreach (var r in it.Elements)
            {
                label5.Text += r.Key + ":" + Utils.resistShorthand(r.Value);
            }
        }

        private void ComboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            short id = (short)comboBox4.SelectedValue;
            var it = SMTIV.Helms[id];
            label4.Text = string.Format("id:{0} HP:{1}\nSt|Dx|Ma|Ag|Lu\n{2}|{3}|{4}|{5}|{6}",
                string.Format("{0}d|{1}h", id, id.ToString("X")),
                it.Hp,
                it.Stats[0].ToString("00"), it.Stats[1].ToString("00"), it.Stats[2].ToString("00"), 
                it.Stats[3].ToString("00;-#;00"), 
                it.Stats[4].ToString("00"));
        }

        private void ComboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            short id = (short)comboBox3.SelectedValue;
            var it = SMTIV.Bullets[id];
            label3.Text = string.Format("id:{0} {1} pow:{2}\n{3}",
                string.Format("{0}d|{1}h", id, id.ToString("X")),
                it.Type,
                it.Power,
                it.Effect > 0 ? "Chance to inflict " + it.Effect: string.Empty);
        }

        private void ComboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            short id = (short)comboBox2.SelectedValue;
            var it = SMTIV.Guns[id];
            label2.Text = string.Format("id:{0} pow:{1}\n{2}{3} hit{4} {5}",
                string.Format("{0}d|{1}h", id, id.ToString("X")),
                it.Power,
                it.HitsMin,
                it.HitsMax > 1 ? "~" + it.HitsMax : string.Empty,
                it.HitsMin + it.HitsMax > 1 ? "s" : string.Empty,
                it.Targets == Target.Enemies ? "All Enemies" : it.Targets + " target(s)");
        }

        private void ComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            short id = (short)comboBox1.SelectedValue;
            var it = SMTIV.Swords[id];
            label1.Text = string.Format("id:{0} ({1}) pow:{2}\nPhys {3}{4} hit{5} {6}\n{7}",
                string.Format("{0}d|{1}h", id, id.ToString("X")),
                it.WeaponType,
                it.Power,
                it.HitsMin,
                it.HitsMax > 1 ? "~" + it.HitsMax : string.Empty,
                it.HitsMin + it.HitsMax > 1 ? "s" : string.Empty,
                it.Targets == Target.Enemies ? "All Enemies" : it.Targets + " target(s)",
                it.IsInaccurate ? "Low Accuracy," : string.Empty);

            if (it.Effect > 0)
            {
                label1.Text += string.Format("{0} to inflict {1}",
                    it.IsInaccurate ? " chance" : "Chance",
                    it.Effect);
            }
        }
    }
}