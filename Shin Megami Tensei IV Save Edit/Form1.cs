using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SMTIV.Items;

namespace SMTIV
{
    public partial class Form1 : Form
    {
        const int DEMON_STOCK_OFFSET = 0x19c;
        const int PARTY_IDS_OFFSET = 0x91fc;
        const int APP_UNLOCKS_OFFSET = 0x989e;
        const int APP_POINTSTOTAL_OFFSET = 0x98ec;
        const int APP_POINTS_OFFSET = 0x98f0;
        const int VALUABLES_OFFSET = 0x98f4;
        const int EXPENDABLES_OFFSET = 0x99e4;
        const int SWORDS_OFFSET = 0x9a5c;
        const int GUNS_OFFSET = 0x9b4c;
        const int HELMS_OFFSET = 0x9c3c;
        const int UPPER_ARMOR_OFFSET = 0x9d2c;
        const int LOWER_ARMOR_OFFSET = 0x9e1c;
        const int ACCESSORIES_OFFSET = 0x9f0c;
        const int AMMO_OFFSET = 0x9ffc;
        const int RELICS_OFFSET = 0xa060;
        const int ESTOMA_FLAG_OFFSET = 0xb700;
        const int ESTOMA_STEPS_OFFSET = 0xb704;
        const int PLAY_LOG_OFFSET = 0x1f560;

        byte[] data = new byte[0x24e30];
        string filename;

        ListView itemList;

        public static Form1 Instance { get; private set; }

        public Form1()
        {
            InitializeComponent();
            Instance = this;

            saveToolStripMenuItem.Enabled = false;

            b_changeEquips.Click += clickChangeEquip;
            b_changeSkill.Click += clickChangeSkill;

            nud_level.DataBindings.Add("Value", Player.Instance, "Level");
            nud_exp.DataBindings.Add("Value", Player.Instance, "Exp");
            nud_alignment.DataBindings.Add("Value", Player.Instance, "Alignment");
            nud_macca.DataBindings.Add("Value", Player.Instance, "Macca");

            llb_sword.DataBindings.Add("Text", ChangeEquipForm.Instance.Controls[0].Controls["comboBox1"], "Text");
            llb_gun.DataBindings.Add("Text", ChangeEquipForm.Instance.Controls[0].Controls["comboBox2"], "Text");
            llb_ammo.DataBindings.Add("Text", ChangeEquipForm.Instance.Controls[0].Controls["comboBox3"], "Text");
            llb_helm.DataBindings.Add("Text", ChangeEquipForm.Instance.Controls[0].Controls["comboBox4"], "Text");
            llb_top.DataBindings.Add("Text", ChangeEquipForm.Instance.Controls[0].Controls["comboBox5"], "Text");
            llb_bottom.DataBindings.Add("Text", ChangeEquipForm.Instance.Controls[0].Controls["comboBox6"], "Text");
            llb_accessory.DataBindings.Add("Text", ChangeEquipForm.Instance.Controls[0].Controls["comboBox7"], "Text");

            nud_hp.DataBindings.Add("Value", Player.Instance, "Hp");
            nud_mp.DataBindings.Add("Value", Player.Instance, "Mp");
            nud_st.DataBindings.Add("Value", Player.Instance, "St");
            nud_dx.DataBindings.Add("Value", Player.Instance, "Dx");
            nud_ma.DataBindings.Add("Value", Player.Instance, "Ma");
            nud_ag.DataBindings.Add("Value", Player.Instance, "Ag");
            nud_lu.DataBindings.Add("Value", Player.Instance, "Lu");

            gv_skills.AutoGenerateColumns = false;
            var gbsrc = (from Control c in ChangeSkillsForm.Instance.Controls[0].Controls
                         where c is ComboBox select (ComboBox)c).ToList();
            gv_skills.DataSource = new BindingList<ComboBox>(gbsrc);
            gv_skills.DataBindingComplete += (sender, e) => { ChangeSkillsForm.Instance.RefreshValues(); };
            gv_skills.RowsAdded += (sender, e) => { gv_skills.Height += gv_skills.Rows[e.RowIndex].Height; };

            gv_apps.AutoGenerateColumns = false;
            gv_apps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;            
            gv_apps.DataSource = SMTIV.Apps;

            itemList = new ListView();
            itemList.View = View.Details;
            itemList.Anchor = AnchorStyles.Left;
            itemList.Dock = DockStyle.Fill;
            itemList.Columns.Add("Name", 180);
            itemList.Columns.Add("Amount", 100);
            itemList.FullRowSelect = itemList.MultiSelect = true;
            //itemList.KeyDown += ItemList_KeyDown;
            b_setItemAmount.Click += setItemAmount;
            splitContainer1.Panel1.Controls.Add(itemList);
            splitContainer1.SplitterDistance = 320 + splitContainer1.SplitterWidth;
            splitContainer1.Panel1.Padding = new Padding(0, 0,
                SystemInformation.VerticalScrollBarWidth, SystemInformation.HorizontalScrollBarHeight);
            tabControl2.Selected += TabControl2_Selected;
            KeyPreview = true;

            //tableLayoutPanel1.MouseEnter += (sender, e) => { tableLayoutPanel1.Focus(); };
            tableLayoutPanel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth,
                SystemInformation.HorizontalScrollBarHeight);
        }

