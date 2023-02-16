using AutoMapper;
using hr.AutoMapper;

namespace hr.Tests
{
	public class AutoMapperTests
	{

		[SetUp]
		public void Setup()
		{
		}

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