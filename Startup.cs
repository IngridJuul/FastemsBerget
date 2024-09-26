/* using Microsoft.AspNetCore.Builder;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;
 
public class Startup

{

    public void ConfigureServices(IServiceCollection services)

    {

        // Add other services (e.g., MVC, RazorPages, etc.)

        services.AddControllers(); // or services.AddRazorPages();

    }
 
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)

    {

        if (env.IsDevelopment())

        {

            app.UseDeveloperExceptionPage();

        }

        else

        {

            app.UseExceptionHandler("/Home/Error"); // Replace with your error page

            app.UseHsts();

        }
 
        // This line is critical for forwarding HTTP headers from ngrok or any reverse proxy.

        app.UseForwardedHeaders(new ForwardedHeadersOptions

        {

            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto

        });
 
        app.UseHttpsRedirection(); // Ensure this is registered after UseForwardedHeaders.

        app.UseStaticFiles();
 
        app.UseRouting();
 
        app.UseAuthorization();
 
        app.UseEndpoints(endpoints =>

        {

            endpoints.MapControllers(); // or endpoints.MapRazorPages();

        });

    }

} */