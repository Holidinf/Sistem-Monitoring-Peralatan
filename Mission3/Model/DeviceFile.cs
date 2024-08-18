using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Mission3.Model
{
    public class DeviceFile : IDataSource<Device>
    {
        private const string FileName = "Device.txt";

        public List<Device> Load()
        {
            try
            {
                // 1. Baca string JSON yang disimpan dalam file “Device.txt” di folder yang sama.
                string json = File.ReadAllText(FileName);

                // 2. Kembalikan string ke objek List<Device> menggunakan metode kelas JsonConvert.
                List<Device> devices = JsonConvert.DeserializeObject<List<Device>>(json);

                // 3. Jika hasil yang dikembalikan bukan null, List dikembalikan. Jika null, objek List<Device> kosong dibuat dan dikembalikan.
                return devices ?? new List<Device>();
            }
            catch (Exception)
            {
                // Jika terjadi kesalahan (misalnya file tidak ditemukan), kembalikan List<Device> kosong.
                return new List<Device>();
            }
        }

        public void Save(List<Device> list)
        {
            try
            {
                // 1. Konversikan list yang diterima sebagai parameter menjadi string JSON menggunakan metode kelas JsonConvert.
                string json = JsonConvert.SerializeObject(list, Formatting.Indented);

                // 2. Tulis string menggunakan file “Device.txt” di folder yang sama.
                File.WriteAllText(FileName, json);
            }
            catch (Exception ex)
            {
                // Tangani kesalahan jika diperlukan, misalnya log atau tampilkan pesan kesalahan.
                Console.WriteLine($"Error saving devices: {ex.Message}");
            }
        }

        public Task SaveAsync(List<Device> list)
        {
            // 1. Kode untuk memanggil metode Save() yang ditulis di atas secara asinkron menggunakan metode Task.Factory.StartNew().
            return Task.Factory.StartNew(() => Save(list));
        }
    }
}
