namespace Genresponse.CustomResponse.Models;
public class GenericApiResponse<AdminClass>
{

  public bool Status { get; set; }
  public string? Message { get; set; }
  public AdminClass Data { get; set; }

  public GenericApiResponse(bool status, string message, AdminClass data)
  {
    this.Status = status;
    this.Message = message;
    this.Data = data;
  }
}
