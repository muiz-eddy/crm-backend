using AdminApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers;

[ApiController]
[Route("[controller]")]

public class AdminController : ControllerBase
{

  private readonly ApplicationDbContext _context;
  public AdminController(ApplicationDbContext context)
  {
    _context = context;
  }
  [HttpPost("admin")]
  public async Task<ActionResult<IEnumerable<AdminClass>>> SearchAdmin([FromBody] AdminClass query)
  {
    IQueryable<AdminClass> AdminQuery = _context.Admins.AsQueryable();

    if (!string.IsNullOrEmpty(query.Email) && !string.IsNullOrEmpty(query.Password))
    {

    }

    return null;
  }

}
