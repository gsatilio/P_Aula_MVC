using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Insurance
    {
        public static readonly string INSERT = " INSERT INTO TB_INSURANCE (Description) VALUES (@Description); SELECT CAST(scope_identity() as int) ";
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
