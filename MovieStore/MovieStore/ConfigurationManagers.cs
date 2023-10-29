namespace MovieStore
{
    static class ConfigurationManagers
    {
        public static IConfiguration Appsetting { get; }
        static ConfigurationManagers()
        {
            Appsetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
