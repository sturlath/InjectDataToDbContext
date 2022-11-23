using EFGetStarted;


public class MyConfiguration : IMyConfiguration
{
    /// <summary>
    /// Connection string to database.
    /// </summary>
    public string? ConnectionString { get; set; }

    /// <summary>
    /// Gets or sets whether the service is configured for cloud.
    /// </summary>
    public bool CloudEnabled { get; set; }

}
