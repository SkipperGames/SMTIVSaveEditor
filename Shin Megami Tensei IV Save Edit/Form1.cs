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
        Weapon[] swords;
        Accessory[] accessories;


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
            
            tabControl2.Selected += TabControl2_Selected;
            //using (var parser = new TextFieldParser(
            //    File.OpenRead(Application.StartupPath + "/SMT4 Item Lists - Swords.csv")))
            //{
            //    parser.Delimiters = new string[1] { "," };
            //    parser.ReadFields();
            //    swords = new Weapon[120];
            //    int id = 0;

            //    while (!parser.EndOfData)
            //    {
            //        string[] line = parser.ReadFields();

            //        Weapon sword = new Weapon();
            //        sword.Name = line[0];
            //        sword.Power = int.Parse(line[1]);
            //        sword.HitsMin = int.Parse(line[2]);
            //        sword.HitsMax = 1;
            //        int.TryParse(line[3], out sword.HitsMax);
            //        sword.IsInaccurate = !string.IsNullOrEmpty(line[4]);
            //        sword.Targets = parseWeaponTarget(line[5][0]);
            //        sword.Effect = StatusAilment.None;
            //        Enum.TryParse(line[6], out sword.Effect);
            //        sword.Wep = parseWeaponType(line[7]);

            //        swords[id] = sword;
            //        id++;
            //    }

            //    parser.Close();
            //}

            //File.WriteAllText(Application.StartupPath + "/swords.json",
            //    JsonConvert.SerializeObject(swords));
        }

        private void TabControl2_Selected(object sender, TabControlEventArgs e)
        {
        }

        private Skills.Target parseWeaponTarget(char input)
        {
            switch (input)
            {
                case 'm':
                    return Target.Multi;
                case 'a':
                    return Target.All;
                default:
                    return Target.Single;
            }
        }

        private Dictionary<string, string> parseAccessoryStats(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            var temp = new Dictionary<string, string>();

            var elements = input.Split(' ', '/');

            List<string> list = new List<string>();
            foreach (var e in elements)
            {
                if (e.Contains(':'))
                {
                    var ea = e.Split(':');
                    foreach (var s in list)
                    {
                        temp.Add(s, ea[1]);
                    }
                    temp.Add(ea[0], ea[1]);

                    list.Clear();
                    continue;
                }
                list.Add(e);
            }

            return temp;
        }

        private WeaponType parseWeaponType(string input)
        {
            switch (input)
            {
                case "am":
                    return WeaponType.Ammo;
                case "bl":
                    return WeaponType.Blunt;
                case "da":
                    return WeaponType.Dagger;
                case "gu":
                    return WeaponType.Firearm;
                case "sp":
                    return WeaponType.Spear;
                default:
                    return WeaponType.Sword;
            }
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
                }
            }

            if (!File.Exists(filename)) return;
            
            foreach (TabPage tp in tabControl2.TabPages) { tp.SuspendLayout(); tp.Controls.Clear(); tp.ResumeLayout(); }
            
            saveToolStripMenuItem.Enabled = true;

            TableLayoutPanel table = new TableLayoutPanel();
            table.Anchor = AnchorStyles.Left;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            table.Width = 320;
            table.Height = 480;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66f));
            table.AutoScroll = true;
            table.HorizontalScroll.Visible = false;
            table.MouseEnter += mouseFocus;
            tabPage7.Controls.Add(table);

            table.SuspendLayout();

            int row = 0;
            for (int i = 0; i < swords.Length; i++)
            {
                swords[i].Amount = BitConverter.ToInt16(data, 0x9a5c + i * 2);
                if (swords[i].Amount == 0) continue;

                LinkLabel lb = new LinkLabel();
                lb.DataBindings.Add("Text", swords[i], "Name");
                table.SetColumn(lb, 0);
                table.SetRow(lb, row);
                table.Controls.Add(lb);

                NumericUpDown nu = new NumericUpDown();
                nu.Maximum = 999;
                nu.DataBindings.Add("Value", swords[i], "Amount");
                nu.BorderStyle = BorderStyle.None;
                nu.Controls[0].Enabled = nu.Controls[0].Visible = false;
                table.SetColumn(nu, 1);
                table.SetRow(nu, row);
                table.Controls.Add(nu);

                row++;
            }

            table.ResumeLayout();
        }

        private void mouseFocus(object sender, EventArgs e)
        {
            (sender as Control).Focus();
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