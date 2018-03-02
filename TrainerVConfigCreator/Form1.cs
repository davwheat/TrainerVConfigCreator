using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainerVConfigCreator
{
    public partial class Form1 : Form
    {
        #region AllowFormMovement

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void moveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Close Button Code

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e) => closeButton.ForeColor = Color.White;
        private void closeButton_MouseLeave(object sender, EventArgs e) => closeButton.ForeColor = Color.FromArgb(158, 158, 158);

        #endregion

        #region Maximise Button Code

        private void maximiseButton_MouseEnter(object sender, EventArgs e) => maximiseButton.ForeColor = Color.White;
        private void maximiseButton_MouseLeave(object sender, EventArgs e) => maximiseButton.ForeColor = Color.FromArgb(158, 158, 158);

        #endregion

        private void maximiseButton_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == (FormWindowState)2 ? (FormWindowState)0 : (FormWindowState)2;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;

                Size = new Size(PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
            }
        }

        private void addNewVehBtn_Click(object sender, EventArgs e)
        {
            if (vehNameTextbox.Text.Contains('|') || spawnCodeTextbox.Text.Contains('|'))
            {
                MessageBox.Show("The vehicle name/spawn code CANNOT contain '|'.");
                return;
            }

            var enable="";
            enable = enabledCheckbox.Checked ? "Y" : "N";

            vehicleBox.BeginUpdate();
            vehicleBox.Items.Add(vehNameTextbox.Text + "|" + spawnCodeTextbox.Text + "|" + enable);
            vehicleBox.EndUpdate();

            vehNameTextbox.Clear();
            spawnCodeTextbox.Clear();
        }


        #region listbox movement

        public void MoveItem(int direction)
        {
            // Checking selected item
            if (vehicleBox.SelectedItem == null || vehicleBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            var newIndex = vehicleBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= vehicleBox.Items.Count)
                return; // Index out of range - nothing to do

            var selected = vehicleBox.SelectedItem;

            // Removing removable element
            vehicleBox.Items.Remove(selected);
            // Insert it in new position
            vehicleBox.Items.Insert(newIndex, selected);
            // Restore selection
            vehicleBox.SetSelected(newIndex, true);
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        private void moveItemDownBtn_Click(object sender, EventArgs e)
        {
            MoveItem(+1);
        }

        private void exportToTrainerConfig(object sender, EventArgs e)
        {
            var x = saveConfigDialog.ShowDialog();

            if (x == DialogResult.Cancel || x == DialogResult.Abort)
            {
                MessageBox.Show("Export cancelled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var SaveFile = new StreamWriter(Path.GetFullPath(saveConfigDialog.FileName));

            var i = 0;

            SaveFile.WriteLine("[AddedCars]");

            foreach (var item in vehicleBox.Items)
            {
                i++;

                var enabled = "";

                var vehName = item.ToString().Split('|')[0];
                var vehspawncode = item.ToString().Split('|')[1];
                enabled = item.ToString().Split('|')[2] == "Y" ? "1" : "0";


                SaveFile.WriteLine("Enable" + i + "=" + enabled);
                SaveFile.WriteLine("ModelName" + i + "=" + vehspawncode);
                SaveFile.WriteLine("DisplayName" + i + "=" + vehName);

            }

            SaveFile.Dispose();
        }

        private void saveProjectBtn_Click(object sender, EventArgs e)
        {
            var x = saveFileDialog.ShowDialog();

            if (x == DialogResult.Cancel || x == DialogResult.Abort)
            {
                MessageBox.Show("Save cancelled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var SaveFile = new StreamWriter(Path.GetFullPath(saveFileDialog.FileName));

            foreach (var item in vehicleBox.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }

            SaveFile.Dispose();
        }

        private void loadProjectBtn_Click(object sender, EventArgs e)
        {
            var x = openFileDialog.ShowDialog();

            if (x == DialogResult.Cancel || x == DialogResult.Abort)
            {
                MessageBox.Show("Load cancelled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var lines = File.ReadAllLines(Path.GetFullPath(openFileDialog.FileName));

            vehicleBox.BeginUpdate();

            foreach (var line in lines)
            {
                vehicleBox.Items.Add(line);
            }

            vehicleBox.EndUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var i = vehicleBox.SelectedIndex;
            vehicleBox.Items.RemoveAt(i);
        }
    }
}
