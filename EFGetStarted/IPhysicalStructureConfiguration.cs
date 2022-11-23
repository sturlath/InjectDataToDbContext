namespace EFGetStarted;

/// <summary>
/// Interface defining configurations for Physicial Structure service.
/// </summary>
public interface IPhysicalStructureConfiguration
{
    /// <summary>
    /// Connection string to database.
    /// </summary>
    string? ConnectionString { get; set; }

    /// <summary>
    /// Gets or sets whether the service is configured for cloud.
    /// </summary>
    bool CloudEnabled { get; set; }
}
