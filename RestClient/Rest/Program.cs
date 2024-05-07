using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using RestSharp;

#region GetMethod

string url = "https://localhost:7117";
using var client = new RestClient(url);

var req = new RestRequest("/getbrands");
var resp = await client.GetAsync(req);

var data = JsonSerializer.Deserialize<JsonNode>(resp.Content);

Console.WriteLine(data);

#endregion
#region PostMethod
//Если что, программа не сохраняет изменения в базу данных :)

string url = "https://localhost:7117";
var client = new RestClient(url);

try
{
    var requestData = new
    {
        BrandName = "Apple",
    };
    var request = new RestRequest("/addbrands", Method.Post);
    request.AddJsonBody(requestData);
    var response =  await client.ExecuteAsync(request);

    if (response.StatusCode == HttpStatusCode.OK)
        Console.WriteLine($"Бренд {requestData.BrandName} успешно добавлен.");
    else
        Console.WriteLine($"Ошибка, код: {response.StatusCode}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


#endregion

#region DeleteMethod

string url = "https://localhost:7117";
using var client = new RestClient(url);

try
{
    string brandName = "Apple";
    var requestData = new RestRequest($"/removebrand/{brandName}", Method.Delete);
    var response = await client.ExecuteAsync(requestData);

    if (response.StatusCode == HttpStatusCode.OK)
        Console.WriteLine($"Бренд {brandName} успешно удалён.");
    else if (response.StatusCode == HttpStatusCode.NotFound)
        Console.WriteLine($"Бренд {brandName} не найдён");
    else
        Console.WriteLine($"Ошибка, код: {response.StatusCode}");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
#endregion
