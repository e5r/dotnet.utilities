using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
	using E5R.DotNet.Utilities.AspNetCore.SPA;

	public static class SPAServiceCollectionExtensions
	{
		const string CONFIGURATION_SECTION_NAME = "E5R:SPA";

		public static IServiceCollection AddSPAOptions(this IServiceCollection services, SPAOptions options)
		{
			return services.Configure<SPAOptions>(opt =>
			{
				opt.BootstrapperPath = options.BootstrapperPath;
				opt.AppPath = options.AppPath;
				opt.LibPath = options.LibPath;
				opt.StaticPath = options.StaticPath;

				opt.BootstrapperPhysicalPath = options.BootstrapperPhysicalPath;
				opt.AppPhysicalPath = options.AppPhysicalPath;
				opt.LibPhysicalPath = options.LibPhysicalPath;
				opt.StaticPhysicalPath = options.StaticPhysicalPath;
			});
		}

		public static IServiceCollection AddSPAOptions(this IServiceCollection services, IConfigurationRoot configuration)
		{
			return services.Configure<SPAOptions>(configuration.GetSection(CONFIGURATION_SECTION_NAME));
		}
	}
}
