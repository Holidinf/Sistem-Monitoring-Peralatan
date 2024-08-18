using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mission3.Model
{
    public class SensorDataFile : IDataSource<SensorData>
    {
        private const string FileName = "SensorRecord.txt";

        public List<SensorData> Load()
        {
            try
            {
                // 1. Baca string JSON yang disimpan dalam file “SensorRecord.txt” di folder yang sama.
                string json = File.ReadAllText(FileName);

                // 2. Kembalikan string ke objek List<SensorData> menggunakan metode kelas JsonConvert.
                List<SensorData> sensorData = JsonConvert.DeserializeObject<List<SensorData>>(json);

                // 3. Jika hasil yang dikembalikan bukan null, List dikembalikan. Jika null, objek List<SensorData> kosong dibuat dan dikembalikan.
                return sensorData ?? new List<SensorData>();
            }
            catch (Exception)
            {
                // Jika terjadi kesalahan (misalnya file tidak ditemukan), kembalikan List<SensorData> kosong.
                return new List<SensorData>();
            }
        }

        public void Save(List<SensorData> list)
        {
            try
            {
                // 1. Konversikan list yang diterima sebagai parameter menjadi string JSON menggunakan metode kelas JsonConvert.
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);

                // 2. Tulis string menggunakan file “SensorRecord.txt” di folder yang sama.
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                // Tangani kesalahan jika diperlukan, misalnya log atau tampilkan pesan kesalahan.
                Console.WriteLine($"Error saving sensor data: {ex.Message}");
            }
        }

        public Task SaveAsync(List<SensorData> list)
        {
            // 1. Kode untuk memanggil metode Save() yang ditulis di atas secara asinkron menggunakan metode Task.Factory.StartNew().
            return Task.Factory.StartNew(() => Save(list));
        }
    }
}
