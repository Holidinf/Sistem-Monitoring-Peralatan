using Mission4.Business; // Sesuaikan dengan namespace yang benar
using Mission3.Model;   // Pastikan namespace ini benar
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Mission3.View
{
    public partial class frmSensorDataList : Form
    {
        private DataTable sensorDataTable;
        private SensorMonitoringBiz sensorMonitoringBiz;

        public frmSensorDataList()
        {
            InitializeComponent();
        }

        private void frmSensorDataList_Load(object sender, EventArgs e)
        {
            try
            {
                sensorMonitoringBiz = SensorMonitoringBiz.GetInstance();
                InitializeDataTable();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void InitializeDataTable()
        {
            sensorDataTable = new DataTable();
            sensorDataTable.Columns.Add("LogDate", typeof(DateTime));
            sensorDataTable.Columns.Add("DeviceId", typeof(int)); // Sesuaikan tipe data jika perlu
            sensorDataTable.Columns.Add("Temperature", typeof(decimal));
            sensorDataTable.Columns.Add("Humidity", typeof(decimal));
        }

        private void LoadData()
        {
            try
            {
                // Clear existing rows
                sensorDataTable.Rows.Clear();

                // Load data from SensorMonitoringBiz
                var sensorDataList = sensorMonitoringBiz.GetSensorData(data => true); // Menggunakan filter default

                foreach (var data in sensorDataList)
                {
                    sensorDataTable.Rows.Add(data.LogDate, data.DeviceId, data.Temperature, data.Humidity);
                }

                dgvDevice.DataSource = sensorDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sensor data: " + ex.Message);
            }
        }

        private void btnShowInsideTempRange_Click(object sender, EventArgs e)
        {
            try
            {
                decimal fromTemp = numFromTemp.Value;
                decimal toTemp = numToTemp.Value;
                var filteredRows = sensorDataTable.AsEnumerable()
                    .Where(row => row.Field<decimal>("Temperature") >= fromTemp && row.Field<decimal>("Temperature") <= toTemp);

                UpdateDataGridView(filteredRows.CopyToDataTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering temperature data: " + ex.Message);
            }
        }

        private void btnShowOutsideTempRange_Click(object sender, EventArgs e)
        {
            try
            {
                decimal fromTemp = numFromTemp.Value;
                decimal toTemp = numToTemp.Value;
                var filteredRows = sensorDataTable.AsEnumerable()
                    .Where(row => row.Field<decimal>("Temperature") < fromTemp || row.Field<decimal>("Temperature") > toTemp);

                UpdateDataGridView(filteredRows.CopyToDataTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering temperature data: " + ex.Message);
            }
        }

        private void btnShowInsideHumidityRange_Click(object sender, EventArgs e)
        {
            try
            {
                decimal fromHumidity = numFromHumidity.Value;
                decimal toHumidity = numToHumidity.Value;
                var filteredRows = sensorDataTable.AsEnumerable()
                    .Where(row => row.Field<decimal>("Humidity") >= fromHumidity && row.Field<decimal>("Humidity") <= toHumidity);

                UpdateDataGridView(filteredRows.CopyToDataTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering humidity data: " + ex.Message);
            }
        }

        private void btnShowOutsideHumidityRange_Click(object sender, EventArgs e)
        {
            try
            {
                decimal fromHumidity = numFromHumidity.Value;
                decimal toHumidity = numToHumidity.Value;
                var filteredRows = sensorDataTable.AsEnumerable()
                    .Where(row => row.Field<decimal>("Humidity") < fromHumidity || row.Field<decimal>("Humidity") > toHumidity);

                UpdateDataGridView(filteredRows.CopyToDataTable());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering humidity data: " + ex.Message);
            }
        }

        private void UpdateDataGridView(DataTable filteredData)
        {
            dgvDevice.DataSource = filteredData;
        }
    }
}
