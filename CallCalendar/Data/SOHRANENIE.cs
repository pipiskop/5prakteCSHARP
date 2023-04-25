using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace YukiPesik.Data
{
    static class SOHRANENIE
    {
        public static void BARACUDA(VIBOR_POLZOVATELYA choose)
        {
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves");
            Directory.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, $"{choose.date:dd-MM-yyyy}.json");

            if (choose.items.Count == 0)
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                return;
            }

            string json = JsonSerializer.Serialize(choose.items);

            File.WriteAllText(filePath, json);
        }

        public static VIBOR_POLZOVATELYA LoadUserChoose(DateOnly date)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "saves", $"{date:dd-MM-yyyy}.json");

            var choose = new VIBOR_POLZOVATELYA(date);

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                choose.items = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }

            return choose;
        }
    }
}
