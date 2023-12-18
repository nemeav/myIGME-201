using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Final_Q6
{
    public class PlayerSettings
    {
        //fields
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public string[] Inventory { get; set; }
        public string LicenseKey { get; set; }

        private static PlayerSettings instance;

        //priv construct
        private PlayerSettings() { }

        //mtds
        public static PlayerSettings GetInstance()
        {
            if (instance == null)
            {
                instance = new PlayerSettings();
            }
            return instance;
        }

        public void LoadSettings(string filePath) //kept generic for location reasons
        {
            try
            {
                StreamReader reader = new StreamReader(filePath);
                string json = reader.ReadToEnd();
                instance = JsonConvert.DeserializeObject<PlayerSettings>(json);
                reader.Close();
            }
            catch
            {
                
            }
        }

        public void SaveSettings(string filePath)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                string json = JsonConvert.SerializeObject(instance, Formatting.Indented);
                writer.Write(json);
                writer.Close();
            }
            catch
            {
                
            }
        }
    }
}
