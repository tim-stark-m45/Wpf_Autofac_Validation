using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Navigation_1.Extensions;

namespace Wpf_Navigation_1.Models
{
    public class Contact1 : ObservableObject, IDataErrorInfo
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? CategoryId { get; set; }
        public Category1 Category1 { get; set; }

        public string Error => throw new NotImplementedException();
        public string this[string columnName] => this.Validate(columnName);
    }
}
