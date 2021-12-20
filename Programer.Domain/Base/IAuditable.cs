using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Domain.Base
{
    public interface IAuditable
    {
        DateTime CreateDate { get; set; }
        DateTime? LastModifyDate { get; set; }
    }
}
