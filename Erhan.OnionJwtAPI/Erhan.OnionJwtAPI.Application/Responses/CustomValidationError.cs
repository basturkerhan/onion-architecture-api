﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erhan.MovieTicketSystem.Application.Responses
{
    public class CustomValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
