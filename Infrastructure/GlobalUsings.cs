global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Design;

global using Infrastructure.Data;
global using Infrastructure.Repositories;
global using Infrastructure.Jobs;
global using Infrastructure.Logging;

global using Application.Common.Interfaces;
global using Application.Common.Logging;

global using Domain.Entities;

global using Hangfire;
global using Hangfire.PostgreSql;