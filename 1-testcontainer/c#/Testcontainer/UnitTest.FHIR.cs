using DotNet.Testcontainers.Builders;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Task = System.Threading.Tasks.Task;

namespace Testcontainer;

public class FhirUnitTest
{
    private const string SAPASSWORD = "yourStrong(!)Password";
    
    [Fact]
    public async Task FhirTest()
    {
        var sqlServerContainer = new ContainerBuilder()
            .WithImage("mcr.microsoft.com/mssql/server")
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithEnvironment("SA_PASSWORD", SAPASSWORD)
            .WithPortBinding(1433, false)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(1433))
            .Build();
        await sqlServerContainer.StartAsync();

        var fhirContainer = new ContainerBuilder()
          .WithImage("mcr.microsoft.com/healthcareapis/r4-fhir-server")
          .DependsOn(sqlServerContainer)
          .WithEnvironment("FHIRServer__Security__Enabled", "false")
          .WithEnvironment("SqlServer__ConnectionString", $"Server=tcp:{sqlServerContainer.IpAddress},{sqlServerContainer.GetMappedPublicPort(1433)};Initial Catalog=FHIR;Persist Security Info=False;User ID=sa;Password={SAPASSWORD};MultipleActiveResultSets=False;Connection Timeout=30;TrustServerCertificate=true;")
          .WithEnvironment("SqlServer__AllowDatabaseCreation", "true")
          .WithEnvironment("SqlServer__Initialize", "true")
          .WithEnvironment("SqlServer__SchemaOptions__AutomaticUpdatesEnabled", "true")
          .WithEnvironment("DataStore", "SqlServer")
          .WithPortBinding(8080, true)
          .WithWaitStrategy(Wait.ForUnixContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(8080)))
          .Build();

        await fhirContainer.StartAsync();

        FhirClient client = new($"http://{fhirContainer.Hostname}:{fhirContainer.GetMappedPublicPort(8080)}");
        Patient patient = new()
        {
            Name = [new HumanName { Family = "Doe", Given = ["John"] }],
            Active = true
        };

        var result = await client.CreateAsync(patient);
        var read = await client.ReadAsync<Patient>($"Patient/{result.Id}");
        Assert.NotNull(result);
        Assert.True(read.Active);
        Assert.Equal("Doe", read.Name[0].Family);
        Assert.Equal("John", read.Name[0].Given.ElementAt(0));
    }
}