using System.Linq;
using Microsoft.Azure.Cosmos;

namespace noisyadmin.sitedata;


public class CosmosDBProvider :ISiteDataProvider
{

    private CosmosClient _client;
    private Database _database;
    private string _connString = "AccountEndpoint=https://noisyapi.documents.azure.com:443/;AccountKey=dAOVwHAj1e8Z3GLKvzNadYDL7H5DyUiXGPtyglq6B8jqQVDPEp3BcBPYPBnS0pO6bgwEf66Bu5JNACDb4w4j9Q==;";

    public CosmosDBProvider(){
        _client = new CosmosClient(_connString);
        _database = _client.GetDatabase(id: "NoisyData");   
    }

    public Embed FindEmbed(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Embed>> GetEmbeds()
    {

        List<Embed> embeds = new List<Embed>();
        Container container = _database.GetContainer(id: "Embeds");

      //  var query = new QueryDefinition(query: "SELECT * FROM products p WHERE p.categoryId = @categoryId")
        //    .WithParameter("@categoryId", "61dba35b-4f02-45c5-b648-c6badc0cbd79");

        var query = new QueryDefinition(query: "SELECT * FROM Embeds");

        using FeedIterator<Embed> feed = container.GetItemQueryIterator<Embed>(
            queryDefinition: query
        );

        while (feed.HasMoreResults)
        {
            FeedResponse<Embed> response = await feed.ReadNextAsync();
            
            embeds = response.ToList<Embed>();
        }

        return embeds;
    }

    public async Task<string> InsertEmbed(Embed embed)
    {
         Container container = _database.GetContainer(id: "Embeds");
         Embed createdItem = await container.CreateItemAsync<Embed>(item: embed);

         return createdItem.Id;
    
    }
}