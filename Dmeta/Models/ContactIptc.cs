using System.Collections.Generic;

namespace Dmeta.Models
{
    public class ContactIptc : BaseModel
    {
        /// <summary>
        /// Indica il Nome e Cognome dell'operatore
        /// </summary>
        private string _creator;
        public string Creator
        {
            get { return _creator; }
            set
            {
                if (value != _creator)
                {
                    _creator = value;
                    OnPropertyChanged("Creator");
                }
            }
        }

        private string _job;
        public string JobTitle
        {
            get { return _job; }
            set
            {
                if (value != _job)
                {
                    _job = value;
                    OnPropertyChanged("JobTitle");
                }
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged("Address");
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

        private string _cap;
        public string Cap
        {
            get { return _cap; }
            set
            {
                if (value != _cap)
                {
                    _cap = value;
                    OnPropertyChanged("Cap");
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

        private string _tel;
        public string Telephone
        {
            get { return _tel; }
            set
            {
                if (value != _tel)
                {
                    _tel = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        private string _site;
        public string Site
        {
            get { return _site; }
            set
            {
                if (value != _site)
                {
                    _site = value;
                    OnPropertyChanged("Site");
                }
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        private string _desc;
        public string Description
        {
            get { return _desc; }
            set
            {
                if (value != _desc)
                {
                    _desc = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        private string _keywords;
        public string Keywords
        {
            get { return _keywords; }
            set
            {
                if (value != _keywords)
                {
                    _keywords = value;
                    OnPropertyChanged("Keywords");
                }
            }
        }
    }
}