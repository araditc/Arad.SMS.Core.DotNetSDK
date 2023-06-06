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

using Arad.SMS.Core.DotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Arad.SMS.Core.DotNetSDK
{
    public interface IMessage
    {
        Task<string> GetToken(string Username, string Password, string Scop);
        Task<HttpResponseMessage> Send(List<AradA2PMessage> aradA2PMessages, string Token);
        Task<HttpResponseMessage> SendBulk(AradBulkMessage aradBulkMessage, string Token);
        Task<List<DLRStatus>> GetDLR(List<string> Ids, string Token);
        Task<List<Inbox>> GetMO(bool returnId, string Token);
        Task<List<Inbox>> GetMOByDate(DateTime startDateTime, DateTime endDateTime, bool returnId, string Token);
    }
}
