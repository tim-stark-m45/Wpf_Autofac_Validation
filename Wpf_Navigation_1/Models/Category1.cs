using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Navigation_1.Models
{
    public class Category1
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Contact1> Contact1s { get; set; }
    }
}
