namespace SharedLibrary.DTOs;

public class OrderDetailsDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}