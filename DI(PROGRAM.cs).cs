//Dependency Injection (Program.cs)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IEventRepository, RegistrationRepository>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();