        private void TabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (data == null) return;

            tabControl2.SuspendLayout();
            tabControl2.SelectedTab.Controls.Remove(splitContainer1);
            itemList.SuspendLayout();
            itemList.Items.Clear();

            switch (tabControl2.SelectedTab.Text)
            {
                case "Expendables":
                    for (var num = SMTIV.Expendables.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Relics":
                    for (var num = SMTIV.Relics.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Valuables":
                    for (var num = SMTIV.Valuables.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Swords":
                    for (var num = SMTIV.Swords.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Guns":
                    for (var num = SMTIV.Guns.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Bullets":
                    for (var num = SMTIV.Bullets.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Helmets":
                    for (var num = SMTIV.Helms.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Upper Body":
                    for (var num = SMTIV.UpperArmor.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Lower Body":
                    for (var num = SMTIV.LowerArmor.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
                case "Accessories":
                    for (var num = SMTIV.Accessories.GetEnumerator(); num.MoveNext();)
                    {
                        createItemTableCells(num.Current.Value);
                    }
                    break;
            }

            itemList.ResumeLayout();
            tabControl2.SelectedTab.Controls.Add(splitContainer1);
            tabControl2.ResumeLayout();
        }

        private void createItemTableCells(Item source)
        {
            itemList.Items.Add(new ListViewItem(
                new string[] {
                    string.IsNullOrEmpty(source.Name) ? "???" : source.Name,
                    source.Amount.ToString() })).Tag = source;
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.DefaultExt = "SAV";
                dialog.Filter = "SMT4 SDF Save data (*.SAV)|*.SAV|All files (*.*)|*.*";
                dialog.Title = "Open a SMT4 save";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filename = dialog.FileName;
                    data = File.ReadAllBytes(dialog.FileName);
                    saveToolStripMenuItem.Enabled = true;

                    Player.Instance.Data = data;
                    ChangeEquipForm.Instance.Refresh();
                    //ChangeSkillsForm.Instance.Refresh();
                    gv_skills.Refresh();
                    setAppdataFromData();
                    setInventoryFromData();
                    
                    toolStripStatusLabel1.Text = filename;
                }
            }
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(filename))
            {
                //Player.Instance.Data.CopyTo(data, 0);
                CheckInventoryForEquips();
                setDataFromAppdata();
                setDataFromInventory();

                File.WriteAllBytes(filename, data);
            }
        }

        private void CheckInventoryForEquips()
        {
            var temp = (from Control c in ChangeEquipForm.Instance.Controls[0].Controls
                        where c is ComboBox
                        select (ComboBox)c).ToArray();
            if (SMTIV.Swords[(short)temp[0].SelectedValue].Amount == 0)
                SMTIV.Swords[(short)temp[0].SelectedValue].Amount = 1;
            if (SMTIV.Guns[(short)temp[1].SelectedValue].Amount == 0)
                SMTIV.Guns[(short)temp[1].SelectedValue].Amount = 1;
            if (SMTIV.Bullets[(short)temp[2].SelectedValue].Amount == 0)
                SMTIV.Bullets[(short)temp[2].SelectedValue].Amount = 1;
            if (SMTIV.Helms[(short)temp[3].SelectedValue].Amount == 0)
                SMTIV.Helms[(short)temp[3].SelectedValue].Amount = 1;
            if (SMTIV.UpperArmor[(short)temp[4].SelectedValue].Amount == 0)
                SMTIV.UpperArmor[(short)temp[4].SelectedValue].Amount = 1;
            if (SMTIV.LowerArmor[(short)temp[5].SelectedValue].Amount == 0)
                SMTIV.LowerArmor[(short)temp[5].SelectedValue].Amount = 1;
            if (SMTIV.Accessories[(short)temp[6].SelectedValue].Amount == 0)
                SMTIV.Accessories[(short)temp[6].SelectedValue].Amount = 1;
        }

        public void RefreshSkillDataGridView()
        {
            gv_skills.Refresh();
        }

        private void setAppdataFromData()
        {
            var e = SMTIV.Apps.GetEnumerator();
            for (int offset = APP_UNLOCKS_OFFSET; offset < APP_UNLOCKS_OFFSET + 0x22; offset++)
            {
                byte b = data[offset];
                for (int i = 0; i < 8; i++)
                {
                    if (!e.MoveNext()) return;
                    (e.Current as Appdata).Unlocked = (b & (1 << i)) != 0 ? true : false;
                }
            }

            nud_appPoints.Value = BitConverter.ToInt16(data, APP_POINTS_OFFSET);
        }

        private void setDataFromAppdata()
        {
            var e = SMTIV.Apps.GetEnumerator();
            for (int offset = APP_UNLOCKS_OFFSET; offset < APP_UNLOCKS_OFFSET + 0x22; offset++)
            {
                byte b = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (!e.MoveNext()) return;
                    if ((e.Current as Appdata).Unlocked)
                    {
                        
                        data[offset] = b = (byte)(b | (1 << i));
                    }
                }
            }

            BitConverter.GetBytes((short)nud_appPoints.Value).CopyTo(data, APP_POINTS_OFFSET);
        }

        private void b_unlockApps_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < gv_apps.RowCount; i++)
            //{
            //    (gv_apps.Rows[i].Cells["appunlocks"] as DataGridViewCheckBoxCell).Value = true;
            //}
            for (var num = SMTIV.Apps.GetEnumerator(); num.MoveNext();)
            {
                num.Current.Unlocked = true;
            }
            BitConverter.GetBytes((short)9999).CopyTo(data, APP_POINTSTOTAL_OFFSET);
            gv_apps.DataSource = SMTIV.Apps;
            gv_apps.Refresh();
        }

        private void setInventoryFromData()
        {
            for (var num = SMTIV.Expendables.GetEnumerator(); num.MoveNext();)
            {
                num.Current.Value.Amount = BitConverter.ToInt16(
                    data, EXPENDABLES_OFFSET + num.Current.Key * 2);
            }

            for (var num = SMTIV.Relics.GetEnumerator(); num.MoveNext();)
            {
                num.Current.Value.Amount = BitConverter.ToInt16(
                    data, RELICS_OFFSET + num.Current.Key * 2);
            }

            for (var num = SMTIV.Valuables.GetEnumerator(); num.MoveNext();)
            {
                num.Current.Value.Amount = BitConverter.ToInt16(
                    data, VALUABLES_OFFSET + num.Current.Key * 2);
            }

            for (var i = 0; i < SMTIV.Swords.Count; i++)
            {
                SMTIV.Swords.ElementAt(i).Value.Amount = BitConverter.ToInt16(
                    data, SWORDS_OFFSET + i * 2);
            }

            for (var i = 0; i < SMTIV.Guns.Count; i++)
            {
                SMTIV.Guns.ElementAt(i).Value.Amount = BitConverter.ToInt16(
                    data, GUNS_OFFSET + i * 2);
            }

            for (var i = 0; i < SMTIV.Bullets.Count; i++)
            {
                SMTIV.Bullets.ElementAt(i).Value.Amount = BitConverter.ToInt16(
                    data, AMMO_OFFSET + i * 2);
            }

            for (var i = 0; i < SMTIV.Helms.Count; i++)
            {
                SMTIV.Helms.ElementAt(i).Value.Amount = BitConverter.ToInt16(
                    data, HELMS_OFFSET + i * 2);
            }

            for (var i = 0; i < SMTIV.UpperArmor.Count; i++)
            {
                SMTIV.UpperArmor.ElementAt(i).Value.Amount = BitConverter.ToInt16(
                    data, UPPER_ARMOR_OFFSET + i * 2);
            }

            for (var i = 0; i < SMTIV.LowerArmor.Count; i++)
            {
                SMTIV.LowerArmor.ElementAt(i).Value.Amount = BitConverter.ToInt16(
                    data, LOWER_ARMOR_OFFSET + i * 2);
            }

            for (var i = 0; i < SMTIV.Accessories.Count; i++)
            {
                SMTIV.Accessories.ElementAt(i).Value.Amount = BitConverter.ToInt16(
                    data, ACCESSORIES_OFFSET + i * 2);
            }
        }

        private void setDataFromInventory()
        {
            for (var num = SMTIV.Expendables.GetEnumerator(); num.MoveNext();)
            {
                BitConverter.GetBytes(num.Current.Value.Amount).CopyTo(
                    data, EXPENDABLES_OFFSET + num.Current.Key * 2);
            }

            for (var num = SMTIV.Relics.GetEnumerator(); num.MoveNext();)
            {
                BitConverter.GetBytes(num.Current.Value.Amount).CopyTo(
                    data, RELICS_OFFSET + num.Current.Key * 2);
            }

            for (var num = SMTIV.Valuables.GetEnumerator(); num.MoveNext();)
            {
                BitConverter.GetBytes(num.Current.Value.Amount).CopyTo(
                    data, VALUABLES_OFFSET + num.Current.Key * 2);
            }

            for (var i = 0; i < 120; i++)
            {
                 BitConverter.GetBytes(SMTIV.Swords.ElementAt(i).Value.Amount).CopyTo(
                    data, SWORDS_OFFSET + i * 2);
            }

            for (var i = 0; i < 120; i++)
            {
                BitConverter.GetBytes(SMTIV.Guns.ElementAt(i).Value.Amount).CopyTo(
                    data, GUNS_OFFSET + i * 2);
            }

            for (var i = 0; i < 50; i++)
            {
                BitConverter.GetBytes(SMTIV.Bullets.ElementAt(i).Value.Amount).CopyTo(
                    data, AMMO_OFFSET + i * 2);
            }

            for (var i = 0; i < 120; i++)
            {
                BitConverter.GetBytes(SMTIV.Helms.ElementAt(i).Value.Amount).CopyTo(
                    data, HELMS_OFFSET + i * 2);
            }

            for (var i = 0; i < 120; i++)
            {
                BitConverter.GetBytes(SMTIV.UpperArmor.ElementAt(i).Value.Amount).CopyTo(
                    data, UPPER_ARMOR_OFFSET + i * 2);
            }

            for (var i = 0; i < 120; i++)
            {
                BitConverter.GetBytes(SMTIV.LowerArmor.ElementAt(i).Value.Amount).CopyTo(
                    data, LOWER_ARMOR_OFFSET + i * 2);
            }

            for (var i = 0; i < 120; i++)
            {
                BitConverter.GetBytes(SMTIV.Accessories.ElementAt(i).Value.Amount).CopyTo(
                    data, ACCESSORIES_OFFSET + i * 2);
            }
        }

        private void setItemAmount(object sender, EventArgs e)
        {
            var selected = itemList.SelectedItems;            
            foreach (ListViewItem it in selected)
            {
                (it.Tag as Item).Amount = (short)num_itemAmount.Value;
                it.SubItems[1].Text = num_itemAmount.Value.ToString();
            }
        }

        private void ItemList_KeyDown(object sender, KeyEventArgs e)
        {
            short a = 0;
            if (e.KeyCode == Keys.Left)
                a = -1;
            else if (e.KeyCode == Keys.Right) a = 1;
            foreach (ListViewItem it in itemList.SelectedItems)
            {
                (it.Tag as Item).Amount += a;
                it.SubItems[1].Text = num_itemAmount.Value.ToString();
            }
        }
        
        private void demonSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.Instance.Show();
        }

        private void clickChangeEquip(object sender, EventArgs e)
        {
            //sword, gun, ammo, helm, top, bottom, acc
            ChangeEquipForm.Instance.Show();
        }

        private void clickChangeSkill(object sender, EventArgs e)
        {
            ChangeSkillsForm.Instance.Show();
        }
    }
}