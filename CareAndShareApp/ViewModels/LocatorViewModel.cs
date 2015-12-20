using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareAndShareApp.ViewModels
{
    public class LocatorViewModel
    {
        public string Country { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string Neighborhood { get; set; }

        public byte Priority { get; set; }

        public string Comment { get; set; }

        public string ImagePath { get; set; }

        public object ImageSource { get; set; }

        public string ImageName { get; set; }
    }
}
