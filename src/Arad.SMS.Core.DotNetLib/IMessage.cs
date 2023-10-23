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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Arad.SMS.Core.DotNetLib.Models;

namespace Arad.SMS.Core.DotNetLib
{
    public interface IMessage
    {
        Task<string> GetToken(string username, string password, string scope, CancellationToken cancellationToken);

        Task<HttpResponseMessage> Send(List<AradA2PMessage> aradA2PMessages, string token, bool returnLongId, CancellationToken cancellationToken);

        Task<HttpResponseMessage> SendBulk(AradBulkMessage aradBulkMessage, string token, bool returnLongId, CancellationToken cancellationToken);

        Task<List<DLRStatus>> GetDLR(List<string> ids, string token, bool returnLongId, CancellationToken cancellationToken);

        Task<List<Inbox>> GetMO(bool returnId, string token, CancellationToken cancellationToken);

        Task<List<Inbox>> GetMOByDate(DateTime startDateTime, DateTime endDateTime, bool returnId, string token, CancellationToken cancellationToken);
    }
}