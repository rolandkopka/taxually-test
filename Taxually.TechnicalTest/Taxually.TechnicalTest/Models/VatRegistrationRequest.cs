using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Taxually.TechnicalTest.Models;

public class VatRegistrationRequest
{
    [Required]
    [StringLength(1000, MinimumLength = 1)]
    public string CompanyName { get; set; }
    
    [Required]
    [StringLength(1000, MinimumLength = 5)]
    public string CompanyId { get; set; }
    
    [Required]
    [EnumDataType(typeof(Country), ErrorMessage = "Invalid or missing country code.")]
    public Country Country { get; set; }
}

/// <summary>
/// ISO 3166-1 alpha-2 country code.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Country
{
    Gb = 1, // =1 to make the default value 0 invalid
    Fr,
    De
}