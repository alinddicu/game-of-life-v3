﻿namespace game.of.life.tools
{
    public interface IFileSystem
    {
        bool DirectoryExists(string path);

        void CreateDirectory(string path);

        bool FileExists(string filePath);

        void FileWriteAllText(string path, string contents);

        string FileReadAllText(string filePath);
    }
}