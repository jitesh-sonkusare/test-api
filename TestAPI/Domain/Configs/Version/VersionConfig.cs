using System.ComponentModel.DataAnnotations;

namespace Domain.Configs.Version;

public record VersionConfig
{
    public const string SectionName = "VersionConfig";

    [Required(ErrorMessage = "VersionConfig - Version should not be null/empty.")]
    public string Version { get; set; } = string.Empty;
}
