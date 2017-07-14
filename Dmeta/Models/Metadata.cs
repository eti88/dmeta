using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmeta.Models
{
    class Metadata : BaseModel
    {
        #region Property

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private Uri _image;
        public Uri UriImage
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

        #endregion

        public Metadata() { }
    }
}
