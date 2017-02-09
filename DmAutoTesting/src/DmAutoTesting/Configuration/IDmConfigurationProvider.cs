namespace DmAutoTesting.Configuration
{
    public interface IDmConfigurationProvider
    {
        DmAutoTestingConfiguration Current { get; }
        void Set(DmAutoTestingConfiguration configuration);
    }
}