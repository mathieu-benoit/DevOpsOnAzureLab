namespace MainWebApplication.Services
{
    public interface IConfigurationService
    {
        bool IsRandomAdditionEnable();
        string GetRandomAdditionUrl();
    }
}
