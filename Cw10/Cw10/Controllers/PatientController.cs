using Cw10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cw10.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientsController:ControllerBase
{
    private readonly IDbService _dbService;
    
    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
}