using AutoMapper;
using hr.AutoMapper;

namespace hr.Tests
{
	public class AutoMapperTests
	{
		[Test]
		public void AutomapperConfiguration_IsValid()
		{
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfile<AutoMapperProfile>();
			});

			config.AssertConfigurationIsValid();
		}
	}
}