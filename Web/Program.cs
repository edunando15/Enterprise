﻿using Esame_Enterprise.Application.Extensions;
using Esame_Enterprise.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Model.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddWebServices()
    .AddSwaggerServices()
    .AddSecurityServices(builder.Configuration)
    .AddModelServices(builder.Configuration)
    .AddApplicationServices();
var app  = builder.Build();
app.AddWebMiddleware();
app.Run();