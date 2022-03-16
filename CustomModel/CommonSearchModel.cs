using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class CommonSearchModel
    {
        public string UserId { get; set; }
        public int? TenantID { get; set; }
        public int? TenantTypeId { get; set; }
        public int? CommunityId { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
    }
}
