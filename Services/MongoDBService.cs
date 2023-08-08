using PSTest.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PSTest.Services;
public class MongoDBService {

    private readonly IMongoCollection<Poliza> _polizasCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _polizasCollection = database.GetCollection<Poliza>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Poliza poliza) {
        await _polizasCollection.InsertOneAsync(poliza);
        return;
    }

    public async Task<List<Poliza>> GetAsync() {
        return await _polizasCollection.Find(new BsonDocument()).ToListAsync();
    }
    public async Task<List<Poliza>> GetByPlacaAsync(string placa)
    {
        var filter = Builders<Poliza>.Filter.Eq(p => p.placa_vehiculo, placa);
        return await _polizasCollection.Find(filter).ToListAsync();
    }

    public async Task<List<Poliza>> GetByNPolizaAsync(long poliza)
    {
        var filter = Builders<Poliza>.Filter.Eq(p => p.n_poliza, poliza);
        return await _polizasCollection.Find(filter).ToListAsync();
    }
}