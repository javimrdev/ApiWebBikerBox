using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiWebBikerBox.Models
{
    public class BoolResponse
    {
        private bool b { get; set; }

        public BoolResponse(bool b)
        {
            this.b = b;
        }

    }
}