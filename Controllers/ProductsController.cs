using Microsoft.AspNetCore.Mvc;
using BasicApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace BasicApi.Controller;

[ApiController]
[Route("[controller]")]

public class ProductsController : ControllerBase
{
  private readonly ApplicationDbContext _context;
  public ProductsController(ApplicationDbContext context)
  {
    _context = context;
  }
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
  {
    return await _context.Products.ToListAsync();
  }

  [HttpPost]
  public async Task<ActionResult<Product>> AddProduct(Product product)
  {

    // add new product to DbContext 
    _context.Products.Add(product);

    //save the changes to database
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Product>> GetProduct(int id)
  {

    var product = await _context.Products.FindAsync(id);

    if (product == null)
    {
      return NotFound();
    }

    return product;
  }
  [HttpPost("search")]
  public async Task<ActionResult<IEnumerable<Product>>> SearchProducts([FromBody] ProductQuery query)
  {
    IQueryable<Product> productQuery = _context.Products.AsQueryable();

    if (!string.IsNullOrEmpty(query.Name))
    {
      productQuery = productQuery.Where(p => p.Name.Contains(query.Name));
    }
    if (query.MinPrice.HasValue)
    {
      productQuery = productQuery.Where(p => p.Price >= query.MinPrice.Value);
    }
    if (query.MaxPrice.HasValue)
    {
      productQuery = productQuery.Where(p => p.Price <= query.MaxPrice.Value);
    }
    var products = await productQuery.ToListAsync();
    return Ok(products);
  }
}


// public class ProductsController : ControllerBase {
//     private static readonly List<Product> Products = new List<Product>{
//         new() {Id = 1, Name = "Laptop", Price = 999.95M },
//         new() {Id = 3, Name = "Mouse", Price = 999.95M},
//     };

//     [HttpGet]
//     public IEnumerable<Product> Get() {
//         return Products;
//     }

//     //Additional CRUD Operations can be added here (POST, PUT, DELETE)
// }
