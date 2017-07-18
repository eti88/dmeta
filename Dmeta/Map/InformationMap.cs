using CsvHelper.Configuration;
using Dmeta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmeta.Map
{
    public class InformationMap : CsvClassMap<Information>
    {
        public InformationMap()
        {
            Map(m => m.Image).Index(0);
            Map(m => m.Location).Index(1);
            Map(m => m.City).Index(2);
            Map(m => m.Description).Index(3);
            Map(m => m.Origin).Index(4);
        }
    }
}
