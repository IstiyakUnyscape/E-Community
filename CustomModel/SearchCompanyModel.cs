using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class SearchCompanyModel: CommonSearchModel
    {
        public string Name { get; set; }
        public string Postal_Code { get; set; }
        public string Company_Email { get; set; }
        public string Trade_License_No { get; set; }
        public long Tax_Return_Number { get; set; }
    }
}
