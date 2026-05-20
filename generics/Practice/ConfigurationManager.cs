namespace Practice;

public class ConfigurationManager<T>
{

    public T LoadedConfiguration { get; private set; }

    public ConfigurationManager(T config)
    {
        LoadedConfiguration = config;
    }

    public static void SaveConfig(T configToSave)
    {
        // Implementation for saving the configuration
    }
}