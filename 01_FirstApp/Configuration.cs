using Microsoft.Extensions.Options;

namespace _01_FirstApp;

public class ApplicationSettings
{
    public string BaseUrl { get; set; }
    
}

public class ApplicationSettingsOptions : IConfigureOptions<ApplicationSettings>
{
    private IConfiguration _configuration;

    public ApplicationSettingsOptions(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(ApplicationSettings options)
    {
        _configuration.GetSection(nameof(ApplicationSettings)).Bind(options);
    }
}