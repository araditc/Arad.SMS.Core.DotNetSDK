# Arad.SMS.Core.DotNetSDK
Dotnet SDK for Arad SMS Core API

### NuGet 
You can download this package from [NuGet](https://www.nuget.org/packages/Arad.SMS.Core.DotNetSDK/)

``` C#
 public class Program
    {
        private static IMessage _aradMessage;

        private static async Task Main()
        {
            Console.WriteLine("Hello Arad!");
            _aradMessage = new Message("https://api.aradvas.ir");
            
            await SendAradA2PMessage();
        }

        private static async ValueTask<string> GetToken()
        {
            return await _aradMessage.GetToken("userName", "password", "ApiAccess", CancellationToken.None);
        }

        private static async ValueTask SendAradA2PMessage()
        {
            List<AradA2PMessage> list = new() { new() { DestinationAddress = "989123456789", SourceAddress = "9890001234", MessageText = "Hello Arad!", DataCoding = Enums.DataCodings.Default } };
            
            HttpResponseMessage response = await _aradMessage.Send(list, await GetToken(), false, CancellationToken.None);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ResultApiClass<List<string>> batchIds = JsonConvert.DeserializeObject<ResultApiClass<List<string>>>(await response.Content.ReadAsStringAsync());
                Console.Write(JsonConvert.SerializeObject(batchIds));
            }
        }

        private static async ValueTask SendAradBulkMessage()
        {
            AradBulkMessage list = new() { DestinationAddress = { "989123456789", "989129876543" }, SourceAddress = "9890001234", MessageText = "Hello Arad!" };
            HttpResponseMessage response = await _aradMessage.SendBulk(list, await GetToken(), false, CancellationToken.None);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                ResultApiClass<List<string>> batchIds = JsonConvert.DeserializeObject<ResultApiClass<List<string>>>(await response.Content.ReadAsStringAsync());
                Console.Write(JsonConvert.SerializeObject(batchIds));
            }
        }

        private static async ValueTask GetDelivery()
        {
            List<string> messageIds = new() { "64587abc831e4ec10a883dcd", "64587abc831e4ec10a883hgf" };
            List<DLRStatus> response = await _aradMessage.GetDLR(messageIds, await GetToken(), false, CancellationToken.None);
            Console.Write(JsonConvert.SerializeObject(response));
        }

        private static async ValueTask GetMo()
        {
            List<Inbox> response = await _aradMessage.GetMO(false, await GetToken(), CancellationToken.None);
            Console.Write(JsonConvert.SerializeObject(response));
        }

        private static async ValueTask GetMoByDate()
        {
            List<Inbox> response = await _aradMessage.GetMOByDate(DateTime.Now.AddMinutes(-20), DateTime.Now, false, await GetToken(), CancellationToken.None);
            Console.Write(JsonConvert.SerializeObject(response));
        }
    }
```
