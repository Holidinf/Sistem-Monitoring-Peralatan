using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace SensorDevice
{
    public partial class frmMain : Form
    {
        Socket ClientSocket;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrSensing.Start();
        }

        private void tmrSensing_Tick(object sender, EventArgs e)
        {
            double temperature = 20 + new Random().NextDouble() * 10;
            double humidity = 50 + new Random().NextDouble() * 30;

            lblTemperature.Text = temperature.ToString("0.0");
            lblHumidity.Text = humidity.ToString("0.0");

            if (ClientSocket != null && ClientSocket.Connected)
            {
                var packet = new Packet { DeviceId = (int)numDeviceId.Value, Humidity = Math.Round(humidity, 1), Temperature = Math.Round(temperature, 1) };
                string json = JsonConvert.SerializeObject(packet);
                byte[] bytesToSend = Encoding.Default.GetBytes(json);

                var args = new SocketAsyncEventArgs();
                args.SetBuffer(bytesToSend, 0, bytesToSend.Length);
                args.Completed += SendCompleted;
                ClientSocket.SendAsync(args);
            }
        }

        private void SendCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                DisplayMessage($"[{DateTime.Now.ToString("HH:mm:ss")}] Data telah berhasil dikirim.");
            }
            else
            {
                DisplayMessage($"[{DateTime.Now.ToString("HH:mm:ss")}] Data tidak berhasil dikirim.");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var args = new SocketAsyncEventArgs();
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint sendPoint = new IPEndPoint(IPAddress.Any, 9999);
            args.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), Convert.ToInt32(txtPortNo.Text));
            args.Completed += Connected;
            ClientSocket.ConnectAsync(args);
        }

        private void Connected(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                DisplayMessage("Terhubung ke server penerima.");
            }
            else
            {
                DisplayMessage("Tidak terhubung ke server penerima.");
            }
        }

        private void DisplayMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { DisplayMessage(message); }));
            }
            else
            {
                lblMessage.Text = message;
            }
        }
    }
}
