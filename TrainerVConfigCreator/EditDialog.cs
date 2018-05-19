using System;
using System.Windows.Forms;

namespace TrainerVConfigCreator
{
    public partial class EditDialog : Form
    {
        public string NewVehicleDisplayName { get; set; }
        public string NewVehicleSpawnCode { get; set; }
        public bool NewIsSlotEnabled { get; set; }

        public EditDialog(string vehicleDispName, string vehicleSpawncode, bool isEnabled)
        {
            InitializeComponent();

            vehicleDisplayNameTextBox.Text = vehicleDispName;
            spawnCodeTextBox.Text = vehicleSpawncode;
            enabledCheckbox.Checked = isEnabled;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            NewVehicleDisplayName = vehicleDisplayNameTextBox.Text;
            NewVehicleSpawnCode = spawnCodeTextBox.Text;
            NewIsSlotEnabled = enabledCheckbox.Checked;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}