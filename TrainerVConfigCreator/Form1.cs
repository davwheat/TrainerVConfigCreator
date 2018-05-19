#pragma warning disable CA1303

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[assembly: CLSCompliant(true)]

namespace TrainerVConfigCreator
{
    [CLSCompliant(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Icon = Properties.Resources.icon;

            fontSizeSelector.Value = Properties.Settings.Default.fontSize;
        }

        #region General Form Code

        private bool isMaximised;

        #region AllowFormMovement

        public const int WMNCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private void moveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                NativeMethods.ReleaseCapture();
                NativeMethods.SendMessage(Handle, WMNCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        #endregion AllowFormMovement

        #region ListBox Updating

        private void beginUpdates()
        {
            vehicleBox.BeginUpdate();
            pedBox.BeginUpdate();
            weaponBox.BeginUpdate();
        }

        private void endUpdates()
        {
            vehicleBox.EndUpdate();
            pedBox.EndUpdate();
            weaponBox.EndUpdate();
        }

        #endregion ListBox Updating

        #region Prompt On Form Exit

        private void WhenFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Have you saved your project?", "Have you saved?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        #endregion Prompt On Form Exit

        #region Close Button Code

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e) => closeButton.ForeColor = Color.White;

        private void closeButton_MouseLeave(object sender, EventArgs e) => closeButton.ForeColor = Color.FromArgb(158, 158, 158);

        #endregion Close Button Code

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

        #endregion Maximise Button Code

        #region Minimise Button Code

        private void minimiseButton_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == 0 ? (FormWindowState)1 : (FormWindowState)0;
        }

        #endregion Minimise Button Code

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

        #endregion Resize Form Code

        #region Font Size Change

        private void fontSizeSelector_ValueChanged(object sender, EventArgs e)
        {
            vehicleBox.Font = new Font(FontFamily.GenericSansSerif, (Single)fontSizeSelector.Value);
            pedBox.Font = new Font(FontFamily.GenericSansSerif, (Single)fontSizeSelector.Value);
            weaponBox.Font = new Font(FontFamily.GenericSansSerif, (Single)fontSizeSelector.Value);

            Properties.Settings.Default.fontSize = (int)fontSizeSelector.Value;
            Properties.Settings.Default.Save();
        }

        #endregion Font Size Change

        #endregion General Form Code

        #region Listbox Item Re-ordering

        public static void MoveItem(int direction, ListBox listBox)
        {
            if (listBox == null)
            {
                return;
            }

            // Checking selected item
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            var newIndex = listBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
                return; // Index out of range - nothing to do

            var selected = listBox.SelectedItem;

            // Removing removable element
            listBox.Items.Remove(selected);
            // Insert it in new position
            listBox.Items.Insert(newIndex, selected);
            // Restore selection
            listBox.SetSelected(newIndex, true);
        }

        #endregion Listbox Item Re-ordering

        #region Vehicle Listbox Code

