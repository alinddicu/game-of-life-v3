namespace game.of.life.v3
{
    using Newtonsoft.Json;
    using System.IO;

    public class GridLoader : IGridLoader
    {
        private readonly IFileSystem _fileSystem;
        private readonly string _baseDirPath;

        public GridLoader(IFileSystem fileSystem, string baseDirPath)
        {
            _fileSystem = fileSystem;
            _baseDirPath = baseDirPath;

            if (!_fileSystem.DirectoryExists(_baseDirPath))
            {
                _fileSystem.CreateDirectory(_baseDirPath);
            }
        }

        public void SaveToAppFolder<T>(string fileName, T objetToSave)
        {
            var filePath = Path.Combine(_baseDirPath, fileName + ".json");
            var jsonContent = JsonConvert.SerializeObject(objetToSave);
            _fileSystem.FileWriteAllText(filePath, jsonContent);
        }

        public T LoadFromAppFolder<T>(string fileName)
        {
            var filePath = Path.Combine(_baseDirPath, fileName + ".json");
            if (!_fileSystem.FileExists(filePath))
            {
                return default(T);
            }

            var jsonContent = _fileSystem.FileReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }
    }
}
