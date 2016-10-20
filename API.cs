using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

internal interface IJSONAPI {
    Task<string> GetJSON(string url, string key);
    Task<T> GetData<T>(string url, string key);
    string ToJSON(Object o);
}

internal class MashapeAPI : IJSONAPI {
    private List<string> fields = new List<string>() {
        "item_name",
        "item_id",
        "brand_name",
        "nf_calories",
        "nf_total_fat"
    };

    private string urlFormat(string term) =>
        $"https://nutritionix-api.p.mashape.com/v1_1/search/{term}?fields={String.Join(",", fields)}";

    public async Task<string> GetJSON(string url, string key){
        var http = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("-X-Mashape-Key", key);
        var reply = await http.SendAsync(request);
        var result = await reply.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<T> GetData<T>(string url, string key){
        string json = await GetJSON(url, key);
        T instance = JsonConvert.DeserializeObject<T>(json);
        return instance;
    }

    public string ToJSON(Object o){
        return JsonConvert.SerializeObject(o);
    }
}