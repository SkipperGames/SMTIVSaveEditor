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
        byte[] data;
        string filename;

        Skill[] skills;
        Dictionary<int, Item> valuables;
        Dictionary<int, Item> expendables;
        Weapon[] swords;
        Accessory[] accessories;

        TableLayoutPanel itemtable;


        public Form1()
        {
            InitializeComponent();

            saveToolStripMenuItem.Enabled = false;

            skills = JsonConvert.DeserializeObject<Skill[]>(File.ReadAllText(
                Application.StartupPath + "/skills.json"));

            swords = JsonConvert.DeserializeObject<Weapon[]>(File.ReadAllText(
                Application.StartupPath + "/swords.json"));

            accessories = JsonConvert.DeserializeObject<Accessory[]>(File.ReadAllText(
                Application.StartupPath + "/accessories.json"));

            //tabControl2.Selected += TabControl2_Selected;
            using (var parser = new TextFieldParser(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Valuables.csv")))
            {
                parser.Delimiters = new string[1] { "," };
                valuables = new Dictionary<int, Item>();
                int id = 0;

                while (!parser.EndOfData)
                {
                    string[] line = parser.ReadFields();

                    if (!string.IsNullOrEmpty(line[0]))
                    {
                        valuables.Add(id, new Item() { Name = line[0] });
                    }
                    id++;
                }

                parser.Close();
            }

            using (var parser = new TextFieldParser(
                File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Expendables.csv")))
            {
                parser.Delimiters = new string[1] { "," };
                expendables = new Dictionary<int, Item>();
                int id = 0;

                while (!parser.EndOfData)
                {
                    string[] line = parser.ReadFields();

                    if (!string.IsNullOrEmpty(line[0]))
                    {
                        expendables.Add(id, new Item() { Name = line[0] });
                    }
                    id++;
                }

                parser.Close();
            }

            tabControl2.Selected += TabControl2_Selected;
            tabControl2.Selecting += (sender, e) => { if (tabControl2.SelectedTab.Controls.Contains(itemtable)) tabControl2.SelectedTab.Controls.Remove(itemtable); };
            itemtable = new TableLayoutPanel();
            itemtable.Anchor = AnchorStyles.Left;
            itemtable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            itemtable.Size = new System.Drawing.Size(320, 480);
            itemtable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66f));
            itemtable.AutoScroll = true;
            itemtable.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
            itemtable.MouseEnter += (sender, e) => { itemtable.Focus(); };
        }

        private void TabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (!File.Exists(filename)) return;

            itemtable.SuspendLayout();
            itemtable.Controls.Clear();

            switch (tabControl2.SelectedTab.Text)
            {
                case "Valuables":
                    for (int i = 0, row = 0; i < valuables.Count; i++)
                    {
                        valuables[i].Amount = BitConverter.ToInt16(data, 0x98f8 + i * 2);
                        if (!createItemTableCells(valuables[i], row)) continue;
                        row++;
                    }
                    break;
            }

            itemtable.ResumeLayout();
            tabControl2.SelectedTab.Controls.Add(itemtable);
        }

        private bool createItemTableCells(Item source, int row)
        {
            if (source.Amount == 0) return false;

            LinkLabel lb = new LinkLabel();
            lb.DataBindings.Add("Text", source, "Name");
            itemtable.SetColumn(lb, 0);
            itemtable.SetRow(lb, row);
            itemtable.Controls.Add(lb);

            NumericUpDown nu = new NumericUpDown();
            nu.Maximum = 999;
            nu.DataBindings.Add("Value", source, "Amount");
            nu.BorderStyle = BorderStyle.None;
            nu.Controls.RemoveAt(0);
            itemtable.SetColumn(nu, 1);
            itemtable.SetRow(nu, row);
            itemtable.Controls.Add(nu);

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
                    filename = dialog.FileName;
                    
                    saveToolStripMenuItem.Enabled = true;                    
                }
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
    }
}