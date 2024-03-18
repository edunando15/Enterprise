
/*using Esame_Enterprise.Application.Extensions;
using Esame_Enterprise.Web.Extensions;
using Model.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddWebServices()
    .AddSwaggerServices()
    .AddSecurityServices(builder.Configuration)
    .AddModelServices(builder.Configuration)
    .AddApplicationServices();
var app = builder.Build();
app.AddWebMiddleware();
app.Run();*/
using Esame_Enterprise.Application.Options;
using Esame_Enterprise.Application.Services;
using Model.Context;
using Model.Repositories;

var context = new LibraryContext();
var bookRepo = new BookRepository(context);
var catRepo = new CategoryRepository(context);
var bookCatRepo = new BookCategoryRepository(context);
var userRepo = new UserRepository(context);

var bookService = new BookService(bookRepo, bookCatRepo, catRepo);
var catService = new CategoryService(catRepo, bookCatRepo);
catService.AddCategory(new Esame_Enterprise.Application.Models.Dto.CategoryDto() { Name = "Documentario" });
