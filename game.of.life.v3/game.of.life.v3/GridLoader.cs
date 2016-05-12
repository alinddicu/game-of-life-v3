namespace game.of.life.v3
{
    using System;
    using Newtonsoft.Json;
    using System.IO;

    public class GridLoader
    {
        public void SaveToAppFolder<T>(string fileName, T objetToSave)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".json");
            var jsonContent = JsonConvert.SerializeObject(objetToSave);
            File.WriteAllText(filePath, jsonContent);
        }

        public T LoadFromAppFolder<T>(string fileName)
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".json");
            if (!File.Exists(filePath))
            {
                return default(T);
            }

            var jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
