using Dmeta.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmeta.ViewModels
{
    public class ViewModelMain : ViewModelBase
    {
        public ViewModelMain()
        {
            Metadata m = LoadBaseInfo(); // Carica le informazioni di base

            
        }

        private Metadata LoadBaseInfo()
        {
            return Metadata.LoadModel(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "meta.json"));
        }
    }
}
