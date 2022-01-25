using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class ErrorEntitesModel
    {
        public string message { get; set; }
        public string innerMessage { get; set; }
        public string path { get; set; }
        public string errorType { get; set; }
        public int errorCode { get; set; }
    }
}
