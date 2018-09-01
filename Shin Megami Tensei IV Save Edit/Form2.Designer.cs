namespace SMTIV
{
    partial class Form2
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbx_race = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.b_apply = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_phys = new System.Windows.Forms.ComboBox();
            this.cbx_gun = new System.Windows.Forms.ComboBox();
            this.cbx_fire = new System.Windows.Forms.ComboBox();
            this.cbx_ice = new System.Windows.Forms.ComboBox();
            this.cbx_elec = new System.Windows.Forms.ComboBox();
            this.cbx_force = new System.Windows.Forms.ComboBox();
            this.cbx_light = new System.Windows.Forms.ComboBox();
            this.cbx_dark = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_equal = new System.Windows.Forms.RadioButton();
            this.rb_equalgreater = new System.Windows.Forms.RadioButton();
            this.cbx_status = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ch_guntype = new System.Windows.Forms.CheckBox();
            this.num_hitsmin = new System.Windows.Forms.NumericUpDown();
            this.num_hitsmax = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rb_targetany = new System.Windows.Forms.RadioButton();
            this.rb_targetall = new System.Windows.Forms.RadioButton();
            this.rb_targetmulti = new System.Windows.Forms.RadioButton();
            this.rb_targetsingle = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_sortaz = new System.Windows.Forms.RadioButton();
            this.rb_sortid = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_hitsmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_hitsmax)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(8, 51);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(155, 537);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // cbx_race
            // 
            this.cbx_race.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbx_race, 2);
            this.cbx_race.FormattingEnabled = true;
            this.cbx_race.Location = new System.Drawing.Point(91, 3);
            this.cbx_race.Name = "cbx_race";
            this.cbx_race.Size = new System.Drawing.Size(150, 21);
            this.cbx_race.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.b_apply, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbx_race, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbx_phys, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbx_gun, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbx_fire, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbx_ice, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbx_elec, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbx_force, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbx_light, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbx_dark, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbx_status, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.ch_guntype, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.num_hitsmin, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.num_hitsmax, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(163, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(325, 416);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // b_apply
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.b_apply, 2);
            this.b_apply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.b_apply.Location = new System.Drawing.Point(169, 388);
            this.b_apply.Name = "b_apply";
            this.b_apply.Size = new System.Drawing.Size(153, 25);
            this.b_apply.TabIndex = 3;
            this.b_apply.Text = "Apply Filters";
            this.b_apply.UseVisualStyleBackColor = true;
            this.b_apply.Click += new System.EventHandler(this.b_apply_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "race";
            // 
            // cbx_phys
            // 
            this.cbx_phys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_phys.FormattingEnabled = true;
            this.cbx_phys.Location = new System.Drawing.Point(13, 80);
            this.cbx_phys.Name = "cbx_phys";
            this.cbx_phys.Size = new System.Drawing.Size(72, 21);
            this.cbx_phys.TabIndex = 3;
            // 
            // cbx_gun
            // 
            this.cbx_gun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_gun.FormattingEnabled = true;
            this.cbx_gun.Location = new System.Drawing.Point(91, 80);
            this.cbx_gun.Name = "cbx_gun";
            this.cbx_gun.Size = new System.Drawing.Size(72, 21);
            this.cbx_gun.TabIndex = 4;
            // 
            // cbx_fire
            // 
            this.cbx_fire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_fire.FormattingEnabled = true;
            this.cbx_fire.Location = new System.Drawing.Point(169, 80);
            this.cbx_fire.Name = "cbx_fire";
            this.cbx_fire.Size = new System.Drawing.Size(72, 21);
            this.cbx_fire.TabIndex = 5;
            // 
            // cbx_ice
            // 
            this.cbx_ice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbx_ice.FormattingEnabled = true;
            this.cbx_ice.Location = new System.Drawing.Point(247, 80);
            this.cbx_ice.Name = "cbx_ice";
            this.cbx_ice.Size = new System.Drawing.Size(75, 21);
            this.cbx_ice.TabIndex = 6;
            // 
            // cbx_elec
            // 
            this.cbx_elec.FormattingEnabled = true;
            this.cbx_elec.Location = new System.Drawing.Point(13, 107);
            this.cbx_elec.Name = "cbx_elec";
            this.cbx_elec.Size = new System.Drawing.Size(72, 21);
            this.cbx_elec.TabIndex = 7;
            // 
            // cbx_force
            // 
            this.cbx_force.FormattingEnabled = true;
            this.cbx_force.Location = new System.Drawing.Point(91, 107);
            this.cbx_force.Name = "cbx_force";
            this.cbx_force.Size = new System.Drawing.Size(72, 21);
            this.cbx_force.TabIndex = 8;
            // 
            // cbx_light
            // 
            this.cbx_light.FormattingEnabled = true;
            this.cbx_light.Location = new System.Drawing.Point(169, 107);
            this.cbx_light.Name = "cbx_light";
            this.cbx_light.Size = new System.Drawing.Size(72, 21);
            this.cbx_light.TabIndex = 9;
            // 
            // cbx_dark
            // 
            this.cbx_dark.FormattingEnabled = true;
            this.cbx_dark.Location = new System.Drawing.Point(247, 107);
            this.cbx_dark.Name = "cbx_dark";
            this.cbx_dark.Size = new System.Drawing.Size(75, 21);
            this.cbx_dark.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Location = new System.Drawing.Point(13, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "elemental resistance";
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.rb_equal);
            this.groupBox1.Controls.Add(this.rb_equalgreater);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(169, 134);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 74);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // rb_equal
            // 
            this.rb_equal.AutoSize = true;
            this.rb_equal.Location = new System.Drawing.Point(6, 29);
            this.rb_equal.Name = "rb_equal";
            this.rb_equal.Size = new System.Drawing.Size(51, 17);
            this.rb_equal.TabIndex = 1;
            this.rb_equal.Text = "equal";
            this.rb_equal.UseVisualStyleBackColor = true;
            // 
            // rb_equalgreater
            // 
            this.rb_equalgreater.AutoSize = true;
            this.rb_equalgreater.Checked = true;
            this.rb_equalgreater.Location = new System.Drawing.Point(6, 10);
            this.rb_equalgreater.Name = "rb_equalgreater";
            this.rb_equalgreater.Size = new System.Drawing.Size(99, 17);
            this.rb_equalgreater.TabIndex = 0;
            this.rb_equalgreater.TabStop = true;
            this.rb_equalgreater.Text = "equal or greater";
            this.rb_equalgreater.UseVisualStyleBackColor = true;
            // 
            // cbx_status
            // 
            this.cbx_status.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbx_status, 2);
            this.cbx_status.FormattingEnabled = true;
            this.cbx_status.Items.AddRange(new object[] {
            "(none)",
            "at least any",
            "resist all",
            "resist all plus",
            "null all",
            "at least resist poison",
            "at least resist panic",
            "at least resist sleep",
            "at least resist bind",
            "at least resist sick"});
            this.cbx_status.Location = new System.Drawing.Point(91, 214);
            this.cbx_status.Name = "cbx_status";
            this.cbx_status.Size = new System.Drawing.Size(150, 21);
            this.cbx_status.TabIndex = 13;
            this.cbx_status.Text = "(none)";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "status resistance";
            // 
            // ch_guntype
            // 
            this.ch_guntype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ch_guntype.AutoSize = true;
            this.ch_guntype.Checked = true;
            this.ch_guntype.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.ch_guntype.Location = new System.Drawing.Point(247, 294);
            this.ch_guntype.Name = "ch_guntype";
            this.ch_guntype.Size = new System.Drawing.Size(69, 17);
            this.ch_guntype.TabIndex = 15;
            this.ch_guntype.Text = "Gun type";
            this.ch_guntype.ThreeState = true;
            this.ch_guntype.UseVisualStyleBackColor = true;
            // 
            // num_hitsmin
            // 
            this.num_hitsmin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.num_hitsmin.Location = new System.Drawing.Point(13, 291);
            this.num_hitsmin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_hitsmin.Name = "num_hitsmin";
            this.num_hitsmin.Size = new System.Drawing.Size(72, 20);
            this.num_hitsmin.TabIndex = 16;
            this.num_hitsmin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_hitsmax
            // 
            this.num_hitsmax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.num_hitsmax, 2);
            this.num_hitsmax.Location = new System.Drawing.Point(118, 291);
            this.num_hitsmax.Margin = new System.Windows.Forms.Padding(30, 3, 3, 3);
            this.num_hitsmax.Name = "num_hitsmax";
            this.num_hitsmax.Size = new System.Drawing.Size(75, 20);
            this.num_hitsmax.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 2);
            this.label4.Location = new System.Drawing.Point(13, 269);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "normal attack (hits min max)";
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.rb_targetany);
            this.groupBox2.Controls.Add(this.rb_targetall);
            this.groupBox2.Controls.Add(this.rb_targetmulti);
            this.groupBox2.Controls.Add(this.rb_targetsingle);
            this.groupBox2.Location = new System.Drawing.Point(169, 317);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(153, 65);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "attack targets";
            // 
            // rb_targetany
            // 
            this.rb_targetany.AutoSize = true;
            this.rb_targetany.Checked = true;
            this.rb_targetany.Location = new System.Drawing.Point(6, 19);
            this.rb_targetany.Name = "rb_targetany";
            this.rb_targetany.Size = new System.Drawing.Size(48, 17);
            this.rb_targetany.TabIndex = 3;
            this.rb_targetany.TabStop = true;
            this.rb_targetany.Text = "(any)";
            this.rb_targetany.UseVisualStyleBackColor = true;
            // 
            // rb_targetall
            // 
            this.rb_targetall.AutoSize = true;
            this.rb_targetall.Location = new System.Drawing.Point(60, 42);
            this.rb_targetall.Name = "rb_targetall";
            this.rb_targetall.Size = new System.Drawing.Size(35, 17);
            this.rb_targetall.TabIndex = 2;
            this.rb_targetall.Text = "all";
            this.rb_targetall.UseVisualStyleBackColor = true;
            this.rb_targetall.CheckedChanged += new System.EventHandler(this.rb_targetall_CheckedChanged);
            // 
            // rb_targetmulti
            // 
            this.rb_targetmulti.AutoSize = true;
            this.rb_targetmulti.Location = new System.Drawing.Point(6, 42);
            this.rb_targetmulti.Name = "rb_targetmulti";
            this.rb_targetmulti.Size = new System.Drawing.Size(46, 17);
            this.rb_targetmulti.TabIndex = 1;
            this.rb_targetmulti.Text = "multi";
            this.rb_targetmulti.UseVisualStyleBackColor = true;
            // 
            // rb_targetsingle
            // 
            this.rb_targetsingle.AutoSize = true;
            this.rb_targetsingle.Location = new System.Drawing.Point(60, 19);
            this.rb_targetsingle.Name = "rb_targetsingle";
            this.rb_targetsingle.Size = new System.Drawing.Size(52, 17);
            this.rb_targetsingle.TabIndex = 0;
            this.rb_targetsingle.Text = "single";
            this.rb_targetsingle.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "r. filters";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 388);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "r. list";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(172, 441);
            this.label5.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10);
            this.label5.Size = new System.Drawing.Size(63, 33);
            this.label5.TabIndex = 3;
            this.label5.Text = "label5";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_sortaz);
            this.groupBox3.Controls.Add(this.rb_sortid);
            this.groupBox3.Location = new System.Drawing.Point(8, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 33);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // rb_sortaz
            // 
            this.rb_sortaz.AutoSize = true;
            this.rb_sortaz.Location = new System.Drawing.Point(62, 10);
            this.rb_sortaz.Name = "rb_sortaz";
            this.rb_sortaz.Size = new System.Drawing.Size(39, 17);
            this.rb_sortaz.TabIndex = 1;
            this.rb_sortaz.Text = "a-z";
            this.rb_sortaz.UseVisualStyleBackColor = true;
            this.rb_sortaz.CheckedChanged += new System.EventHandler(this.rb_sortaz_CheckedChanged);
            // 
            // rb_sortid
            // 
            this.rb_sortid.AutoSize = true;
            this.rb_sortid.Checked = true;
            this.rb_sortid.Location = new System.Drawing.Point(7, 10);
            this.rb_sortid.Name = "rb_sortid";
            this.rb_sortid.Size = new System.Drawing.Size(33, 17);
            this.rb_sortid.TabIndex = 0;
            this.rb_sortid.TabStop = true;
            this.rb_sortid.Text = "id";
            this.rb_sortid.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 602);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.listBox1);
            this.MinimumSize = new System.Drawing.Size(512, 640);
            this.Name = "Form2";
            this.Padding = new System.Windows.Forms.Padding(8, 12, 8, 12);
            this.Text = "SMT4 Save Editor - Demon Search";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_hitsmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_hitsmax)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cbx_race;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_phys;
        private System.Windows.Forms.ComboBox cbx_gun;
        private System.Windows.Forms.ComboBox cbx_fire;
        private System.Windows.Forms.ComboBox cbx_ice;
        private System.Windows.Forms.ComboBox cbx_elec;
        private System.Windows.Forms.ComboBox cbx_force;
        private System.Windows.Forms.ComboBox cbx_light;
        private System.Windows.Forms.ComboBox cbx_dark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_equal;
        private System.Windows.Forms.RadioButton rb_equalgreater;
        private System.Windows.Forms.ComboBox cbx_status;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ch_guntype;
        private System.Windows.Forms.NumericUpDown num_hitsmin;
        private System.Windows.Forms.NumericUpDown num_hitsmax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_targetall;
        private System.Windows.Forms.RadioButton rb_targetmulti;
        private System.Windows.Forms.RadioButton rb_targetsingle;
        private System.Windows.Forms.Button b_apply;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rb_targetany;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rb_sortaz;
        private System.Windows.Forms.RadioButton rb_sortid;
    }
}