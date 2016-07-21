using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(JournalSystemMVC.ReactConfig), "Configure")]

namespace JournalSystemMVC
{
	public static class ReactConfig
	{
		public static void Configure()
		{
			// These scripts are added to enable serverside rendering
		    ReactSiteConfiguration.Configuration = new ReactSiteConfiguration()
		        .AddScript("~/Scripts/ReactScripts/ResidentDetails.jsx")
		        .AddScript("~/Scripts/ReactScripts/JournalDetails.jsx");
		}
	}
}