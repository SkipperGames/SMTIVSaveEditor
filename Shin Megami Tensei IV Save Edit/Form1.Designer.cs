namespace SMTIV
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.boxdesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxtargets = new System.Windows.Forms.TextBox();
            this.boxdamage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.boxmp = new System.Windows.Forms.TextBox();
            this.boxtype = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.acccheckbox = new System.Windows.Forms.CheckBox();
            this.lowercheckbox = new System.Windows.Forms.CheckBox();
            this.uppercheckbox = new System.Windows.Forms.CheckBox();
            this.helmcheckbox = new System.Windows.Forms.CheckBox();
            this.bulletscheckbox = new System.Windows.Forms.CheckBox();
            this.gunscheckbox = new System.Windows.Forms.CheckBox();
            this.swordscheckbox = new System.Windows.Forms.CheckBox();
            this.expendablecheckbox = new System.Windows.Forms.CheckBox();
            this.valuablecheckbox = new System.Windows.Forms.CheckBox();
            this.relicscheckbox = new System.Windows.Forms.CheckBox();
            this.saveitems = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.plotcheckbox = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(472, 390);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.boxdesc);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.boxtargets);
            this.tabPage1.Controls.Add(this.boxdamage);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.boxmp);
            this.tabPage1.Controls.Add(this.boxtype);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Player";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 115;
            this.button2.Text = "Surprise Me";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // boxdesc
            // 
            this.boxdesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxdesc.Location = new System.Drawing.Point(133, 260);
            this.boxdesc.Name = "boxdesc";
            this.boxdesc.ReadOnly = true;
            this.boxdesc.Size = new System.Drawing.Size(325, 13);
            this.boxdesc.TabIndex = 114;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "Targets";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Damage";
            // 
            // boxtargets
            // 
            this.boxtargets.BackColor = System.Drawing.SystemColors.Control;
            this.boxtargets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxtargets.Location = new System.Drawing.Point(311, 241);
            this.boxtargets.Name = "boxtargets";
            this.boxtargets.ReadOnly = true;
            this.boxtargets.Size = new System.Drawing.Size(64, 13);
            this.boxtargets.TabIndex = 111;
            // 
            // boxdamage
            // 
            this.boxdamage.BackColor = System.Drawing.SystemColors.Control;
            this.boxdamage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxdamage.Location = new System.Drawing.Point(241, 241);
            this.boxdamage.Name = "boxdamage";
            this.boxdamage.ReadOnly = true;
            this.boxdamage.Size = new System.Drawing.Size(64, 13);
            this.boxdamage.TabIndex = 110;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "MP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 108;
            this.label3.Text = "Type";
            // 
            // boxmp
            // 
            this.boxmp.BackColor = System.Drawing.SystemColors.Control;
            this.boxmp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxmp.Location = new System.Drawing.Point(203, 241);
            this.boxmp.Name = "boxmp";
            this.boxmp.ReadOnly = true;
            this.boxmp.Size = new System.Drawing.Size(32, 13);
            this.boxmp.TabIndex = 106;
            // 
            // boxtype
            // 
            this.boxtype.BackColor = System.Drawing.SystemColors.Control;
            this.boxtype.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxtype.Location = new System.Drawing.Point(133, 241);
            this.boxtype.Name = "boxtype";
            this.boxtype.ReadOnly = true;
            this.boxtype.Size = new System.Drawing.Size(64, 13);
            this.boxtype.TabIndex = 105;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Filters";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 238);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 101;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 309);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(452, 49);
            this.flowLayoutPanel1.TabIndex = 101;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 100;
            this.button1.Text = "Add Skill";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(452, 198);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(464, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stock";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.plotcheckbox);
            this.tabPage3.Controls.Add(this.acccheckbox);
            this.tabPage3.Controls.Add(this.lowercheckbox);
            this.tabPage3.Controls.Add(this.uppercheckbox);
            this.tabPage3.Controls.Add(this.helmcheckbox);
            this.tabPage3.Controls.Add(this.bulletscheckbox);
            this.tabPage3.Controls.Add(this.gunscheckbox);
            this.tabPage3.Controls.Add(this.swordscheckbox);
            this.tabPage3.Controls.Add(this.expendablecheckbox);
            this.tabPage3.Controls.Add(this.valuablecheckbox);
            this.tabPage3.Controls.Add(this.relicscheckbox);
            this.tabPage3.Controls.Add(this.saveitems);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(464, 364);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Items";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // acccheckbox
            // 
            this.acccheckbox.AutoSize = true;
            this.acccheckbox.Location = new System.Drawing.Point(0, 190);
            this.acccheckbox.Name = "acccheckbox";
            this.acccheckbox.Size = new System.Drawing.Size(83, 17);
            this.acccheckbox.TabIndex = 10;
            this.acccheckbox.Text = "Accessories";
            this.acccheckbox.UseVisualStyleBackColor = true;
            // 
            // lowercheckbox
            // 
            this.lowercheckbox.AutoSize = true;
            this.lowercheckbox.Location = new System.Drawing.Point(0, 167);
            this.lowercheckbox.Name = "lowercheckbox";
            this.lowercheckbox.Size = new System.Drawing.Size(82, 17);
            this.lowercheckbox.TabIndex = 9;
            this.lowercheckbox.Text = "Lower Body";
            this.lowercheckbox.UseVisualStyleBackColor = true;
            // 
            // uppercheckbox
            // 
            this.uppercheckbox.AutoSize = true;
            this.uppercheckbox.Location = new System.Drawing.Point(0, 144);
            this.uppercheckbox.Name = "uppercheckbox";
            this.uppercheckbox.Size = new System.Drawing.Size(82, 17);
            this.uppercheckbox.TabIndex = 8;
            this.uppercheckbox.Text = "Upper Body";
            this.uppercheckbox.UseVisualStyleBackColor = true;
            // 
            // helmcheckbox
            // 
            this.helmcheckbox.AutoSize = true;
            this.helmcheckbox.Location = new System.Drawing.Point(-1, 121);
            this.helmcheckbox.Name = "helmcheckbox";
            this.helmcheckbox.Size = new System.Drawing.Size(55, 17);
            this.helmcheckbox.TabIndex = 7;
            this.helmcheckbox.Text = "Helms";
            this.helmcheckbox.UseVisualStyleBackColor = true;
            // 
            // bulletscheckbox
            // 
            this.bulletscheckbox.AutoSize = true;
            this.bulletscheckbox.Location = new System.Drawing.Point(-1, 213);
            this.bulletscheckbox.Name = "bulletscheckbox";
            this.bulletscheckbox.Size = new System.Drawing.Size(57, 17);
            this.bulletscheckbox.TabIndex = 6;
            this.bulletscheckbox.Text = "Bullets";
            this.bulletscheckbox.UseVisualStyleBackColor = true;
            // 
            // gunscheckbox
            // 
            this.gunscheckbox.AutoSize = true;
            this.gunscheckbox.Location = new System.Drawing.Point(0, 98);
            this.gunscheckbox.Name = "gunscheckbox";
            this.gunscheckbox.Size = new System.Drawing.Size(51, 17);
            this.gunscheckbox.TabIndex = 5;
            this.gunscheckbox.Text = "Guns";
            this.gunscheckbox.UseVisualStyleBackColor = true;
            // 
            // swordscheckbox
            // 
            this.swordscheckbox.AutoSize = true;
            this.swordscheckbox.Location = new System.Drawing.Point(0, 74);
            this.swordscheckbox.Name = "swordscheckbox";
            this.swordscheckbox.Size = new System.Drawing.Size(61, 17);
            this.swordscheckbox.TabIndex = 4;
            this.swordscheckbox.Text = "Swords";
            this.swordscheckbox.UseVisualStyleBackColor = true;
            // 
            // expendablecheckbox
            // 
            this.expendablecheckbox.AutoSize = true;
            this.expendablecheckbox.Location = new System.Drawing.Point(0, 50);
            this.expendablecheckbox.Name = "expendablecheckbox";
            this.expendablecheckbox.Size = new System.Drawing.Size(87, 17);
            this.expendablecheckbox.TabIndex = 3;
            this.expendablecheckbox.Text = "Expendables";
            this.expendablecheckbox.UseVisualStyleBackColor = true;
            // 
            // valuablecheckbox
            // 
            this.valuablecheckbox.AutoSize = true;
            this.valuablecheckbox.Location = new System.Drawing.Point(0, 27);
            this.valuablecheckbox.Name = "valuablecheckbox";
            this.valuablecheckbox.Size = new System.Drawing.Size(72, 17);
            this.valuablecheckbox.TabIndex = 2;
            this.valuablecheckbox.Text = "Key Items";
            this.valuablecheckbox.UseVisualStyleBackColor = true;
            // 
            // relicscheckbox
            // 
            this.relicscheckbox.AutoSize = true;
            this.relicscheckbox.Location = new System.Drawing.Point(-1, 236);
            this.relicscheckbox.Name = "relicscheckbox";
            this.relicscheckbox.Size = new System.Drawing.Size(55, 17);
            this.relicscheckbox.TabIndex = 1;
            this.relicscheckbox.Text = "Relics";
            this.relicscheckbox.UseVisualStyleBackColor = true;
            // 
            // saveitems
            // 
            this.saveitems.Location = new System.Drawing.Point(4, 338);
            this.saveitems.Name = "saveitems";
            this.saveitems.Size = new System.Drawing.Size(75, 23);
            this.saveitems.TabIndex = 0;
            this.saveitems.Text = "Save";
            this.saveitems.UseVisualStyleBackColor = true;
            this.saveitems.Click += new System.EventHandler(this.saveitems_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(496, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 420);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(496, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // plotcheckbox
            // 
            this.plotcheckbox.AutoSize = true;
            this.plotcheckbox.Location = new System.Drawing.Point(0, 4);
            this.plotcheckbox.Name = "plotcheckbox";
            this.plotcheckbox.Size = new System.Drawing.Size(71, 17);
            this.plotcheckbox.TabIndex = 11;
            this.plotcheckbox.Text = "Plot items";
            this.plotcheckbox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 442);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(512, 480);
            this.MinimumSize = new System.Drawing.Size(512, 480);
            this.Name = "Form1";
            this.Text = "Shin Megami Tensei IV Save Editor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxmp;
        private System.Windows.Forms.TextBox boxtype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxtargets;
        private System.Windows.Forms.TextBox boxdamage;
        private System.Windows.Forms.TextBox boxdesc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button saveitems;
        private System.Windows.Forms.CheckBox relicscheckbox;
        private System.Windows.Forms.CheckBox valuablecheckbox;
        private System.Windows.Forms.CheckBox expendablecheckbox;
        private System.Windows.Forms.CheckBox swordscheckbox;
        private System.Windows.Forms.CheckBox gunscheckbox;
        private System.Windows.Forms.CheckBox acccheckbox;
        private System.Windows.Forms.CheckBox lowercheckbox;
        private System.Windows.Forms.CheckBox uppercheckbox;
        private System.Windows.Forms.CheckBox helmcheckbox;
        private System.Windows.Forms.CheckBox bulletscheckbox;
        private System.Windows.Forms.CheckBox plotcheckbox;

    }
}

