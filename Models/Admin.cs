namespace AdminApi.Models;

public class AdminClass
{
  public int Id { get; set; }
  public string? Email { get; set; }
  public string? Password { get; set; }
  public string? Token { get; set; } //session
}
