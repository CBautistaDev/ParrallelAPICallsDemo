
using ParralelAPICallsConsole;

List<string> apiUrls = new();

//create a list of 100 api urls
for (var i = 1; i <= 100; i++)
{
  apiUrls.Add($"https://jsonplaceholder.typicode.com/posts/{i}");

}





var watch = System.Diagnostics.Stopwatch.StartNew();

//var responses = await HelperClass.CallsApiInParallel(apiUrls);
  
var normalReponses = await HelperClass.CallAPINormal(apiUrls);

watch.Stop();

foreach(var response in normalReponses)
{
  Console.WriteLine(response);
}


//Console.WriteLine($"Total time taken in Parrallel: {watch.ElapsedMilliseconds} ms");
Console.WriteLine($"Total time taken in normal calls: {watch.ElapsedMilliseconds} ms");
