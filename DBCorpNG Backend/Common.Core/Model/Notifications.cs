﻿using DBCorp.Common.Core.Interface;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBCorp.Common.Core.Model
{
   public  class Notifications : INotification

 
    {


        [JsonProperty(Order = -2)]
        public string Key { get; }

        [JsonProperty(Order = -1)]
        public string Value { get; }

        public Notifications(
            string key,
            string value)
        {
            Key = key;
            Value = value;
        }
    }
}
