namespace ParralelAPICallsConsole;

public class HelperClass
{
    public static async Task<string[]> CallsApiInParallel(List<string> apiUrls)
    {
        var httpCLient = new HttpClient();

        var apiTasks = new List<Task<string>>();

        foreach (var apiurl in apiUrls)
        {
            apiTasks.Add(CallApiAsync(httpCLient,apiurl));
        } 
        
        string[] apiResponses = await Task.WhenAll(apiTasks);

        return apiResponses;
    }
    
    public static async Task<List<string>> CallAPINormal(List<string> apiUrls)
    {
        var httpCLient = new HttpClient();
        List<string> apiResponses = new();

        foreach (var apiUrl in apiUrls)
        {
            apiResponses.Add((await CallApiAsync(httpCLient,apiUrl)));
            
        }

        return apiResponses;

    }
    public static async Task<string> CallApiAsync(HttpClient httpClient, string apiUrl)
    {
        var response = await httpClient.GetStringAsync(apiUrl);
        return response;
    }
    
}