﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Dto.Token
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }

    }
}
