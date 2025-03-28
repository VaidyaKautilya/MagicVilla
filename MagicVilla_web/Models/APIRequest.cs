﻿using System.Security.AccessControl;
using static MagicVilla_Utilities.SD;

namespace MagicVilla_web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string? Token { get; set; }
    }
}
