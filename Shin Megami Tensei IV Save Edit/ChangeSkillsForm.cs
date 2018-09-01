using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SMTIV.Skills;
namespace SMTIV
{
    public partial class ChangeSkillsForm : Form
    {
        public static ChangeEquipForm Instance { get; private set; }
        static ChangeSkillsForm() { Instance = new ChangeEquipForm(); Instance.Init(); }

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

            var datasource = 

            comboBox1.DataSource = (from x in SMTIV.Swords select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox2.DataSource = (from x in SMTIV.Guns select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox3.DataSource = (from x in SMTIV.Bullets select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox4.DataSource = (from x in SMTIV.Helms select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox5.DataSource = (from x in SMTIV.UpperArmor select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox6.DataSource = (from x in SMTIV.LowerArmor select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();
            comboBox7.DataSource = (from x in SMTIV.Accessories select new KeyValuePair<short, string>(x.Key, x.Value.Name)).ToArray();

            BindingSource bindingsource = new BindingSource(Player.Instance, "Skills");

            comboBox1.DataBindings.Add("SelectedValue", Player.Instance, "Sword");
            comboBox2.DataBindings.Add("SelectedValue", Player.Instance, "Gun");
            comboBox3.DataBindings.Add("SelectedValue", Player.Instance, "Ammo");
            comboBox4.DataBindings.Add("SelectedValue", Player.Instance, "Helm");
            comboBox5.DataBindings.Add("SelectedValue", Player.Instance, "Top");
            comboBox6.DataBindings.Add("SelectedValue", Player.Instance, "Bottom");
            comboBox7.DataBindings.Add("SelectedValue", Player.Instance, "Accessory");

            comboBox1.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox2.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox3.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox4.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox5.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox6.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox7.SelectedValueChanged += ComboBox_SelectedValueChanged;
            comboBox8.SelectedValueChanged += ComboBox_SelectedValueChanged;
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
        }
    }
}