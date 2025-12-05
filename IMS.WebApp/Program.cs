using IMS.CoreBusiness;
using IMS.Plugins.EfCore;
using IMS.Plugins.EFCore;
using IMS.UseCases.CustomerPrices;
using IMS.UseCases.CustomerPrices.Interfaces;
using IMS.UseCases.Customers;
using IMS.UseCases.Customers.Interfaces;
using IMS.UseCases.Inventories;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Report;
using IMS.UseCases.Report.Interfaces;
using IMS.UseCases.Voucher;
using IMS.UseCases.Voucher.Interfaces;
using IMS.WebApp.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<IMSDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
}
);
builder.Services.AddScoped<ICustomerRepository, EFCustomerRepository>();
builder.Services.AddScoped<IInventoryRepository, EFInventoryRepository>();
builder.Services.AddScoped<ICustomerPriceRepository, EFCustomerPriceRepository>();
builder.Services.AddScoped<IReportsRepository, EFReportsRepository>();
builder.Services.AddScoped<IVouchersRepository, EFVouchersRepository>();

builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IGetInventoryByIdUseCase, GetInventoryByIdUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IDeleteInventoryUseCase, DeleteInventoryUseCase>();
builder.Services.AddTransient<IUpdateInventoryUseCase, UpdateInventoryUseCase>();
builder.Services.AddTransient<ICheckForInventoryItemUseCase, CheckForInventoryItemUseCase>();

builder.Services.AddTransient<IGetCustomerAndInventoryUseCase, GetCustomerAndInventoryUseCase>();
builder.Services.AddTransient<IViewCustomersByNameUseCase, ViewCustomersByNameUseCase>();
builder.Services.AddTransient<IAddCustomerUseCase, AddCustomerUseCase>();
builder.Services.AddTransient<IAddCustomerPriceUseCase, AddCustomerPriceUseCase>();
builder.Services.AddTransient<IGetCustomerByIdUseCase, GetCustomerByIdUseCase>();
builder.Services.AddTransient<IGetCustomerPriceItemsUseCase, GetCustomerPriceItemsUseCase>();
builder.Services.AddTransient<IEditCustomerPriceUseCase, EditCustomerPriceUseCase>();
builder.Services.AddTransient<IEditCustomerUseCase, EditCustomerUseCase>();
builder.Services.AddTransient<IRemoveCustomerPriceUseCase, RemoveCustomerPriceUseCase>();
builder.Services.AddTransient<IAddCustomerPriceItemUseCase, AddCustomerPriceItemUseCase>();
builder.Services.AddTransient<IRemoveCustomerPricesUseCase, RemoveCustomerPricesUseCase>();
builder.Services.AddTransient<IRemoveCustomerUseCase, RemoveCustomerUseCase>(); 

builder.Services.AddTransient<IGetAllReportsUseCase, GetAllReportsUseCase>();
builder.Services.AddTransient<IAddVoucherUseCase, AddVoucherUseCase>();
builder.Services.AddTransient<ICreateReportUseCase, CreateReportUseCase>();
builder.Services.AddTransient<IUpdateVoucherUseCase, UpdateVoucherUseCase>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
