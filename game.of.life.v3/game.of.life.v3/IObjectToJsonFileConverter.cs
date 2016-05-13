namespace game.of.life.v3
{
    public interface IObjectToJsonFileConverter
    {
        void Save<T>(string fileName, T objetToSave);
        T Load<T>(string fileName);
    }
}