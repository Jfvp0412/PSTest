using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace PSTest.Models;

public class Poliza {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;} 
    public long n_poliza {get; set;}
    public string? nombre_cliente {get; set;}
    public string? cc_cliente {get; set;}
    public string? fecha_nac_cliente {get; set;}
    public string? fecha_poliza {get; set;}
    public string? fecha_fin {get; set;}
    public int n_coberturas {get; set;}
    public long val_max {get; set;}
    public string? nombre_poliza {get; set;}
    public string? ciudad_cliente {get; set;}
    public string? dir_cliente {get; set;}
    public string? placa_vehiculo {get; set;}
    public string? modelo_vehiculo {get; set;}
    public bool inspeccionado {get; set;}
}