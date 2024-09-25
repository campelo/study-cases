using MongoDB.Driver;
using Testcontainers.MongoDb;

namespace Testcontainer;

public class MongoSecondTest
{
    [Theory]
    [InlineData("mongo:5.0")]
    [InlineData("mongo:latest")]
    public async Task DefaultFlow(string mongoVersion)
    {
        MongoDbContainer mongoDbContainer = null;
        try
        {
            mongoDbContainer = new MongoDbBuilder()
                .WithImage(mongoVersion)
                //.WithImage($"mongodb/mongodb-community-server:{mongoVersion}")
                //.WithPortBinding(27017, false)
                //.WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(27017))
                //.WithCleanUp(true)
                //.WithAutoRemove(true)
                //.WithReuse(true)
                .Build();
            await mongoDbContainer.StartAsync();

            var client = new MongoClient(mongoDbContainer.GetConnectionString());
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<Animal>("test");
            collection.InsertOne(new Animal { Name = "Cat", Type = "Mammal" });
            collection.InsertOne(new Animal { Name = "Dog", Type = "Mammal" });

            var animals = await collection.Find(_ => true).ToListAsync();
            Assert.Equal(2, animals.Count);
        }
        finally
        {
            //if (mongoDbContainer != null)
            //{
            //    await mongoDbContainer.StopAsync().ConfigureAwait(false);
            //    await mongoDbContainer.DisposeAsync().ConfigureAwait(false);
            //}
        }
    }
}