        private void addNewVehBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(vehNameTextbox.Text) || String.IsNullOrEmpty(spawnCodeTextbox.Text))
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
            if (vehicleBox.SelectedItem != null)
            {
                var i = vehicleBox.SelectedIndex;
                vehicleBox.Items.RemoveAt(i);
            }
        }

        private void editVehicleItem(object sender, EventArgs e)
        {
            if (vehicleBox.SelectedItem != null)
            {
                var x = vehicleBox.SelectedItem.ToString().Split('|')[2] == "Y" ? true : false;

                var ed = new EditDialog(vehicleBox.SelectedItem.ToString().Split('|')[0], vehicleBox.SelectedItem.ToString().Split('|')[1], x);

                var result = ed.ShowDialog();
                var item = "";

                var y = ed.NewIsSlotEnabled ? "Y" : "N";

                if (result == DialogResult.OK)
                {
                    item = ed.NewVehicleDisplayName + "|" + ed.NewVehicleSpawnCode + "|" + y;

                    vehicleBox.Items[vehicleBox.SelectedIndex] = item;
                }

                ed.Dispose();
            }
        }

        private void moveVehicleUp(object sender, EventArgs e)
        {
            if (vehicleBox.SelectedItem != null)
                MoveItem(-1, vehicleBox);
        }

        private void moveVehicleDown(object sender, EventArgs e)
        {
            if (vehicleBox.SelectedItem != null)
                MoveItem(+1, vehicleBox);
        }

        private void spawnCodeTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                addNewVehBtn_Click(addNewVehBtn, new EventArgs());
                vehNameTextbox.Focus();
            }
        }

        private void vehicleBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (vehicleBox.SelectedItem == null) return;
            vehicleBox.DoDragDrop(vehicleBox.SelectedItem, DragDropEffects.Move);
        }

        private void vehicleBox_DragOver(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;

        private void vehicleBox_DragDrop(object sender, DragEventArgs e)
        {
            var point = vehicleBox.PointToClient(new Point(e.X, e.Y));
            var index = vehicleBox.IndexFromPoint(point);
            if (index < 0) index = vehicleBox.Items.Count - 1;
            var data = vehicleBox.SelectedItem;
            vehicleBox.Items.Remove(data);
            vehicleBox.Items.Insert(index, data);
        }

        #endregion Vehicle Listbox Code

        #region Ped Listbox Code

        private void addNewPed_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pedDisplayName.Text) || String.IsNullOrEmpty(pedSpawnCode.Text))
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
            if (pedBox.SelectedItem != null)
            {
                var i = pedBox.SelectedIndex;
                pedBox.Items.RemoveAt(i);
            }
        }

        private void editPed_Click(object sender, EventArgs e)
        {
            if (pedBox.SelectedItem != null)
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
        }

        private void movePedUp_Click(object sender, EventArgs e)
        {
            if (pedBox.SelectedItem != null)
                MoveItem(-1, pedBox);
        }

        private void movePedDown_Click(object sender, EventArgs e)
        {
            if (pedBox.SelectedItem != null)
                MoveItem(+1, pedBox);
        }

        private void pedSpawnCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                addNewPed_Click(addNewPed, new EventArgs());
                pedDisplayName.Focus();
            }
        }

        private void pedBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (vehicleBox.SelectedItem == null) return;
            vehicleBox.DoDragDrop(vehicleBox.SelectedItem, DragDropEffects.Move);
        }

        private void pedbox_DragOver(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;

        private void pedbox_DragDrop(object sender, DragEventArgs e)
        {
            var point = pedBox.PointToClient(new Point(e.X, e.Y));
            var index = pedBox.IndexFromPoint(point);
            if (index < 0) index = pedBox.Items.Count - 1;
            var data = pedBox.SelectedItem;
            pedBox.Items.Remove(data);
            pedBox.Items.Insert(index, data);
        }

        #endregion Ped Listbox Code

        #region Weapon Listbox Code

        private void addWeapon_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(weaponDisplayName.Text) || String.IsNullOrEmpty(weaponModelName.Text))
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
            if (weaponBox.SelectedItem != null)
            {
                var i = weaponBox.SelectedIndex;
                weaponBox.Items.RemoveAt(i);
            }
        }

        private void moveWeaponUp_Click(object sender, EventArgs e)
        {
            if (weaponBox.SelectedItem != null)
                MoveItem(-1, weaponBox);
        }

        private void editWeapon_Click(object sender, EventArgs e)
        {
            if (weaponBox.SelectedItem != null)
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
        }

        private void moveWeaponDown_Click(object sender, EventArgs e)
        {
            if (weaponBox.SelectedItem != null)
                MoveItem(+1, weaponBox);
        }

        private void weaponModelName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                addWeapon_Click(addWeapon, new EventArgs());
                weaponDisplayName.Focus();
            }
        }

        private void weaponbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (vehicleBox.SelectedItem == null) return;
            vehicleBox.DoDragDrop(vehicleBox.SelectedItem, DragDropEffects.Move);
        }

        private void weaponbox_DragOver(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;

        private void weaponbox_DragDrop(object sender, DragEventArgs e)
        {
            var point = vehicleBox.PointToClient(new Point(e.X, e.Y));
            var index = vehicleBox.IndexFromPoint(point);
            if (index < 0) index = vehicleBox.Items.Count - 1;
            var data = vehicleBox.SelectedItem;
            vehicleBox.Items.Remove(data);
            vehicleBox.Items.Insert(index, data);
        }

        #endregion Weapon Listbox Code

        #region Saving Code

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

                var pedName = item.ToString().Split('|')[0];
                var pedspawncode = item.ToString().Split('|')[1];
                var enabled = item.ToString().Split('|')[2] == "Y" ? "1" : "0";

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

        #endregion Saving Code

        #region Loading Code

        private void loadProjectBtn_Click(object sender, EventArgs e)
        {
            var x = openFileDialog.ShowDialog();

            if (x == DialogResult.Cancel || x == DialogResult.Abort)
            {
                MessageBox.Show("Load cancelled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var lines = File.ReadAllLines(Path.GetFullPath(openFileDialog.FileName));

            beginUpdates();

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
                        addItem(line, type);
                        break;
                }
            }

            endUpdates();
        }

        private void addItem(string line, int type)
        {
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
        }

        string[] openImportDialog()
        {
            var x = openTrainerVConfigDialog.ShowDialog();

            if (x == DialogResult.Cancel || x == DialogResult.Abort)
            {
                MessageBox.Show("Import cancelled!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            return File.ReadAllLines(Path.GetFullPath(openTrainerVConfigDialog.FileName));
        }

        private void importFromTrainerVBtn_Click(object sender, EventArgs e)
        {
            var lines = openImportDialog();

            if (lines == null)
            {
                MessageBox.Show("Loading cancelled.");
                return;
            }

            beginUpdates();

            var type = -1;

            var ni = 0;
            var mi = 0;
            var di = 0;

            var n = false;          // eNabled
            var m = string.Empty;   // Model name
            var d = string.Empty;   // Display name

            var set1 = false;
            var set2 = false;
            var set3 = false;

            foreach (var line in lines)
            {
                switch (line)
                {
                    case "[AddedCars]":
                        {
                            type = 0;
                            break;
                        }
                    case "[AddedPeds]":
                        {
                            type = 1;
                            break;
                        }
                    case "[AddedWeapons]":
                        {
                            type = 2;
                            break;
                        }
                    default:
                        {
                            if (type != -1)
                            {
                                if (line.StartsWith("Enable"))
                                {
                                    try
                                    {
                                        ni = int.Parse(line.Substring(6, 1));

                                        n = getEnabled(line);
                                        set1 = true;
                                    }
                                    catch (Exception)
                                    {
                                        errorImporting(line, lines);
                                        set1 = set2 = set3 = false;
                                    }
                                }
                                else if (line.StartsWith("ModelName"))
                                {
                                    try
                                    {
                                        mi = int.Parse(line.Substring(9, 1));
                                        m = line.Substring(11);

                                        set2 = true;
                                    }
                                    catch (Exception)
                                    {
                                        errorImporting(line, lines);
                                        set1 = set2 = set3 = false;
                                    }
                                }
                                else if (line.StartsWith("DisplayName"))
                                {
                                    try
                                    {
                                        di = int.Parse(line.Substring(11, 1));
                                        d = line.Substring(13);

                                        set3 = true;
                                    }
                                    catch (Exception)
                                    {
                                        errorImporting(line, lines);
                                        set1 = set2 = set3 = false;
                                    }
                                }

                                if (set1 && set2 && set3)
                                {
                                    if (new[] { mi, di }.Distinct().Count() == ni)
                                    {
                                        set1 = set2 = set3 = false;

                                        addItems(type, n, m, d);
                                    }
                                    else
                                    {
                                        var sType = "";

                                        switch (type)
                                        {
                                            case 0:
                                                sType = "Added Vehicles";
                                                break;
                                            case 1:
                                                sType = "Added Peds";
                                                break;
                                            case 2:
                                                sType = "Added Weapons";
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                }

                endUpdates();
            }

            vehicleBox.EndUpdate();
        }

        private static void errorImporting(string line, string[] lines)
        {
            MessageBox.Show("ERROR IN TRAINERV CONFIG FILE: Error with line number " + Array.IndexOf(lines, line).ToString() + Environment.NewLine + '"' + line + '"');
        }

        private void addItems(int type, bool n, string m, string d)
        {
            var enabled = n ? "Y" : "N";

            var text = d + '|' + m + '|' + enabled;
            switch (type)
            {
                case 0:
                    vehicleBox.Items.Add(text);
                    break;

                case 1:
                    pedBox.Items.Add(text);
                    break;

                case 2:
                    weaponBox.Items.Add(text);
                    break;
            }
        }

        private static bool getEnabled(string line)
        {
            switch (line.EndsWith("0"))
            {
                case true:
                    return false;

                case false:
                    return true;

                default:
                    return false;
            }
        }

        #endregion Loading Code
    }

    internal class NativeMethods
    {
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr window, int message, int unknown, int parameter);
    }
}

#pragma warning restore CA1303