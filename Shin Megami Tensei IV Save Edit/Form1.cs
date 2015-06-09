using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using Skills;

namespace SMTIV
{


    public partial class Form1 : Form
    {

        
        byte[] data;
        string filename;


        #region enums
        Skill_Type[] types = new Skill_Type[]
        {
            Skill_Type.Fire,
            Skill_Type.Ice,
            Skill_Type.Elec,
            Skill_Type.Force,
            Skill_Type.Almighty,
            Skill_Type.Dark,
            Skill_Type.Light,
            Skill_Type.Ailment,
            Skill_Type.Healing,
            Skill_Type.Status,
            Skill_Type.Support,
            Skill_Type.Phys,
            Skill_Type.Gun,
            Skill_Type.Auto,
            Skill_Type.Dummy,
        };

        Damage[] damage = new Damage[]
        {
            Damage.Weak,
            Damage.Medium,
            Damage.Heavy,
            Damage.Severe,
            Damage.Fixed,
            Damage.KO,
            Damage.Zero,
            Damage.Unknown,
            Damage.Mega,
        };

        Target[] target = new Target[]
        {
            Target.Single,
            Target.Multi,
            Target.Enemies,
            Target.Self,
            Target.Ally,
            Target.Allies,
            Target.Unknown,
        };
        #endregion enums



        public Skill_Type[] GetTypes { get { return types; } }
        public Damage[] GetDamage { get { return damage; } }
        public Target[] GetTarget { get { return target; } }


        public FlowLayoutPanel FlowPanel { get { return flowLayoutPanel1; } }


        static AddFilterButton addfilterbutton = new AddFilterButton();




        public Form1()
        {

            InitializeComponent();


            saveToolStripMenuItem.Enabled = false;


            SkillCollection.SkillDeserializeJson();


            comboBox1.DataSource = SkillCollection.GetNames;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1.SelectedIndex = 0;
            comboBox1_SelectedIndexChanged(this, null);


            AddFilterButton.ParentForm = this;
            ComboFilter.ParentForm = this;
            ComboTypeFilter.ParentForm = this;
            NumericCostFilter.form1 = this;
            ComboDamageFilter.ParentForm = this;
            ComboTargetFilter.ParentForm = this;


            flowLayoutPanel1.Controls.Add(addfilterbutton);


        }




        private List<string> filters = new List<string>(4)
        {
            "Damage",
            "MP Cost",
            "Targets",
            "Type",
        };

        public string[] Filters { get { return filters.ToArray(); } }

        private List<object> specifiedfilters = new List<object>(4);


        public void CreateFilterButton(Control other)
        {

            flowLayoutPanel1.Controls.Remove(other);


            if (filters.Count > 1)
            {
                flowLayoutPanel1.Controls.Add(new ComboFilter());
            }
            else
            {
                switch (filters[0])
                {
                    case "Type":
                        flowLayoutPanel1.Controls.Add(new ComboTypeFilter());
                        break;
                    case "MP Cost":
                        flowLayoutPanel1.Controls.Add(new NumericCostFilter());
                        break;
                    case "Damage":
                        flowLayoutPanel1.Controls.Add(new ComboDamageFilter());
                        break;
                    case "Targets":
                        flowLayoutPanel1.Controls.Add(new ComboTargetFilter());
                        break;
                    default:
                        return;
                }
            }

        }


