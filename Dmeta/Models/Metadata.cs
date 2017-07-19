using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmeta.Models
{
    class Metadata : BaseModel
    {
        #region Property

        private string _image;
        public string UriImage
        {
            get { return _image; }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    OnPropertyChanged("UriImage");
                }
            }
        }

        private ContactIptc _contactData;
        public ContactIptc ContactData
        {
            get { return _contactData; }
            set
            {
                if (value != _contactData)
                {
                    _contactData = value;
                    OnPropertyChanged("ContactData");
                }
            }
        }

        private ImageIptc _imageData;
        public ImageIptc ImageData
        {
            get { return _imageData; }
            set
            {
                if (value != _imageData)
                {
                    _imageData = value;
                    OnPropertyChanged("ImageData");
                }
            }
        }

        private ConditionsIptc _conditionsData;
        public ConditionsIptc ConditionsData
        {
            get { return _conditionsData; }
            set
            {
                if (value != _conditionsData)
                {
                    _conditionsData = value;
                    OnPropertyChanged("ConditionsData");
                }
            }
        }

        public DateTime StartScanDate { get; set; }

        public int ScanDay { get; set; }


        #endregion

        public Metadata() {
            ContactData = new ContactIptc();
            ImageData = new ImageIptc();
            ConditionsData = new ConditionsIptc();
        }


        public static Metadata LoadModel(string uri)
        {
            try
            {
                Metadata m;
                using (StreamReader sr = new StreamReader(uri))
                {
                    string json = sr.ReadToEnd();
                    m = JsonConvert.DeserializeObject<Metadata>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                }
                return m;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
