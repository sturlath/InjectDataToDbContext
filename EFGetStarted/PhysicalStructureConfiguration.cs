using EFGetStarted;

namespace PhysicalStructureService.Configurations;

/// <summary>
/// Configuration class for Physicial Structure service.
/// </summary>
public class PhysicalStructureConfiguration : IPhysicalStructureConfiguration
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
