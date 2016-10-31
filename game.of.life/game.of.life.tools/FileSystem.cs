namespace game.of.life.tools
{
    using System.IO;

    public class FileSystem : IFileSystem
    {
        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void FileWriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        public string FileReadAllText(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
