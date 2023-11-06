namespace BasicApi.Models;

public class ProductQuery
{

  //Properties that represent search  critiera 
  public string Name { get; set; }
  public decimal? MinPrice { get; set; }
  public decimal? MaxPrice { get; set; }

}
