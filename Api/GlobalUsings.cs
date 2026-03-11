global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Caching.Distributed;

global using Application.Common.Logging;
global using Application.Common.Exceptions;
global using Application.Common.Models;
global using Application.Common.Interfaces;
global using Application.Orders.Create;
global using Application.Features.Authenticates.Dtos;
global using Application.Features.Authenticates.Commands.SendRegisterOtp;
global using Application.Features.Authenticates.Commands.VerifyOtp;
global using Application.Features.Accounts.Queries;
global using Application.Features.Accounts.Dtos;
global using Application.Features.Devices.Dtos;
global using Application.Features.Devices.Commands.CreateDevice;
global using Application.Features.Devices.Commands.DeleteDevice;
global using Application.Features.Devices.Queries.GetDevices;
global using Application.Features.Excel.Commands.ImportExcel;
global using Application.Features.Excel.Queries.ExportExcel;

global using Infrastructure.Services;

global using Serilog;
global using Carter;
global using MediatR;
global using FluentValidation;
global using Hangfire;
global using Hangfire.Dashboard;