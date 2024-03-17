using Esame_Enterprise.Application.Extensions;
using Esame_Enterprise.Application.Models.Dto;
using Esame_Enterprise.Application.Services;
using Esame_Enterprise.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Model.Context;
using Model.Entities;
using Model.Extensions;
using Model.Repositories;




LibraryContext context = new LibraryContext();
BookRepository bookRepository = new BookRepository(context);
CategoryRepository categoryRepository = new CategoryRepository(context);
BookCategoryRepository bookCategoryRepository = new BookCategoryRepository(context);
UserRepository userRepository = new UserRepository(context);
BookService bookService = new BookService(bookRepository, bookCategoryRepository, new CategoryRepository(context));

CategoryService categoryService = new CategoryService(categoryRepository, bookCategoryRepository);

if (categoryService.AddCategory(new CategoryDto() { Name = "filosofia" })) Console.WriteLine("TRUE");
else Console.WriteLine("FALSE");
var c = categoryService.GetCategories();
foreach (var category in c) Console.WriteLine(category.Name);

BookDto bookDto = new BookDto();
bookDto.Id = bookRepository.GetByName("Siddharta").FirstOrDefault().Id;
bookDto.Name = "Siddharta";
bookDto.Author = "Dan";
bookDto.Publisher = "Feltrinelli";
bookDto.PublicationDate = DateTime.Parse("01/01/2000");
bookDto.Categories = new List<CategoryDto>()
{
    new CategoryDto() { Name = "guerra" },
    new CategoryDto() { Name = "Fantascienza" }
};

//if (bookService.AddBook(bookDto)) Console.WriteLine("Libro aggiunto");
//else Console.WriteLine("Libro non aggiunto");
//bookService.DeleteBook(bookDto);

var tot = 0;
var res = bookService.GetBooks(0, 5, "", out tot, "", "", null, new CategoryDto() { Name = "filosofia"}) ;
foreach (var item in res)
{
    Console.WriteLine(item.Name);
    Console.WriteLine(item.Author);
    Console.WriteLine(item.Publisher);
    Console.WriteLine(item.PublicationDate);
}
Console.WriteLine(tot);

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddWebServices()
    .AddSecurityServices(builder.Configuration)
    .AddModelServices(builder.Configuration)
    .AddApplicationServices();
var app  = builder.Build();
app.AddWebMiddleware();
app.Run();