using Mission3.Model;
using Mission4.Business;
using System;
using System.Linq;
using System.Threading.Tasks; // Untuk Task
using System.Windows.Forms;

namespace Mission3.View
{
    public partial class frmMain : Form
    {
        DeviceComManager deviceComManager;
        SensorMonitoringBiz sensorMonitoringBiz;

        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            sensorMonitoringBiz = SensorMonitoringBiz.GetInstance();
            sensorMonitoringBiz.SetDeviceFile(new DeviceFile());
            sensorMonitoringBiz.SetSensorDataFile(new SensorDataFile());

            sensorMonitoringBiz.LoadData();

            deviceComManager = new DeviceComManager(9999);
            deviceComManager.SensorDataArrived += SensorDataArrived;
            deviceComManager.Start();

            RefreshGrid();

            tmrSaveData.Start();
        }

        private void SensorDataArrived(SensorData sensorData)
        {
            this.Invoke(new Action(() => { ProcessSensorData(sensorData); }));
        }

        private void ProcessSensorData(SensorData sensorData)
        {
            var deviceMap = sensorMonitoringBiz.GetDeviceMap();

            if (deviceMap.ContainsKey(sensorData.DeviceId))
            {
                var device = deviceMap[sensorData.DeviceId];
                device.CurrentTemperature = sensorData.Temperature;
                device.CurrentHumidity = sensorData.Humidity;
                sensorMonitoringBiz.AddSensorData(sensorData);

                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            dgvDevice.AutoGenerateColumns = false;
            dgvDevice.DataSource = sensorMonitoringBiz.GetDeviceList().ToList();
        }

        private void lblAddSensorDevice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new frmDeviceAdd();

            if (form.ShowDialog() == DialogResult.OK)
                RefreshGrid();
        }

        private async void tmrSaveData_Tick(object sender, EventArgs e)
        {
            await sensorMonitoringBiz.SaveToDataSourceAsync();
        }

        private async void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            await sensorMonitoringBiz.SaveToDataSourceAsync();
        }

        private void lblSensorDataHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new frmSensorDataList();
            form.ShowDialog();
        }
    }
}
