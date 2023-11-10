namespace Genresponse.CustomResponse.Models;
public class GenericApiResponse<T>
{

  public bool Status { get; set; }
  public string? Message { get; set; }
  public T Data { get; set; }

  public GenericApiResponse(bool status, string message, T data)
  {
    this.Status = status;
    this.Message = message;
    this.Data = data;
  }
}
