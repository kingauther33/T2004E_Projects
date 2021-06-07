using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Project_FastFood.Services
{
    class FileHandleService
    {
        public static async void WriteFile(string filename, string content)
        {
            var storage = ApplicationData.Current.LocalFolder; // tìm đến nơi lưu trữ file trong PC (temp)
            var demoFile = await storage.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(demoFile, content);
        }

        public static async Task<string> ReadFile(string filename)
        {
            var storage = ApplicationData.Current.LocalFolder;
            var demoFile = await storage.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            return await FileIO.ReadTextAsync(demoFile);
        }
    }
}
