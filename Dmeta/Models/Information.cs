using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmeta.Models
{
    /// <summary>
    /// Modello per il caricamento delle informazioni variabili dal file csv
    /// </summary>
    public class Information
    {
        public string Image { get; set; }
        public string Location { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }

        Information()
        {
            Image = string.Empty;
            Location = string.Empty;
            City = string.Empty;
            Description = string.Empty;
            Origin = string.Empty;
        }

        Information(string image, string location, string city, string description, string origin)
        {
            Image = image;
            Location = location;
            City = city;
            Description = description;
            Origin = origin;
        }
    }
}
