using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

//IRepositoryRepository.cs
public interface IRepositoryRepository
{
    Task AddAsync(Registraion registraion);
    Task SaveChangesAsync();
}

//RegistrationRepository.cs
public interface RegistrationRepository : IRepositoryRepository
{
    private readonly ApplicationDbContext _context;

    public RegistrationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Registraion registraion)
    {
        await _context.Registrations.AddAsync(registraion);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}

//IRepositryService.cs
public interface IRegistrationService
{
    Task<Registraion> CreateAsync(int eventId, int userId);
}

//RegistrationService.cs
public class RegistrationService : IRegistrationService
{
    private readonly IRepositoryRepository _repository;

    public RegistrationService(IRepositoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Registraion> CreateAsync(int eventId, int userId)
    {
        var registration = new Registraion
        {
            EventId = eventId,
            UserId = userId,
        };

        await _repository.AddAsync(registration);
        await _repository.SaveChangesAsync();

        return registration;
    }
}

//RegistrationController.cs
[ApiController]
[Route("api/events/{eventId}/registrations")]
public class RegistrationController : ControllerBase
{
    private readonly IRegistrationService _service;

    public RegistrationController(IRegistrationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> Create(int eventId, [FromBody] int userId)
    {
        var registration = await _service.CreateAsync(eventId, userId);
        return StatusCode(201, registration);
    }
}