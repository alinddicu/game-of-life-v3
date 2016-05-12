namespace game.of.life.v3
{
    public interface IGridLoader
    {
        void SaveToAppFolder<T>(string fileName, T objetToSave);
        T LoadFromAppFolder<T>(string fileName);
    }
}