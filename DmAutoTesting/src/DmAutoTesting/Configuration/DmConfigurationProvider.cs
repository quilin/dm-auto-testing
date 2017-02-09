namespace DmAutoTesting.Configuration
{
    public class DmConfigurationProvider : IDmConfigurationProvider
    {
        private readonly object syncObject = new object();
        private DmAutoTestingConfiguration configuration;

        public DmAutoTestingConfiguration Current
        {
            get
            {
                if (configuration == null)
                {
                    lock (syncObject)
                    {
                        if (configuration != null)
                        {
                            return configuration;
                        }
                    }
                }
                return configuration;
            }
        }

        public void Set(DmAutoTestingConfiguration configuration)
        {
            this.configuration = configuration;
        }
    }
}