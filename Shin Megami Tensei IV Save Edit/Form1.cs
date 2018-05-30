using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Microsoft.VisualBasic.FileIO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SMTIV.Skills;
using SMTIV.Items;

namespace SMTIV
{
    public partial class Form1 : Form
    {
        const int PLAYER_SAVESTATS_OFFSET = 0x92;
        const int MACCA_OFFSET = 0x10C;
        const int PLAYER_STATS_OFFSET = 0x110;

        const int APP_UNLOCKS_OFFSET = 0x989e;
        const int APP_POINTSTOTAL_OFFSET = 0x98EC;
        const int APP_POINTS_OFFSET = 0x98f0;
        const int VALUABLES_OFFSET = 0x98f8;
        const int EXPENDABLES_OFFSET = 0x99e4;
        const int SWORDS_OFFSET = 0x9a5c;
        const int GUNS_OFFSET = 0x9b4c;
        const int HELMS_OFFSET = 0x9c3c;
        const int UPPER_ARMOR_OFFSET = 0x9d2c;
        const int LOWER_ARMOR_OFFSET = 0x9e1c;
        const int ACCESSORIES_OFFSET = 0x9f0c;
        const int AMMO_OFFSET = 0x9ffc;
        const int RELICS_OFFSET = 0xa060;

        const int PLAY_LOG_OFFSET = 0x1f560;

        byte[] data = new byte[0x24e30];
        string filename;

        Skill[] skills;
        Dictionary<int, Item> valuables;
        Dictionary<int, Item> expendables;
        Weapon[] swords;
        Accessory[] accessories;
        Dictionary<int, Item> relics;

        TableLayoutPanel itemtable;
        SolidBrush brush = new SolidBrush(Color.LightGray);

        public Form1()
        {
            InitializeComponent();

            statusStrip1.Text = "No save file loaded";
            saveToolStripMenuItem.Enabled = false;

            skills = JsonConvert.DeserializeObject<Skill[]>(File.ReadAllText(
                Application.StartupPath + "/skills.json"));

            swords = JsonConvert.DeserializeObject<Weapon[]>(File.ReadAllText(
                Application.StartupPath + "/swords.json"));

            accessories = JsonConvert.DeserializeObject<Accessory[]>(File.ReadAllText(
                Application.StartupPath + "/accessories.json"));
            
            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Valuables.csv")))
            {                
                valuables = new Dictionary<int, Item>();
                int id = 0;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        valuables.Add(id, new Item() { Name = line });
                    }
                    id++;
                }

                sr.Close();
            }

            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Expendables.csv")))
            {
                expendables = new Dictionary<int, Item>();
                int id = 0;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        expendables.Add(id, new Item() { Name = line });
                    }
                    id++;
                }

                sr.Close();
            }

            using (var sr = new StreamReader(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Relics.csv")))
            {
                relics = new Dictionary<int, Item>();
                int id = 0;

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    if (!string.IsNullOrEmpty(line))
                    {
                        relics.Add(id, new Item() { Name = line });
                    }
                    id++;
                }

                sr.Close();
            }

            itemtable = new TableLayoutPanel();
            itemtable.Anchor = AnchorStyles.Left;
            itemtable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            itemtable.Size = new System.Drawing.Size(320, 480);
            itemtable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66f));
            itemtable.AutoScroll = true;
            itemtable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
            tableLayoutPanel1.MouseEnter += (sender, e) => { tableLayoutPanel1.Focus(); };
            itemtable.MouseEnter += (sender, e) => { itemtable.Focus(); };
            tabControl2.Selected += TabControl2_Selected;
            tabControl2.Selecting += (sender, e) => { if (tabControl2.SelectedTab.Controls.Contains(itemtable)) tabControl2.SelectedTab.Controls.Remove(itemtable); };
            tableLayoutPanel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
            tabPage1.Padding = new Padding(0, 0, 0, SystemInformation.HorizontalScrollBarHeight);
            
        }

        private void TabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (data == null) return;

            itemtable.Hide();
            itemtable.SuspendLayout();
            while (itemtable.Controls.Count > 0) { itemtable.Controls[0].Dispose(); }
            itemtable.Controls.Clear();
            itemtable.RowStyles.Clear();
            itemtable.RowCount = 0;

            switch (tabControl2.SelectedTab.Text)
            {
                case "Valuables":
                    for (int i = 0; i < valuables.Count; i++)
                    {
                        var item = valuables.ElementAt(i);
                        item.Value.Amount = BitConverter.ToInt16(data, VALUABLES_OFFSET + item.Key * 2);
                        if (!createItemTableCells(item.Value)) continue;
                    }
                    break;
                case "Expendables":
                    for (int i = 0; i < expendables.Count; i++)
                    {
                        var item = expendables.ElementAt(i);
                        item.Value.Amount = BitConverter.ToInt16(data, EXPENDABLES_OFFSET + item.Key * 2);
                        if (!createItemTableCells(item.Value)) continue;
                    }
                    break;
                case "Swords":
                    for (int i = 0; i < swords.Length; i++)
                    {
                        swords[i].Amount = BitConverter.ToInt16(data, SWORDS_OFFSET + i * 2);
                        if (!createItemTableCells(swords[i])) continue;
                    }
                    break;
                case "Accessories":
                    for (int i = 0; i < accessories.Length; i++)
                    {
                        accessories[i].Amount = BitConverter.ToInt16(data, ACCESSORIES_OFFSET + i * 2);
                        if (!createItemTableCells(accessories[i])) continue;
                    }
                    break;
                case "Relics":
                    for (int i = 0; i < relics.Count; i++)
                    {
                        var item = relics.ElementAt(i);
                        item.Value.Amount = BitConverter.ToInt16(data, RELICS_OFFSET + item.Key * 2);
                        if (!createItemTableCells(item.Value)) continue;
                    }
                    break;
            }

            itemtable.ResumeLayout();
            tabControl2.SelectedTab.Controls.Add(itemtable);
            itemtable.Show();
        }

        private bool createItemTableCells(Item source)
        {
            if (source.Amount == 0) return false;

            LinkLabel lb = new LinkLabel();
            lb.DataBindings.Add("Text", source, "Name");
            itemtable.SetColumn(lb, 0);
            itemtable.SetRow(lb, itemtable.RowCount);
            itemtable.Controls.Add(lb);

            NumericUpDown nu = new NumericUpDown();
            nu.Maximum = 999;
            nu.DataBindings.Add("Value", source, "Amount");
            nu.BorderStyle = BorderStyle.None;
            nu.Controls.RemoveAt(0);
            itemtable.SetColumn(nu, 1);
            itemtable.SetRow(nu, itemtable.RowCount);
            itemtable.Controls.Add(nu);

            itemtable.RowCount++;
            return true;
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
                    data = File.ReadAllBytes(dialog.FileName);
                    statusStrip1.Text = filename = dialog.FileName;
                    
                    saveToolStripMenuItem.Enabled = true;

                    TabControl2_Selected(null, null);
                }
            }
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(filename))
            {
                File.WriteAllBytes(filename, data);
                
                statusStrip1.Text = "Saved " +
                    DateTime.Now.Hour + "h " +
                    DateTime.Now.Minute + "m " +
                    DateTime.Now.Second + "s " +
                    DateTime.Now.Millisecond + "ms";
            }
        }
    }
}