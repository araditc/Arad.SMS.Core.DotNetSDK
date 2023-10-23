﻿//  --------------------------------------------------------------------
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

using static Arad.SMS.Core.DotNetLib.Helpers.Enums;

namespace Arad.SMS.Core.DotNetLib.Models
{
    public class ResultApiClass<TClass> where TClass : class
    {
        public string Message { get; set; }

        public bool Succeeded { get; set; }

        public TClass Data { get; set; }

        public ApiResponse ResultCode { get; set; }
    }
}