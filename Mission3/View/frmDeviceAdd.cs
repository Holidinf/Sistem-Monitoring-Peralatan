using Mission3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mission4.Business; // Mengimpor namespace yang benar untuk SensorMonitoringBiz

namespace Mission3.View
{
    public partial class frmDeviceAdd : Form
    {
        public frmDeviceAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var biz = SensorMonitoringBiz.GetInstance();
            biz.AddDevice(new Device { DeviceId = (int)numDeviceId.Value });
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
