using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Taxually.TechnicalTest.Models;

public class VatRegistrationRequest
{
    [Required]
    [StringLength(1000)]
    public string CompanyName { get; set; }
    
    [Required]
    [StringLength(1000)]
    public string CompanyId { get; set; }
    
    [Required]
    public Country Country { get; set; }
}

/// <summary>
/// ISO 3166-1 alpha-2 country code.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Country
{
    Gb,
    Fr,
    De
}