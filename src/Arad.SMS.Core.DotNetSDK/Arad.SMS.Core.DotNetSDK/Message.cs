//  --------------------------------------------------------------------
//  Copyright (c) 2005-2023 Arad ITC.
//
//  Author : Ammar Heidari <ammar@arad-itc.org>
//  Licensed under the Apache License, Version 2.0 (the "License")
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0 
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  --------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Net.Http;
using Arad.SMS.Core.DotNetSDK.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Arad.SMS.Core.DotNetSDK
{
    public class Message : IMessage
    {
        private HttpClient httpClient = new HttpClient();
        private const string _apiBaseAddress = "https://api.aradvas.ir/";
        public Message() {

            httpClient.BaseAddress = new Uri(_apiBaseAddress);
        }

        public async Task<string> GetToken(string Username, string Password, string Scop)
        {
            try
            {
                List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>()
                                                               {
                                                                   new KeyValuePair<string, string>("username", Username),
                                                                   new KeyValuePair<string, string>("password", Password),
                                                                   new KeyValuePair < string, string >("scope", Scop)
                                                               };
                FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(keyValues);
                HttpResponseMessage responseMessage = await httpClient.PostAsync("/connect/token", formUrlEncodedContent);

                TokenResponseModel data = JsonConvert.DeserializeObject<TokenResponseModel>(await responseMessage.Content.ReadAsStringAsync());
                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return data?.access_token;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> Send(List<AradA2PMessage> aradA2PMessages, string Token)
        {
            return await GetResult(JsonConvert.SerializeObject(aradA2PMessages), "api/message/send/", Token);
        }
    
        public async Task<HttpResponseMessage> SendBulk(AradBulkMessage aradBulkMessage, string Token)
        {
            return await GetResult(JsonConvert.SerializeObject(aradBulkMessage), "api/message/bulk/", Token);
        }

        public async Task<List<DLRStatus>> GetDLR(List<string> Ids, string Token)
        {
            HttpResponseMessage response = await GetResult(JsonConvert.SerializeObject(Ids), "api/message/GetDLR/", Token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ResultApiClass<List<DLRStatus>> resultApi = JsonConvert.DeserializeObject<ResultApiClass<List<DLRStatus>>>(await response.Content.ReadAsStringAsync());
                return resultApi.Data;
            }
            else
            {
                return new List<DLRStatus>();
            }
        }

        public async Task<List<Inbox>> GetMO(bool returnId, string Token)
        {
            HttpResponseMessage response = await GetResult(returnId ? "api/message/GetMO?returnId=true" : "api/message/GetMO/", Token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ResultApiClass<List<Inbox>> resultApi = JsonConvert.DeserializeObject<ResultApiClass<List<Inbox>>>(await response.Content.ReadAsStringAsync());
                return resultApi.Data;
            }
            else
            {
                return new List<Inbox>();
            }
        }

        public async Task<List<Inbox>> GetMOByDate(DateTime startDateTime, DateTime endDateTime, bool returnId, string Token)
        {
            HttpResponseMessage response = await GetResult(returnId ? $"api/message/GetMOByDate?startDateTime={startDateTime}&endDateTime={endDateTime}&returnId={returnId}" : $"api/message/GetMOByDate?startDateTime={startDateTime}&endDateTime={endDateTime}", Token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ResultApiClass<List<Inbox>> resultApi = JsonConvert.DeserializeObject<ResultApiClass<List<Inbox>>>(await response.Content.ReadAsStringAsync());
                return resultApi.Data;
            }
            else
            {
                return new List<Inbox>();
            }
        }

        private async Task<HttpResponseMessage> GetResult(string Content, string Url, string Token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            StringContent content = new StringContent(Content, Encoding.UTF8, MediaTypeNames.Application.Json);
            return await httpClient.PostAsync(Flurl.Url.Combine(_apiBaseAddress, Url), content);
        }

        private async Task<HttpResponseMessage> GetResult(string Url, string Token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
            return await httpClient.GetAsync(Flurl.Url.Combine(_apiBaseAddress, Url));
        }
    }
}
