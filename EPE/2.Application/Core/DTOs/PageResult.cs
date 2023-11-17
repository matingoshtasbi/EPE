using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE.Application.Core.DTOs
{
    public class PageResult<T>
    {
        public List<T> Results { get; set; }
        public int TotalCount { get; set; }
    }
}
