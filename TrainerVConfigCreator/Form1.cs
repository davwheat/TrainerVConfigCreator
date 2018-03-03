using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrainerVConfigCreator
{
    public partial class Form1 : Form
    {
        bool isMaximised;

        public Form1()
        {
            InitializeComponent();
        }

        #region General Form Code

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

        private void maximiseButton_Click(object sender, EventArgs e)
        {
            if (isMaximised)
            {
                Width = 800;
                Height = 600;
                Top = (Screen.PrimaryScreen.WorkingArea.Height / 2) - (Height / 2);
                Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2);
            }
            else
            {
                Left = Top = 0;
                Width = Screen.PrimaryScreen.WorkingArea.Width;
                Height = Screen.PrimaryScreen.WorkingArea.Height;
            }

            isMaximised = !isMaximised;
        }

        #endregion

        #region Minimise Button Code

        private void minimiseButton_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == 0 ? (FormWindowState)1 : (FormWindowState)0;
        }

        #endregion

        #region Resize Form Code

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;

                Size = new Size(PointToClient(MousePosition).X, PointToClient(MousePosition).Y);
            }
        }

        #endregion

        #endregion

        #region Listbox Item Re-ordering

        public static void MoveItem(int direction, ListBox listbox)
        {
            // Checking selected item
            if (listbox.SelectedItem == null || listbox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            var newIndex = listbox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listbox.Items.Count)
                return; // Index out of range - nothing to do

            var selected = listbox.SelectedItem;

            // Removing removable element
            listbox.Items.Remove(selected);
            // Insert it in new position
            listbox.Items.Insert(newIndex, selected);
            // Restore selection
            listbox.SetSelected(newIndex, true);
        }

        #endregion

        #region Vehicle Listbox Code

        private void addNewVehBtn_Click(object sender, EventArgs e)
        {
            if (pedDisplayName.Text == "" || pedSpawnCode.Text == "")
            {
                MessageBox.Show("Vehicle Display Name or Spawn Code cannot be empty!");
                return;
            }

            if (vehNameTextbox.Text.Contains('|') || spawnCodeTextbox.Text.Contains('|'))
            {
                MessageBox.Show("The vehicle name/spawn code CANNOT contain '|'.");
                return;
            }

            var enable = "";
            enable = enabledCheckbox.Checked ? "Y" : "N";

            vehicleBox.BeginUpdate();
            vehicleBox.Items.Add(vehNameTextbox.Text + "|" + spawnCodeTextbox.Text + "|" + enable);
            vehicleBox.EndUpdate();

            vehNameTextbox.Clear();
            spawnCodeTextbox.Clear();
            enabledCheckbox.Checked = true;
        }

        private void deleteVehicleItem(object sender, EventArgs e)
        {
            var i = vehicleBox.SelectedIndex;
            vehicleBox.Items.RemoveAt(i);
        }

        private void editVehicleItem(object sender, EventArgs e)
        {
            var x = vehicleBox.SelectedItem.ToString().Split('|')[2] == "Y" ? true : false;

            var ed = new EditDialog(vehicleBox.SelectedItem.ToString().Split('|')[0], vehicleBox.SelectedItem.ToString().Split('|')[1], x);

            var y = ed.NewIsSlotEnabled ? "Y" : "N";

            var result = ed.ShowDialog();
            var item = "";

            if (result == DialogResult.OK)
            {
                item = ed.NewVehicleDisplayName + "|" + ed.NewVehicleSpawnCode + "|" + y;

                vehicleBox.Items[vehicleBox.SelectedIndex] = item;
            }

            ed.Dispose();
        }

        private void moveVehicleUp(object sender, EventArgs e)
        {
            MoveItem(-1, vehicleBox);
        }

        private void moveVehicleDown(object sender, EventArgs e)
        {
            MoveItem(+1, vehicleBox);
        }

        #endregion

        #region Ped Listbox Code

        private void addNewPed_Click(object sender, EventArgs e)
        {
            if (pedDisplayName.Text == ""|| pedSpawnCode.Text=="")
            {
                MessageBox.Show("Ped Display Name or Spawn Code cannot be empty!");
                return;
            }


            if (pedDisplayName.Text.Contains('|') || pedSpawnCode.Text.Contains('|'))
            {
                MessageBox.Show("The ped name/spawn code CANNOT contain '|'.");
                return;
            }

            var enable = "";
            enable = pedSlotEnabledCheckbox.Checked ? "Y" : "N";

            pedBox.BeginUpdate();
            pedBox.Items.Add(pedDisplayName.Text + "|" + pedSpawnCode.Text + "|" + enable);
            pedBox.EndUpdate();

            pedDisplayName.Clear();
            pedSpawnCode.Clear();
            pedSlotEnabledCheckbox.Checked = true;
        }

        private void deletePed_Click(object sender, EventArgs e)
        {
            var i = pedBox.SelectedIndex;
            pedBox.Items.RemoveAt(i);
        }

        private void editPed_Click(object sender, EventArgs e)
        {
            var x = pedBox.SelectedItem.ToString().Split('|')[2] == "Y" ? true : false;

            var ed = new EditDialog(pedBox.SelectedItem.ToString().Split('|')[0], pedBox.SelectedItem.ToString().Split('|')[1], x);

            var y = ed.NewIsSlotEnabled ? "Y" : "N";

            var result = ed.ShowDialog();
            var item = "";

            if (result == DialogResult.OK)
            {
                item = ed.NewVehicleDisplayName + "|" + ed.NewVehicleSpawnCode + "|" + y;

                pedBox.Items[pedBox.SelectedIndex] = item;
            }

            ed.Dispose();
        }

        private void movePedUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1, pedBox);
        }

        private void movePedDown_Click(object sender, EventArgs e)
        {
            MoveItem(+1, pedBox);
        }

        #endregion

        #region Weapon Listbox Code

        private void addWeapon_Click(object sender, EventArgs e)
        {
            if (weaponDisplayName.Text == "" || weaponModelName.Text == "")
            {
                MessageBox.Show("Weapon Display Name or Model Name cannot be empty!");
                return;
            }


            if (weaponDisplayName.Text.Contains('|') || weaponModelName.Text.Contains('|'))
            {
                MessageBox.Show("Weapon Display Name or Model Name cannot contain '|'.");
                return;
            }

            var enable = "";
            enable = weaponEnabledCheckbox.Checked ? "Y" : "N";

            weaponBox.BeginUpdate();
            weaponBox.Items.Add(weaponDisplayName.Text + "|" + weaponModelName.Text + "|" + enable);
            weaponBox.EndUpdate();

            weaponDisplayName.Clear();
            weaponModelName.Clear();
            weaponEnabledCheckbox.Checked = true;
        }

        private void deleteWeaponItem_Click(object sender, EventArgs e)
        {
            var i = weaponBox.SelectedIndex;
            weaponBox.Items.RemoveAt(i);
        }

        private void moveWeaponUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1, weaponBox);
        }

        private void editWeapon_Click(object sender, EventArgs e)
        {
            var x = weaponBox.SelectedItem.ToString().Split('|')[2] == "Y" ? true : false;

            var ed = new EditDialog(weaponBox.SelectedItem.ToString().Split('|')[0], weaponBox.SelectedItem.ToString().Split('|')[1], x);

            var y = ed.NewIsSlotEnabled ? "Y" : "N";

            var result = ed.ShowDialog();
            var item = "";

            if (result == DialogResult.OK)
            {
                item = ed.NewVehicleDisplayName + "|" + ed.NewVehicleSpawnCode + "|" + y;

                weaponBox.Items[weaponBox.SelectedIndex] = item;
            }

            ed.Dispose();
        }

        private void moveWeaponDown_Click(object sender, EventArgs e)
        {
            MoveItem(+1, weaponBox);
        }

        #endregion

        #region Saving/Loading Code

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

            SaveFile.WriteLine("[AddedPeds]");

            foreach (var item in pedBox.Items)
            {
                i++;

                var enabled = "";

                var pedName = item.ToString().Split('|')[0];
                var pedspawncode = item.ToString().Split('|')[1];
                enabled = item.ToString().Split('|')[2] == "Y" ? "1" : "0";


                SaveFile.WriteLine("Enable" + i + "=" + enabled);
                SaveFile.WriteLine("ModelName" + i + "=" + pedspawncode);
                SaveFile.WriteLine("DisplayName" + i + "=" + pedName);

            }

            SaveFile.WriteLine("[AddedWeapons]");

            foreach (var item in weaponBox.Items)
            {
                i++;

                var enabled = "";

                var weaponName = item.ToString().Split('|')[0];
                var weaponspawncode = item.ToString().Split('|')[1];
                enabled = item.ToString().Split('|')[2] == "Y" ? "1" : "0";


                SaveFile.WriteLine("Enable" + i + "=" + enabled);
                SaveFile.WriteLine("ModelName" + i + "=" + weaponspawncode);
                SaveFile.WriteLine("DisplayName" + i + "=" + weaponName);

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

            SaveFile.WriteLine("[Vehicles]");

            foreach (var item in vehicleBox.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }

            SaveFile.WriteLine("[Peds]");

            foreach (var item in pedBox.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }

            SaveFile.WriteLine("[Weapons]");

            foreach (var item in weaponBox.Items)
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

            var type = 0;

            foreach (var line in lines)
            {
                switch (line)
                {
                    case "[Vehicles]":
                        type = 0;
                        break;
                    case "[Peds]":
                        type = 1;
                        break;
                    case "[Weapons]":
                        type = 2;
                        break;
                    default:
                        switch (type)
                        {
                            case 0:
                                vehicleBox.Items.Add(line);
                                break;
                            case 1:
                                pedBox.Items.Add(line);
                                break;
                            case 2:
                                weaponBox.Items.Add(line);
                                break;
                        }

                        break;
                }
            }

            vehicleBox.EndUpdate();
        }

        #endregion
    }
}