        public void AddFilter(object args)
        {


            if (args.GetType() == typeof(Skill_Type))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(Skill_Type));
                specifiedfilters.Add((Skill_Type)args);
            }
            else if (args.GetType() == typeof(int))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(int));
                specifiedfilters.Add((int)args);
            }
            else if (args.GetType() == typeof(Damage))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(Damage));
                specifiedfilters.Add((Damage)args);
            }
            else if (args.GetType() == typeof(Target))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(Target));
                specifiedfilters.Add((Target)args);
            }
            else return;

            SkillCollection.OrganizeSkillList(specifiedfilters.ToArray());
            comboBox1.DataSource = SkillCollection.GetNames;
        }


        public void RemoveFilter(object args, Control other)
        {

            flowLayoutPanel1.Controls.Remove(other);
            flowLayoutPanel1.Refresh();


            if (args.GetType() == typeof(Skill_Type))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(Skill_Type));
                filters.Add("Type");
            }
            else if (args.GetType() == typeof(int))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(int));
                filters.Add("MP Cost");
            }
            else if (args.GetType() == typeof(Damage))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(Damage));
                filters.Add("Damage");
            }
            else if (args.GetType() == typeof(Target))
            {
                specifiedfilters.RemoveAll(a => a.GetType() == typeof(Target));
                filters.Add("Targets");
            }


            if (!flowLayoutPanel1.Controls.Contains(addfilterbutton))
            {
                flowLayoutPanel1.Controls.Add(addfilterbutton);
            }

            filters.Sort();


            SkillCollection.OrganizeSkillList(specifiedfilters.ToArray());
            comboBox1.DataSource = SkillCollection.GetNames;
        }


        public void OnTypeFilterAdded(ComboFilter filter)
        {

            flowLayoutPanel1.Controls.Add(new ComboTypeFilter());
            if (filters.Count > 1)
            {
                flowLayoutPanel1.Controls.Add(addfilterbutton);
            }

            flowLayoutPanel1.Controls.Remove(filter);
            filters.Remove("Type");
        }


        public void OnCostFilterAdded(ComboFilter filter)
        {

            flowLayoutPanel1.Controls.Add(new NumericCostFilter());
            if (filters.Count > 1)
            {
                flowLayoutPanel1.Controls.Add(addfilterbutton);
            }

            flowLayoutPanel1.Controls.Remove(filter);
            filters.Remove("MP Cost");
        }


        public void OnDamageFilterAdded(ComboFilter filter)
        {

            flowLayoutPanel1.Controls.Add(new ComboDamageFilter());
            if (filters.Count > 1)
            {
                flowLayoutPanel1.Controls.Add(addfilterbutton);
            }

            flowLayoutPanel1.Controls.Remove(filter);
            filters.Remove("Damage");
        }


        public void OnTargetFilterAdded(ComboFilter filter)
        {

            flowLayoutPanel1.Controls.Add(new ComboTargetFilter());

            if (filters.Count > 1)
            {
                flowLayoutPanel1.Controls.Add(addfilterbutton);
            }

            flowLayoutPanel1.Controls.Remove(filter);
            filters.Remove("Targets");
        }


        private void CreateSurpriseSkill()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(addfilterbutton);


            filters.Clear();
            filters.Add("Damage");
            filters.Add("MP Cost");
            filters.Add("Targets");
            filters.Add("Type");

            specifiedfilters.Clear();


            comboBox1.SelectedItem = (string)SkillCollection.GetSurpriseSkill().Name;
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            boxtype.Text = SkillCollection.GetSkillInfo((string)comboBox1.SelectedItem, "Type");
            boxmp.Text = SkillCollection.GetSkillInfo((string)comboBox1.SelectedItem, "MP");
            boxdamage.Text = SkillCollection.GetSkillInfo((string)comboBox1.SelectedItem, "Damage");
            boxtargets.Text = SkillCollection.GetSkillInfo((string)comboBox1.SelectedItem, "Targets");
            boxdesc.Text = SkillCollection.GetSkillInfo((string)comboBox1.SelectedItem, "Desc");
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "SAV";
            dialog.Filter = "SMT4 SDF Save data (*.SAV)|*.SAV|All files (*.*)|*.*";
            dialog.Title = "Open a SMT4 save";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                data = File.ReadAllBytes(dialog.FileName);
                filename = dialog.FileName;

                saveToolStripMenuItem.Enabled = true;
            }

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (data != null)
            {
                File.WriteAllBytes(filename, data);

                statusStrip1.Text = "Saved " +
                    DateTime.Now.Hour + "h " +
                    DateTime.Now.Minute + "m " +
                    DateTime.Now.Second + "s " +
                    DateTime.Now.Millisecond + "ms";
            }

        }

                
        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (specifiedfilters.Count == 0)
            {
                this.CreateSurpriseSkill();
            }
            else if (MessageBox.Show("Clear filters and generate random skill?",
                    "Message",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.CreateSurpriseSkill();
            }
        }

        
        private void saveitems_Click(object sender, EventArgs e)
        {


            openToolStripMenuItem_Click(this, e);


            int offset = 0x0;


            if (plotcheckbox.Checked)
            {

                offset = 0x98f8;
                for (short i = 0; i < 47; i++)
                {
                    data[offset] = 0x01;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (valuablecheckbox.Checked)
            {

                offset = 0x9958;
                for (short i = 0; i < 70; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (valuablecheckbox.Checked)
            {

                offset = 0x9958;
                for (short i = 0; i < 70; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (expendablecheckbox.Checked)
            {

                offset = 0x99e4;
                for (short i = 0; i < 60; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (swordscheckbox.Checked)
            {

                offset = 0x9a5c;
                for (short i = 0; i < 120; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (gunscheckbox.Checked)
            {

                offset = 0x9b4c;
                for (short i = 0; i < 120; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (helmcheckbox.Checked)
            {


                offset = 0x9c3c;

                data[offset] = 0x00;
                data[offset + 1] = 0x00;

                offset += 2;
                for (short i = 1; i < 99; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }

                data[offset] = 0x00;
                data[offset + 1] = 0x00;

                offset += 2;
                for (short i = 1; i < 21; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (uppercheckbox.Checked)
            {

                offset = 0x9d2c;
                for (short i = 0; i < 120; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (lowercheckbox.Checked)
            {

                offset = 0x9e1c;
                for (short i = 0; i < 120; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (acccheckbox.Checked)
            {

                offset = 0x9f0c;
                for (short i = 0; i < 120; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (bulletscheckbox.Checked)
            {

                offset = 0x9ffc;
                for (short i = 0; i < 50; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }

            if (relicscheckbox.Checked)
            {

                offset = 0xa060;
                for (short i = 0; i < 1000; i++)
                {
                    data[offset] = 0x63;
                    data[offset + 1] = 0x00;

                    offset += 2;
                }
            }



            File.WriteAllBytes(filename, data);


        }


    }


    public class AddFilterButton : System.Windows.Forms.Button
    {


        public static Form1 ParentForm;



        public AddFilterButton()
        {
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "button";
            this.Size = new System.Drawing.Size(75, 23);
            this.TabIndex = 0; ;
            this.Text = "Add Filter";
            this.UseVisualStyleBackColor = true;
            this.MouseClick += OnAddFilterButtonClicked;
        }


        private void OnAddFilterButtonClicked(object sender, EventArgs e)
        {
            ParentForm.CreateFilterButton(this);
        }


    }

    public class RemoveFilterButton : System.Windows.Forms.Button
    {


        public RemoveFilterButton()
        {
            this.Name = "button";
            this.Size = new System.Drawing.Size(21, 21);
            this.TabIndex = 0;
            this.Text = "X";
            this.UseVisualStyleBackColor = true;
        }

    }

    public class ComboFilter : System.Windows.Forms.ComboBox
    {

        public static Form1 ParentForm;



        public ComboFilter(params object[] args)
        {
            this.FormattingEnabled = true;
            this.DataSource = ParentForm.Filters;
            this.Name = "comboBox";
            this.Size = new System.Drawing.Size(80, 21);
            this.TabIndex = 0;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            if (this.Items.Count != 0) this.SelectedIndex = 0;
            this.SelectedIndexChanged += ComboFilter_SelectedIndexChanged;

        }


        private void ComboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Items.Count < 2) return;


            switch ((string)SelectedItem)
            {
                case "Type":
                    ParentForm.OnTypeFilterAdded(this);
                    break;
                case "MP Cost":
                    ParentForm.OnCostFilterAdded(this);
                    break;
                case "Damage":
                    ParentForm.OnDamageFilterAdded(this);
                    break;
                case "Targets":
                    ParentForm.OnTargetFilterAdded(this);
                    break;
                default:
                    return;
            }

        }

    }

    public class ComboTypeFilter : System.Windows.Forms.ComboBox
    {

        public static Form1 ParentForm;

        static RemoveFilterButton button = new RemoveFilterButton();




        public ComboTypeFilter()
        {
            this.FormattingEnabled = true;
            this.DataSource = ParentForm.GetTypes;
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "comboBox";
            this.Size = new System.Drawing.Size(80, 21);
            this.TabIndex = 0;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            if (this.Items.Count != 0) this.SelectedIndex = 0;
            this.SelectedIndexChanged += ComboTypeFilter_SelectedIndexChanged;



            button.MouseClick += OnFilterRemoved;
            ParentForm.FlowPanel.Controls.Add(button);


            ParentForm.AddFilter(Skill_Type.Fire);
        }

        protected virtual void ComboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentForm.AddFilter(SelectedItem);
        }

        public void OnFilterRemoved(object sender, EventArgs e)
        {
            ParentForm.RemoveFilter(SelectedItem, this);
            ParentForm.FlowPanel.Controls.Remove(button);
        }

    }

    public class NumericCostFilter : System.Windows.Forms.NumericUpDown
    {

        public static Form1 form1;

        static RemoveFilterButton button = new RemoveFilterButton();



        public NumericCostFilter()
        {
            this.Maximum = new decimal(new int[] {
            251,
            0,
            0,
            0});
            this.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Name = "numericUpDown";
            this.Size = new System.Drawing.Size(64, 20);
            this.TabIndex = 1;
            this.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Value = 251;
            this.ValueChanged += OnValueChanged;


            button.MouseClick += OnFilterRemoved;
            form1.FlowPanel.Controls.Add(button);



            form1.AddFilter(251);
        }

        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            form1.AddFilter((int)this.Value);
        }

        public void OnFilterRemoved(object sender, EventArgs e)
        {
            form1.RemoveFilter(0, this);
            form1.FlowPanel.Controls.Remove(button);
        }

    }

    public class ComboDamageFilter : System.Windows.Forms.ComboBox
    {

        public static Form1 ParentForm;

        static RemoveFilterButton button = new RemoveFilterButton();




        public ComboDamageFilter()
        {
            this.FormattingEnabled = true;
            this.DataSource = ParentForm.GetDamage;
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "comboBox";
            this.Size = new System.Drawing.Size(80, 21);
            this.TabIndex = 0;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.SelectedIndexChanged += ComboTypeFilter_SelectedIndexChanged;


            button.MouseClick += OnFilterRemoved;
            ParentForm.FlowPanel.Controls.Add(button);


            ParentForm.AddFilter(Damage.Weak);
        }

        protected virtual void ComboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentForm.AddFilter(SelectedItem);
        }

        public void OnFilterRemoved(object sender, EventArgs e)
        {
            ParentForm.RemoveFilter(SelectedItem, this);
            ParentForm.FlowPanel.Controls.Remove(button);
        }

    }

    public class ComboTargetFilter : System.Windows.Forms.ComboBox
    {

        public static Form1 ParentForm;

        static RemoveFilterButton button = new RemoveFilterButton();




        public ComboTargetFilter()
        {
            this.FormattingEnabled = true;
            this.DataSource = ParentForm.GetTarget;
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "comboBox";
            this.Size = new System.Drawing.Size(80, 21);
            this.TabIndex = 0;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            if (this.Items.Count != 0) this.SelectedIndex = 0;
            this.SelectedIndexChanged += ComboTypeFilter_SelectedIndexChanged;



            button.MouseClick += OnFilterRemoved;
            ParentForm.FlowPanel.Controls.Add(button);


            ParentForm.AddFilter(Target.Single);
        }

        protected virtual void ComboTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParentForm.AddFilter(SelectedItem);
        }

        public void OnFilterRemoved(object sender, EventArgs e)
        {
            ParentForm.RemoveFilter(SelectedItem, this);
            ParentForm.FlowPanel.Controls.Remove(button);
        }

    }
}