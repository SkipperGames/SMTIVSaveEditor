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
        Dictionary<short, Weapon> swords;
        Dictionary<short, Accessory> accessories;
        Dictionary<int, Item> relics;
        ListView itemList;
        AppInfo[] appdata;
        Player player = new Player();

        public Form1()
        {
            InitializeComponent();

            saveToolStripMenuItem.Enabled = false;

            skills = JsonConvert.DeserializeObject<Skill[]>(File.ReadAllText(
                Application.StartupPath + "/skills.json"));

            var swordsjson = JsonConvert.DeserializeObject<Weapon[]>(File.ReadAllText(
                Application.StartupPath + "/swords.json"));
            for (short i = 0x3d; i - 0x3d < swordsjson.Length; i++)
            {
                swords.Add(i, swordsjson[i]);
            }

            var accjson = JsonConvert.DeserializeObject<Accessory[]>(File.ReadAllText(
                Application.StartupPath + "/accessories.json"));
            for (short i = 0x295; i - 0x295 < accjson.Length; i++)
            {
                accessories.Add(i, accjson[i]);
            }

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
                NumericUpDown asdf = new NumericUpDown();
                
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

            nud_level.DataBindings.Add("Value", player, "Level");
            nud_exp.DataBindings.Add("Value", player, "Exp");
            nud_macca.DataBindings.Add("Value", player, "Macca");
            
            var appnames = File.ReadAllLines(Application.StartupPath + "/apps.txt");
            appdata = new AppInfo[appnames.Length];
            for (int i = 0; i < appnames.Length; i++)
                appdata[i] = new AppInfo() { Name = appnames[i] };

            tableLayoutPanel1.MouseEnter += (sender, e) => { tableLayoutPanel1.Focus(); };
            tableLayoutPanel1.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);

            itemList = new ListView();
            itemList.View = View.Details;
            itemList.Anchor = AnchorStyles.Left;
            //itemList.Dock = DockStyle.Top | DockStyle.Left;
            itemList.Size = new System.Drawing.Size(320, 480);
            itemList.Columns.Add("Name", 200);
            itemList.Columns.Add("Amount", 80);
            itemList.Padding = new Padding(0, 0, 
                SystemInformation.VerticalScrollBarWidth, SystemInformation.HorizontalScrollBarHeight);
            //itemList.MouseEnter += (sender, e) => { itemList.Focus(); };
            tabControl2.Selected += TabControl2_Selected;
            tabControl2.Selecting += (sender, e) => { if (tabControl2.SelectedTab.Controls.Contains(itemList)) tabControl2.SelectedTab.Controls.Remove(itemList); };
        }

        private void TabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (data == null) return;

            itemList.SuspendLayout();
            itemList.Items.Clear();

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
                    for (int i = 0; i < swords.Count; i++)
                    {
                        var item = swords.ElementAt(i);
                        item.Value.Amount = BitConverter.ToInt16(data, SWORDS_OFFSET + item.Key * 2);
                        if (!createItemTableCells(item.Value)) continue;
                    }
                    break;
                case "Accessories":
                    for (int i = 0; i < accessories.Count; i++)
                    {
                        var item = accessories.ElementAt(i);
                        item.Value.Amount = BitConverter.ToInt16(data, ACCESSORIES_OFFSET + item.Key * 2);
                        if (!createItemTableCells(item.Value)) continue;
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
            itemList.ResumeLayout();
            tabControl2.SelectedTab.Controls.Add(itemList);
        }

        private bool createItemTableCells(Item source)
        {
            if (source.Amount == 0) return false;
            itemList.Items.Add(new ListViewItem(
                new string[] {
                    string.IsNullOrEmpty(source.Name) ? "???" : source.Name,
                    source.Amount.ToString() })).Tag = source;
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
                    filename = dialog.FileName;
                    data = File.ReadAllBytes(dialog.FileName);
                    saveToolStripMenuItem.Enabled = true;

                    TabControl2_Selected(null, null);
                    player.Data = data;
                    setAppdataFromMemory();
                }
            }
        }

        private void setAppdataFromMemory()
        {
            int offset = APP_UNLOCKS_OFFSET;
            var e = appdata.GetEnumerator();
            for (; offset < APP_UNLOCKS_OFFSET + 0x22; offset++)
            {
                byte b = data[offset];
                for (int i = 0; i < 8; i++)
                {
                    if (!e.MoveNext()) return;
                    if ((b & (1 << i)) != 0)
                    {
                        (e.Current as AppInfo).Unlocked = true;
                    }
                }
            }
        }
        
        private void unlockApp(int index)
        {
            var s = index % 8;
            var b = data[APP_UNLOCKS_OFFSET + (index / 8)];
            var d = (byte)(b | (1 << s));
            data[APP_UNLOCKS_OFFSET + (index / 8)] = d;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(filename))
            {
                File.WriteAllBytes(filename, data);
            }
        }
    }
}