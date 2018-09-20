using MVPtest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPtest.View
{
    interface IContactsForm
    {
        Contact Contact { get; set; }
        void UpdateList();
    }
}
