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
using System.ComponentModel;

namespace Arad.SMS.Core.DotNetSDK.Helpers
{
    public class Enums
    {
        public enum MessageClass
        {
            TEXT,
            BINARY,
            WAPPUSH,
            VCARD,
            VCALENDAR,
            VOICEMAIL,
            EMAIL,
            FAX,
            VIDEO,
            PICTUREMESSAGE,
            USSD,
            MMS,
            FLASH,
            HEXSTRING
        }

        public enum Priority
        {
            Lowest = 0,

            VeryLow = 1,

            Low = 2,

            Normal = 3,

            AboveNormal = 4,

            High = 5,

            VeryHigh = 6,

            Highest = 7
        }

        public enum DataCodings : byte
        {
            /// <summary>
            /// SMSC Default Alphabet (GSM 7 bit) (0x0)
            /// </summary>
            Default = 0x0,
            /// <summary>
            /// IA5 (CCITT T.50)/ASCII (ANSI X3.4) (0x1)
            /// </summary>
            ASCII = 0x1,
            /// <summary>
            /// Octet unspecified (8-bit binary) (0x2)
            /// </summary>
            Octets = 0x2,
            /// <summary>
            /// Latin 1 (ISO-8859-1) (0x3)
            /// </summary>
            Latin1 = 0x3,
            /// <summary>
            /// Octet unspecified (8-bit binary) (0x4)
            /// </summary>
            OctetUnspecified = 0x4,
            /// <summary>
            /// Cyrllic (ISO-8859-5)(0x6)
            /// </summary>
            Cyrllic = 0x6,
            /// <summary>
            /// Latin/Hebrew (ISO-8859-8) (0x7)
            /// </summary>
            LatinHebrew = 0x7,
            /// <summary>
            /// UCS2 (ISO/IEC-10646) (0x8)
            /// </summary>
            UCS2 = 0x8,

            /// <summary>
            /// Flash message (Class 0) (0x10)
            /// </summary>
            Class0FlashMessage = 0x10,

            /// <summary>
            /// ME-specific message (Class 1) (0x11)
            /// </summary>
            Class1MEMessage = 0x11,

            /// <summary>
            /// IM/USIM-specific message (Class 2) (0x12)
            /// </summary>
            Class2SIMMessage = 0x12,

            /// <summary>
            /// TE-specific message (Class 3) (0x13)
            /// </summary>
            Class3TEMessage = 0x13,

            /// <summary>
            /// Flash message (Class 0) with 8 bit data (0x14)
            /// </summary>
            Class0FlashMessage8bit = Class0FlashMessage | OctetUnspecified,

            /// <summary>
            /// ME-specific message (Class 1) with 8 bit data (0x15)
            /// </summary>
            Class1MEMessage8bit = Class1MEMessage | OctetUnspecified,

            /// <summary>
            /// IM/USIM-specific message (Class 2) with 8 bit data (0x16)
            /// </summary>
            Class2SIMMessage8bit = Class2SIMMessage | OctetUnspecified,

            /// <summary>
            /// TE-specific message (Class 3) with 8 bit data (0x17)
            /// </summary>
            Class3TEMessage8bit = Class3TEMessage | OctetUnspecified,

            /// <summary>
            /// Flash message (Class 0) with UCS2 characters (0x18)
            /// </summary>
            Class0FlashMessageUCS2 = Class0FlashMessage | UCS2,

            /// <summary>
            /// ME-specific message (Class 1) with UCS2 characters  (0x19)
            /// </summary>
            Class1MEMessageUCS2 = Class1MEMessage | UCS2,

            /// <summary>
            /// IM/USIM-specific message (Class 2) with UCS2 characters (0x1A)
            /// </summary>
            Class2SIMMessageUCS2 = Class2SIMMessage | UCS2,

            /// <summary>
            /// TE-specific message (Class 3) with UCS2 characters  (0x1B)
            /// </summary>
            Class3TEMessageUCS2 = Class3TEMessage | UCS2,

            /// <summary>
            /// Message Class 0 (0xF0)
            /// </summary>
            Class0 = GroupMessageClass | Class0FlashMessage,

            /// <summary>
            /// Message Class 1 (0xF1)
            /// </summary>
            Class1 = GroupMessageClass | Class1MEMessage,
            /// <summary>
            /// Message Class 2 (0xF2)
            /// </summary>
            Class2 = GroupMessageClass | Class2SIMMessage,

            /// <summary>
            /// Message Class 3 (0xF3)
            /// </summary>
            Class3 = GroupMessageClass | Class3TEMessage,

            /// <summary>
            /// Class 0 Flash message 8bit data (0xF4)
            /// </summary>
            Class08Bit = GroupMessageClass | Class0FlashMessage | OctetUnspecified,

            /// <summary>
            /// Class 1 ME specific 8-bit data (0xF5)
            /// </summary>
            Class1ME8Bit = GroupMessageClass | Class1MEMessage | OctetUnspecified,

            /// <summary>
            /// Class 2 SIM specific 8-bit data (0xF6)
            /// </summary>
            Class2SIM8Bit = GroupMessageClass | Class2SIMMessage | OctetUnspecified,

