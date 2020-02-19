using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests
{
    public class TestScenarios: TestScenarioBase
    {
        [Fact]
        public async Task GetTest()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                .GetAsync($"api/values/5");

                Assert.Equal("value", await response.Content.ReadAsStringAsync());
            }
        }
    }
}
