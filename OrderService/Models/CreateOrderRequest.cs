using System.ComponentModel.DataAnnotations;

public class CreateOrderRequest
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string Product { get; set; } = string.Empty;

    [Required]
    [Range(1, 1000)]
    public int Quantity { get; set; }

    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; } = string.Empty;
}


