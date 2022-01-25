using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class PagedStaticList<T>
    {
        public PagedStaticList()
        {
            Items = new List<T>();
        }
        public IEnumerable<T> Items{ get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemCount { get; set; }

    }
}
