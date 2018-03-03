namespace TrainerVConfigCreator
{
    partial class EditDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.vehicleDisplayNameTextBox = new System.Windows.Forms.TextBox();
            this.spawnCodeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.enabledCheckbox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Display Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vehicleDisplayNameTextBox
            // 
            this.vehicleDisplayNameTextBox.Location = new System.Drawing.Point(128, 11);
            this.vehicleDisplayNameTextBox.Name = "vehicleDisplayNameTextBox";
            this.vehicleDisplayNameTextBox.Size = new System.Drawing.Size(294, 20);
            this.vehicleDisplayNameTextBox.TabIndex = 1;
            // 
            // spawnCodeTextBox
            // 
            this.spawnCodeTextBox.Location = new System.Drawing.Point(128, 40);
            this.spawnCodeTextBox.Name = "spawnCodeTextBox";
            this.spawnCodeTextBox.Size = new System.Drawing.Size(294, 20);
            this.spawnCodeTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Spawn Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enabledCheckbox
            // 
            this.enabledCheckbox.AutoSize = true;
            this.enabledCheckbox.Location = new System.Drawing.Point(128, 70);
            this.enabledCheckbox.Name = "enabledCheckbox";
            this.enabledCheckbox.Size = new System.Drawing.Size(100, 17);
            this.enabledCheckbox.TabIndex = 4;
            this.enabledCheckbox.Text = "Is slot enabled?";
            this.enabledCheckbox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.okButton.Location = new System.Drawing.Point(128, 95);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(294, 29);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.cancelButton.Location = new System.Drawing.Point(12, 95);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 29);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // EditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(434, 136);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.enabledCheckbox);
            this.Controls.Add(this.spawnCodeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vehicleDisplayNameTextBox);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(450, 175);
            this.MinimumSize = new System.Drawing.Size(450, 175);
            this.Name = "EditDialog";
            this.Text = "Edit Item...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox vehicleDisplayNameTextBox;
        private System.Windows.Forms.TextBox spawnCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox enabledCheckbox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}