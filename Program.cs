using dotnet_rpg.Services.CharacterService;

var builder = WebApplication.CreateBuilder(args);
/*
 The WebApplication.CreateBuilder(args) method creates a new WebApplicationBuilder instance and passes in any command-line arguments that were provided when starting the application as the args parameter. The WebApplicationBuilder instance is used to configure the WebApplication instance with various services, middleware, and other settings.

After this line of code is executed, the builder variable contains an instance of the WebApplicationBuilder class, which can be used to further configure the WebApplication instance before it is built and started.
*/
// Add services to the container.

builder.Services.AddControllers();
/*
 *
 * In a C# program, the builder.Services.AddControllers() line of code adds the MVC (Model-View-Controller) service to the WebApplication instance's service container.

The AddControllers() method is an extension method provided by the Microsoft.AspNetCore.Mvc.Core package, which adds support for controllers to the application. By adding this service to the container, the application can now create and use controllers to handle incoming HTTP requests.

The AddControllers() method also adds additional services that are required for the MVC framework to function properly, such as model binding, input/output formatters, and routing. These services are added to the application's service container so that they can be injected into controllers as needed.

Overall, this line of code sets up the WebApplication instance to handle incoming HTTP requests using the MVC pattern, allowing developers to define controllers and actions to handle specific requests.
 */

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*
 * In a C# program, the builder.Services.AddEndpointsApiExplorer() line of code adds the API Explorer service to the WebApplication instance's service container.

The AddEndpointsApiExplorer() method is an extension method provided by the Microsoft.AspNetCore.Mvc.ApiExplorer package, which adds support for generating documentation for the API endpoints defined in the application. By adding this service to the container, the application can generate Swagger/OpenAPI specification for the API endpoints.

The API Explorer service provides metadata about the API endpoints, such as their names, descriptions, and supported HTTP methods. This metadata can be used to generate interactive API documentation, client SDKs, and other tools that consume the API.

After adding the API Explorer service, the application can use the Swagger UI or other OpenAPI tools to view and interact with the API documentation.
 */
builder.Services.AddSwaggerGen();
/*
 * In a C# program, the builder.Services.AddSwaggerGen() line of code adds the Swagger generator service to the WebApplication instance's service container.

The AddSwaggerGen() method is an extension method provided by the Swashbuckle.AspNetCore.SwaggerGen package, which adds support for generating Swagger/OpenAPI specifications for the API endpoints defined in the application. By adding this service to the container, the application can generate Swagger/OpenAPI specification for the API endpoints.

The Swagger generator service works by examining the application's endpoints and generating Swagger/OpenAPI specification for them. This specification includes information such as the endpoint's URL, HTTP methods it supports, request and response models, and so on.

After adding the Swagger generator service, the application can use it to generate the Swagger/OpenAPI specification and provide it to clients of the API. Clients can use this specification to understand how to interact with the API and generate client SDKs or other tools that consume the API.

Overall, this line of code sets up the WebApplication instance to generate Swagger/OpenAPI specification for the API endpoints, allowing developers to easily document and share information about the API.
 */
builder.Services.AddAutoMapper(typeof(Program).Assembly);
/*
 * In a C# program, the builder.Services.AddAutoMapper(typeof(Program).Assembly) line of code adds the AutoMapper service to the WebApplication instance's service container.

The AddAutoMapper() method is an extension method provided by the AutoMapper.Extensions.Microsoft.DependencyInjection package, which adds support for mapping objects between different types. By adding this service to the container, the application can use AutoMapper to simplify mapping data between different objects.

The typeof(Program).Assembly argument specifies the assembly that contains the types to be mapped. In this case, it is the assembly that contains the Program class.

After adding the AutoMapper service, the application can define mappings between objects using the AutoMapper API. This allows developers to easily map data from one type to another without writing custom mapping code.

Overall, this line of code sets up the WebApplication instance to use AutoMapper for object mapping, which can simplify data manipulation and reduce development time.
 */

builder.Services.AddScoped<ICharacterService, CharacterService>();
/*
 * In a C# program, the builder.Services.AddScoped<ICharacterService, CharacterService>() line of code registers a new service in the WebApplication instance's service container.

The AddScoped() method is an extension method provided by the Microsoft.Extensions.DependencyInjection package, which adds a new service to the container with a scoped lifetime. This means that a new instance of the service will be created for each HTTP request.

The ICharacterService interface is the service type that will be registered, and CharacterService is the concrete type that will be used to implement the service. By registering the ICharacterService interface with the CharacterService concrete type, the service container will be able to create instances of the CharacterService class whenever an ICharacterService instance is requested.

This line of code effectively creates a dependency injection mapping between the ICharacterService interface and the CharacterService class. This enables other components of the application to receive instances of the ICharacterService interface through constructor injection or other means, which allows them to use the functionality provided by the CharacterService class.

Overall, this line of code sets up the WebApplication instance to use dependency injection to provide instances of the ICharacterService interface, which allows for easier and more modular development.
 */
var app = builder.Build();
/*
 * In a C# program, the var app = builder.Build() line of code creates a new WebApplication instance by building the WebApplicationBuilder instance created earlier using the WebApplication.CreateBuilder(args) method.

The Build() method is a method of the WebApplicationBuilder class, which creates and configures a new instance of the WebApplication class. The WebApplication class represents the entry point of the application and is responsible for handling HTTP requests and responses.

The builder object created using the WebApplication.CreateBuilder(args) method contains all of the configuration for the WebApplication instance, including registered services, middleware, and routing. Calling the Build() method on this object creates a new WebApplication instance with this configuration.

After creating the WebApplication instance, the application can be started by calling the Run() method on the instance. Alternatively, the WebApplication instance can be used to configure additional middleware, services, or routes before starting the application.

Overall, this line of code creates a new WebApplication instance and sets it up with the configuration defined in the WebApplicationBuilder instance, allowing the application to handle HTTP requests and responses.
 */

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
/*
 * this just automatically redirects HTTP requests to HTTPS
 */

app.UseAuthorization();

app.MapControllers();

app.Run();
