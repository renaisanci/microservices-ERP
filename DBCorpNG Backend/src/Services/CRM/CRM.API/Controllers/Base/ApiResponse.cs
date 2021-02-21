﻿using DBCorp.Common.Core.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBCorp.CRM.API.Controllers.Base
{
    public class ApiResponse
    {

        private ApiResponse()
        {
        }

        public ApiResponse(string verbDescription, List<Notifications> exception, string target = null)
        {
            var response = GetCompleteException(verbDescription, exception, target);
            Error = response.Error;
            InnerError = response.InnerError;
        }

        /// <summary>
        ///     Response error
        /// </summary>
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public Error Error { get; private set; }

        /// <summary>
        ///     Response inner error
        /// </summary>
        [JsonProperty("innererror", NullValueHandling = NullValueHandling.Ignore)]
        public ApiResponse InnerError { get; private set; }

        private ApiResponse GetCompleteException(string verbDescription, List<Notifications> validationErrors, string target)
        {
            var response = new ApiResponse
            {
                Error = new Error
                {
                    Message = validationErrors,
                    Target = target,
                    Code = verbDescription
                }
            };

            return response;
        }

    }
}