            /// <summary>
            /// Class 3 TE specific 8-bit data (0xF7)
            /// </summary>
            Class3TE8Bit = GroupMessageClass | Class3TEMessage | OctetUnspecified,

            /// <summary>
            /// Coding Group: Message Marked for Automatic Deletion
            /// </summary>
            GroupAutomaticDeletion = 0x40,

            /// <summary>
            /// Coding Group: Data Coding/Message Class
            /// </summary>
            GroupMessageClass = 0xF0,

            /// <summary>
            /// Flash SMS with GSM 7 bit charset (0x10)
            /// </summary>
            DefaultFlashSMS = Class0FlashMessage,

            /// <summary>
            /// Flash SMS with Unicode characters (0x18)
            /// </summary>
            UnicodeFlashSMS = UCS2 | Class0FlashMessage,

            [Obsolete("Use Class2SIM8Bit instead.")]
            Class1SIM8Bit = Class2SIM8Bit,

            [Obsolete("Use Class3TE8Bit instead.")]
            Class1TE8Bit = Class3TE8Bit,

            None = 0xFE
        }

        public enum ApiResponse
        {
            [Description("Succeeded")]
            Succeeded = 100,

            [Description("DatabaseError")]
            DatabaseError = 101,

            [Description("RepositoryError")]
            RepositoryError = 102,

            [Description("ModelError")]
            ModelError = 103,

            [Description("Error connecting to api")]
            ApiConnectionAttemptFailure = 104,

            [Description("Service unavailable at the moment")]
            ServiceUnAvailable = 105,

            [Description("Confirm email failed")]
            ConfirmEmailFailed = 106,

            [Description("User not found")]
            UserNotFound = 107,

            [Description("Item already exists")]
            DuplicateError = 108,

            [Description("Item not found!")]
            NotFound = 109,

            [Description("Could not json convert the result!")]
            UnableToCreateResultApiError = 110,

            [Description("Error mapping object!")]
            AutoMapperError = 111,

            [Description("GeneralFailure")]
            GeneralFailure = 112,

            [Description("Error in 3rd party web service.")]
            WebServiceError = 113,

            [Description("Unable to recieve token from identity provider.")]
            ErrorGettingTokenFromIdp = 114,

            [Description("Can not read appsettings.json")]
            ErrorRetrievingDataFromAppSettings = 115,

            [Description("Headers of request is not correctly set.")]
            HeaderError = 116,

            [Description("Bad request.")]
            BadRequestError = 117,

            [Description("RangeLimitExceed")]
            RangeLimitExceedResponse = 118,

            [Description("No Tariff package for user is defined.")]
            UserTariffNull = 119,

            [Description("Limited in send day.")]
            LimitedInSendDay,

            [Description("Limited in send Monthly.")]
            LimitedInSendMonth
        }

        public enum DeliveryStatus
        {
            Delivered = 1, 
            UnDelivered = 2, 
            Accepted = 3,
            ReceivedByUpstream = 4, 
            Rejected = 5, 
            NotReceiveByServer = 6, 
            ErrorInSending = 7,
            WaitingForSend = 8, 
            Sent = 9, 
            NotSent = 10, 
            Expired = 11, 
            IsSending = 12, 
            IsCanceled = 13, 
            BlackList = 14, 
            SmsIsFilter = 15, 
            Deleted = 16, 
            WaitingForConfirmation = 17, 
            NotEnoughBalance = 18,
            IsPreparing = 19, 
            IsPreparedForSending = 20,
            AccessDenied = 21, 
            TextIsEmpty = 22,
            InvalidInputFormat = 23, 
            InvalidUserOrPassword = 24, 
            InvalidUsedMethod = 25, 
            InvalidSender = 26, 
            InvalidMobile = 27, 
            InvalidReception = 28, 
            Stored = 29, 
            BlackListTable = 30, 
            GetDeliveryStatus = 31, 
            Unknown = 32,
            Enroute = 33,
            Undeliverable = 34,
            MessageQueueFull = 35,
            UnreachableNetwork = 36
        }

        public enum SmsSendError
        {
            SendError = 0,
            NotEnoughCredit = -1,
            ServerError = -2,
            DeActiveAccount = -3,
            ExpiredAccount = -4,
            InvalidUsernameOrPassword = -5,
            AuthenticationFailure = -6,
            ServerBusy = -7,
            NumberAtBlackList = -8,
            LimitedInSendDay = -9,
            LimitedInVolume = -10,
            InvalidSenderNumber = -11,
            InvalidReceiverNumber = -12,
            InvalidDestinationNetwork = -13,
            UnreachableNetwork = -14,
            DeActiveSenderNumber = -15,
            InvalidFormatOfSenderNumber = -16,
            TariffNotFound = -17,
            InvalidIpAddress = -18,
            InvalidPattern = -19,
            ExpiredSenderNumber = -20,
            MessageContainsLink = -21,
            InvalidPort = -22,
            MessageTooLong = -23,
            FilterWord = -24,
            InvalidReferenceNumberType = -25,
            InvalidTargetUDH = -26,
            LimitedInSendMonth = -27
        }
    }
}
