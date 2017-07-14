namespace Dmeta.Models
{
    public class ConditionsIptc : BaseModel
    {
        #region Property

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

        private string _jobIdentifier;
        public string JobIdentifier
        {
            get { return _jobIdentifier; }
            set
            {
                if (value != _jobIdentifier)
                {
                    _jobIdentifier = value;
                    OnPropertyChanged("JobIdentifier");
                }
            }
        }

        private string _instr;
        public string Instructions
        {
            get { return _instr; }
            set
            {
                if (value != _instr)
                {
                    _instr = value;
                    OnPropertyChanged("Instructions");
                }
            }
        }

        private string _provider;
        public string Provider
        {
            get { return _provider; }
            set
            {
                if (value != _provider)
                {
                    _provider = value;
                    OnPropertyChanged("Provider");
                }
            }
        }

        private string _origin;
        public string Origin
        {
            get { return _origin; }
            set
            {
                if (value != _origin)
                {
                    _origin = value;
                    OnPropertyChanged("Origin");
                }
            }
        }

        private string _copyright;
        public string Copyright
        {
            get { return _copyright; }
            set
            {
                if (value != _copyright)
                {
                    _copyright = value;
                    OnPropertyChanged("Copyright");
                }
            }
        }

        private string _usageTerms;
        public string UsageTerms
        {
            get { return _usageTerms; }
            set
            {
                if (value != _usageTerms)
                {
                    _usageTerms = value;
                    OnPropertyChanged("UsageTerms");
                }
            }
        }

        #endregion

        public ConditionsIptc() { }
    }
}