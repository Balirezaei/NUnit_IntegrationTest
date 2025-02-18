using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit_Api_Testing.Service;
using System.Net;
using FluentAssertions;

using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NUnit_Api_Testing.Model;

namespace IntegrationTest
{
    public class ProductApiTests
    {

        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
            {

                builder.UseEnvironment("IntegrationTest").ConfigureAppConfiguration(configurationBuilder =>
                {
                    var integrationConfig = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddEnvironmentVariables()
                        .Build();

                    configurationBuilder.AddConfiguration(integrationConfig);
                });

                builder.ConfigureServices((builder, services) =>
                {
                    var config = builder.Configuration;


                    services.Remove<ILocalLogger>()
                         .AddScoped(options =>
                         {
                             return NSubstitute.Substitute.For<ILocalLogger>();

                         });



                    var app = services.BuildServiceProvider();



                    //using (var scope = app.CreateScope())
                    //{

                    //}
                });

            });

            _client = _factory.CreateClient();
        }

        [Test]
        public async Task We_Can_Get_Product_List_Throw_API_Call()
        {
            //Fixture
            var url = "/api/Product";


            //Exercise
            var response = await _client.GetAsync(url);


            //Verification
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Product>>(responseString);
            result.Count.Should().BeGreaterThan(0);
        }


        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}