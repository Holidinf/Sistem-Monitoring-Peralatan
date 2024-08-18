using Mission3.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks; // Untuk Task

namespace Mission4.Business
{
    public class SensorMonitoringBiz
    {
        private static SensorMonitoringBiz sensorMonitoringBiz;
        private List<Device> deviceList;
        private Dictionary<int, Device> deviceMap;
        private List<SensorData> sensorDataList;
        private IDataSource<SensorData> sensorDataFile;
        private IDataSource<Device> deviceFile;

        // Konstruktor privat untuk mencegah instansiasi dari luar
        private SensorMonitoringBiz()
        {
            deviceList = new List<Device>();
            deviceMap = new Dictionary<int, Device>();
            sensorDataList = new List<SensorData>();
        }

        // Metode statis publik untuk mendapatkan instance singleton
        public static SensorMonitoringBiz GetInstance()
        {
            if (sensorMonitoringBiz == null)
            {
                sensorMonitoringBiz = new SensorMonitoringBiz();
            }
            return sensorMonitoringBiz;
        }

        public void SetSensorDataFile(IDataSource<SensorData> dataSource)
        {
            sensorDataFile = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }

        public void SetDeviceFile(IDataSource<Device> dataSource)
        {
            deviceFile = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
        }

        public void LoadData()
        {
            if (sensorDataFile != null)
            {
                sensorDataList = sensorDataFile.Load();
            }
            else
            {
                sensorDataList = new List<SensorData>();
            }

            if (deviceFile != null)
            {
                deviceList = deviceFile.Load();
                deviceMap = PutToDeviceMap(deviceList);
            }
            else
            {
                deviceList = new List<Device>();
                deviceMap = new Dictionary<int, Device>();
            }
        }

        private Dictionary<int, Device> PutToDeviceMap(List<Device> deviceList)
        {
            var deviceMap = new Dictionary<int, Device>();

            foreach (var device in deviceList)
            {
                deviceMap[device.DeviceId] = device;
            }

            return deviceMap;
        }

        public List<SensorData> GetSensorData(Func<SensorData, bool> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter));

            var list = new List<SensorData>();

            foreach (var data in sensorDataList)
            {
                if (filter(data))
                {
                    list.Add(data);
                }
            }

            return list;
        }

        public void AddDevice(Device device)
        {
            if (device == null) throw new ArgumentNullException(nameof(device));

            deviceList.Add(device);
            deviceMap[device.DeviceId] = device;

            if (deviceFile != null)
            {
                deviceFile.Save(deviceList);
            }
        }

        public void AddSensorData(SensorData sensorData)
        {
            if (sensorData == null) throw new ArgumentNullException(nameof(sensorData));

            sensorDataList.Add(sensorData);
        }

        public List<Device> GetDeviceList()
        {
            return new List<Device>(deviceList); // Mengembalikan salinan untuk menghindari modifikasi
        }

        public Dictionary<int, Device> GetDeviceMap()
        {
            return new Dictionary<int, Device>(deviceMap); // Mengembalikan salinan untuk menghindari modifikasi
        }

        public async Task SaveToDataSourceAsync()
        {
            if (sensorDataFile != null)
            {
                await sensorDataFile.SaveAsync(sensorDataList);
            }
            if (deviceFile != null)
            {
                await deviceFile.SaveAsync(deviceList);
            }
        }
    }
}
