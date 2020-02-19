using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace IntegrationTests
{
    public class TestScenarioBase
    {
        public TestServer CreateServer()
{   
  var webHostBuilder = WebHost.CreateDefaultBuilder();
  webHostBuilder.UseStartup<IStartup>();
  var testServer = new TestServer(webHostBuilder);

  return testServer;
}
    }
}
