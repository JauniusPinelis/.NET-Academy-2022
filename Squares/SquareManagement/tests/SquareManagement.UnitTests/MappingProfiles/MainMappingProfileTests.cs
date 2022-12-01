using AutoMapper;
using NUnit.Framework;
using SquareManagement.WebApi.MappingProfiles;

namespace SquareManagement.UnitTests.MappingProfiles
{
    public class MainMappingProfileTests
    {
        [Test]
        public void AutoMapper_ConvertFromByte_IsValid()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MainMappingProfile());
            });
            mappingConfig.AssertConfigurationIsValid();
        }
    }
}
