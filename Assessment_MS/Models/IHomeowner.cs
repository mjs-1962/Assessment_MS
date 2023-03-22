namespace Assessment_MS.Models
{
    public interface IHomeowner
    {
        string? FullName { get; set; }
        string? EmailAddress { get; set; }
        string? AddressLine1 { get; set; }
        string? AddressLine2 { get; set; }
        string? Town { get; set; }
        string? County { get; set; }
        string? Postcode { get; set; }
    }
}
