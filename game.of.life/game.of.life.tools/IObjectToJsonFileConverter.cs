namespace game.of.life.tools
{
    public interface IObjectToJsonFileConverter
    {
        void Save<T>(string fileName, T objetToSave);

        T Load<T>(string fileName);
    }
}