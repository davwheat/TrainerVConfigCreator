namespace TrainerVConfigCreator
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.maximiseButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.vehicleBox = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.loadProjectBtn = new System.Windows.Forms.Button();
            this.saveProjectBtn = new System.Windows.Forms.Button();
            this.exportprojectbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.moveItemUpBtn = new System.Windows.Forms.Button();
            this.moveItemDownBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enabledCheckbox = new System.Windows.Forms.CheckBox();
            this.addNewVehBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.spawnCodeTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vehNameTextbox = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveConfigDialog = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.maximiseButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 31);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveForm);
            // 
            // maximiseButton
            // 
            this.maximiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximiseButton.FlatAppearance.BorderSize = 0;
            this.maximiseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.maximiseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.maximiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximiseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.maximiseButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.maximiseButton.Location = new System.Drawing.Point(608, -4);
            this.maximiseButton.Name = "maximiseButton";
            this.maximiseButton.Size = new System.Drawing.Size(50, 27);
            this.maximiseButton.TabIndex = 2;
            this.maximiseButton.Text = "🗖";
            this.maximiseButton.UseVisualStyleBackColor = true;
            this.maximiseButton.Click += new System.EventHandler(this.maximiseButton_Click);
            this.maximiseButton.MouseEnter += new System.EventHandler(this.maximiseButton_MouseEnter);
            this.maximiseButton.MouseLeave += new System.EventHandler(this.maximiseButton_MouseLeave);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(664, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(50, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.closeButton_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(387, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "TrainerV Config Generator | by David Wheatley";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vehicleBox
            // 
            this.vehicleBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.vehicleBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vehicleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.vehicleBox.ForeColor = System.Drawing.Color.White;
            this.vehicleBox.FormattingEnabled = true;
            this.vehicleBox.ItemHeight = 15;
            this.vehicleBox.Location = new System.Drawing.Point(0, 0);
            this.vehicleBox.Name = "vehicleBox";
            this.vehicleBox.Size = new System.Drawing.Size(500, 459);
            this.vehicleBox.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vehicleBox);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(714, 459);
            this.splitContainer1.SplitterDistance = 500;
            this.splitContainer1.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.loadProjectBtn);
            this.groupBox3.Controls.Add(this.saveProjectBtn);
            this.groupBox3.Controls.Add(this.exportprojectbtn);
            this.groupBox3.Location = new System.Drawing.Point(10, 260);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 109);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save/Load";
            // 
            // loadProjectBtn
            // 
            this.loadProjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.loadProjectBtn.Location = new System.Drawing.Point(9, 77);
            this.loadProjectBtn.Name = "loadProjectBtn";
            this.loadProjectBtn.Size = new System.Drawing.Size(173, 23);
            this.loadProjectBtn.TabIndex = 6;
            this.loadProjectBtn.Text = "Load Project";
            this.loadProjectBtn.UseVisualStyleBackColor = true;
            this.loadProjectBtn.Click += new System.EventHandler(this.loadProjectBtn_Click);
            // 
            // saveProjectBtn
            // 
            this.saveProjectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveProjectBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.saveProjectBtn.Location = new System.Drawing.Point(9, 48);
            this.saveProjectBtn.Name = "saveProjectBtn";
            this.saveProjectBtn.Size = new System.Drawing.Size(173, 23);
            this.saveProjectBtn.TabIndex = 5;
            this.saveProjectBtn.Text = "Save Project";
            this.saveProjectBtn.UseVisualStyleBackColor = true;
            this.saveProjectBtn.Click += new System.EventHandler(this.saveProjectBtn_Click);
            // 
            // exportprojectbtn
            // 
            this.exportprojectbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportprojectbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.exportprojectbtn.Location = new System.Drawing.Point(9, 19);
            this.exportprojectbtn.Name = "exportprojectbtn";
            this.exportprojectbtn.Size = new System.Drawing.Size(173, 23);
            this.exportprojectbtn.TabIndex = 4;
            this.exportprojectbtn.Text = "Export to Config";
            this.exportprojectbtn.UseVisualStyleBackColor = true;
            this.exportprojectbtn.Click += new System.EventHandler(this.exportToTrainerConfig);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pictureBox1.Location = new System.Drawing.Point(186, 435);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.moveItemUpBtn);
            this.groupBox2.Controls.Add(this.moveItemDownBtn);
            this.groupBox2.Location = new System.Drawing.Point(10, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 90);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.button3.Location = new System.Drawing.Point(9, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // moveItemUpBtn
            // 
            this.moveItemUpBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveItemUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveItemUpBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.moveItemUpBtn.Location = new System.Drawing.Point(107, 26);
            this.moveItemUpBtn.Name = "moveItemUpBtn";
            this.moveItemUpBtn.Size = new System.Drawing.Size(75, 23);
            this.moveItemUpBtn.TabIndex = 1;
            this.moveItemUpBtn.Text = "Move Up";
            this.moveItemUpBtn.UseVisualStyleBackColor = true;
            this.moveItemUpBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // moveItemDownBtn
            // 
            this.moveItemDownBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveItemDownBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveItemDownBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.moveItemDownBtn.Location = new System.Drawing.Point(107, 55);
            this.moveItemDownBtn.Name = "moveItemDownBtn";
            this.moveItemDownBtn.Size = new System.Drawing.Size(75, 23);
            this.moveItemDownBtn.TabIndex = 0;
            this.moveItemDownBtn.Text = "Move Down";
            this.moveItemDownBtn.UseVisualStyleBackColor = true;
            this.moveItemDownBtn.Click += new System.EventHandler(this.moveItemDownBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.enabledCheckbox);
            this.groupBox1.Controls.Add(this.addNewVehBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.spawnCodeTextbox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.vehNameTextbox);
            this.groupBox1.Location = new System.Drawing.Point(10, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 152);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Vehicle";
            // 
            // enabledCheckbox
            // 
            this.enabledCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enabledCheckbox.Checked = true;
            this.enabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledCheckbox.Location = new System.Drawing.Point(6, 71);
            this.enabledCheckbox.Name = "enabledCheckbox";
            this.enabledCheckbox.Size = new System.Drawing.Size(176, 24);
            this.enabledCheckbox.TabIndex = 4;
            this.enabledCheckbox.Text = "Is slot enabled?";
            this.enabledCheckbox.UseVisualStyleBackColor = true;
            // 
            // addNewVehBtn
            // 
            this.addNewVehBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewVehBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewVehBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.addNewVehBtn.Location = new System.Drawing.Point(6, 123);
            this.addNewVehBtn.Name = "addNewVehBtn";
            this.addNewVehBtn.Size = new System.Drawing.Size(176, 23);
            this.addNewVehBtn.TabIndex = 4;
            this.addNewVehBtn.Text = "Add";
            this.addNewVehBtn.UseVisualStyleBackColor = true;
            this.addNewVehBtn.Click += new System.EventHandler(this.addNewVehBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Spawn Code";
            // 
            // spawnCodeTextbox
            // 
            this.spawnCodeTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spawnCodeTextbox.Location = new System.Drawing.Point(80, 45);
            this.spawnCodeTextbox.Name = "spawnCodeTextbox";
            this.spawnCodeTextbox.Size = new System.Drawing.Size(102, 20);
            this.spawnCodeTextbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Veh Name";
            // 
            // vehNameTextbox
            // 
            this.vehNameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vehNameTextbox.Location = new System.Drawing.Point(69, 19);
            this.vehNameTextbox.Name = "vehNameTextbox";
            this.vehNameTextbox.Size = new System.Drawing.Size(113, 20);
            this.vehNameTextbox.TabIndex = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "TrainerVConfig.cfg";
            this.saveFileDialog.Filter = "TrainerV Config Generator Files|*.cfg";
            this.saveFileDialog.InitialDirectory = "%USERPROFILE%\\Desktop";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            this.saveFileDialog.Title = "Save your TrainerV Project...";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "TrainerV Config Generator Files|*.cfg";
            this.openFileDialog.Title = "Open your TrainerV Project...";
            // 
            // saveConfigDialog
            // 
            this.saveConfigDialog.Filter = "TrainerV Config|*.ini";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.button1.Location = new System.Drawing.Point(9, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(714, 490);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button maximiseButton;
        private System.Windows.Forms.ListBox vehicleBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button moveItemUpBtn;
        private System.Windows.Forms.Button moveItemDownBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vehNameTextbox;
        private System.Windows.Forms.Button addNewVehBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox spawnCodeTextbox;
        private System.Windows.Forms.CheckBox enabledCheckbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button exportprojectbtn;
        private System.Windows.Forms.Button loadProjectBtn;
        private System.Windows.Forms.Button saveProjectBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveConfigDialog;
        private System.Windows.Forms.Button button1;
    }
}

