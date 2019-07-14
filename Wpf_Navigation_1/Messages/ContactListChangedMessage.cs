using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf_Navigation_1.Models;

namespace Wpf_Navigation_1.Messages
{
    class ContactListChangedMessage
    {
        public Contact1 Item { get; set; }
    }
}
