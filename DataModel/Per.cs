using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Per
    {

        [Required]
        public int Mataikhoan { get; set; }

        [Required]
        public string per { get; set; }
    }
}
