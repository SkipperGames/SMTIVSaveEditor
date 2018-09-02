using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SMTIV
{
    public partial class ChangeSkillsForm : Form
    {
        public static ChangeSkillsForm Instance
        {
            get;
            private set;
        }
        static ChangeSkillsForm()
        {
            Instance = new ChangeSkillsForm(); 
            Instance.Init();
        }

        private void Init()
        {
            InitializeComponent();
            FormClosing += (sender, e) => { Hide(); e.Cancel = true; };
            
            var datasource = (from x in SMTIV.Skills select new KeyValuePair<short, string>(x.ID, x.Name)).ToArray();

            for (int i = 0; i < 8; i++)
            {
                ConnectData(i, datasource);
            }
        }

        private void ConnectData(int i, object datasource)
        {
            ComboBox temp = Controls[0].Controls["comboBox" + (i+1)] as ComboBox;
            temp.DisplayMember = "Value";
            temp.ValueMember = "Key";
            temp.DataSource = datasource;
            var bindingsource = new BindingSource(Player.Instance, "Skills");
            bindingsource.CurrencyManager.Position = i;
            temp.DataBindings.Add("SelectedValue", bindingsource, "id");
            temp.SelectedValueChanged += ComboBox_SelectedValueChanged;
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}