namespace game.of.life.domain
{
    public interface IObjectToJsonFileConverter
    {
        void Save<T>(string fileName, T objetToSave);

        T Load<T>(string fileName);
    }
}