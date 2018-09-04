using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace SMTIV
{
    public partial class ChangeSkillsForm : Form
    {
        public static ChangeSkillsForm Instance { get; private set; }
        static ChangeSkillsForm() { Instance = new ChangeSkillsForm(); Instance.Init(); }
        
        private void Init()
        {
            InitializeComponent();
            FormClosing += (sender, e) => 
            {
                e.Cancel = true;
                Hide();
                Form1.Instance.RefreshSkillDataGridView();
            };
            
            var datasource = (from x in SMTIV.Skills select new KeyValuePair<short, string>(x.ID, x.Name)).ToArray();            
            for (int i = 0; i < 8; i++)
            {
                ConnectData(i, datasource);
            }
        }

        private void ConnectData(int i, KeyValuePair<short, string>[] datasource)
        {
            ComboBox temp = Controls[0].Controls["comboBox" + (i + 1)] as ComboBox;
            
            temp.DisplayMember = "Value";
            temp.ValueMember = "Key";
            temp.DataSource = datasource.ToArray();

            BindingSource b = new BindingSource(Player.Instance, "Skills");
            b.CurrencyManager.Position = i;
            temp.DataBindings.Add(
                "SelectedValue",
                b, "", false,
                DataSourceUpdateMode.OnPropertyChanged);

            temp.DataBindings["SelectedValue"].ControlUpdateMode =
                ControlUpdateMode.OnPropertyChanged;
            temp.SelectedIndex = 0;
            temp.SelectedValueChanged += ComboBox_SelectedValueChanged;
        }

        public void RefreshValues()
        {
            comboBox1.SelectedValue = Player.Instance.Skills[0];
            comboBox2.SelectedValue = Player.Instance.Skills[1];
            comboBox3.SelectedValue = Player.Instance.Skills[2];
            comboBox4.SelectedValue = Player.Instance.Skills[3];
            comboBox5.SelectedValue = Player.Instance.Skills[4];
            comboBox6.SelectedValue = Player.Instance.Skills[5];
            comboBox7.SelectedValue = Player.Instance.Skills[6];
            comboBox8.SelectedValue = Player.Instance.Skills[7];
        }
        
        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var temp = sender as ComboBox;
            Label lb = Controls[0].Controls[(string)temp.Tag] as Label;
            var s = SMTIV.Skills.First(x => x.ID == (short)temp.SelectedValue);

            lb.Text = string.Format("id:{0}d {1}h | mp:{2}\npower:{3} type:{4} target(s):{5}\n{6}",
                s.ID, s.ID.ToString("X"), s.Cost,
                s.Damage, s.Type, s.Target,
                s.Desc);

            temp.DataBindings["SelectedValue"].WriteValue();
        }
    }
}