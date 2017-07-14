using System;

namespace Dmeta.Models
{
    public class ImageIptc : BaseModel
    {
        #region Property

        private DateTime _created;
        public DateTime CreatedAt
        {
            get { return _created; }
            set
            {
                if (value != _created)
                {
                    _created = value;
                    OnPropertyChanged("CreatedAt");
                }
            }
        }

        private string _loc;
        public string Location
        {
            get { return _loc; }
            set
            {
                if (value != _loc)
                {
                    _loc = value;
                    OnPropertyChanged("Location");
                }
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }

        private string _pv;
        public string Provence
        {
            get { return _pv; }
            set
            {
                if (value != _pv)
                {
                    _pv = value;
                    OnPropertyChanged("Provence");
                }
            }
        }

        private string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        private string _isocounrty;
        public string ISOCounrty
        {
            get { return _isocounrty; }
            set
            {
                if (value != _isocounrty)
                {
                    _isocounrty = value;
                    OnPropertyChanged("ISOCounrty");
                }
            }
        }

        #endregion

        public ImageIptc() { }
    }
}