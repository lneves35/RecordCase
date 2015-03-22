using System;
using System.Windows.Media.Imaging;
using RecordCase.Core.WPF;

namespace RecordCase.Collections.Entities
{
    public class CollectionMetadata : ViewModelBaseValidating
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        private DateTime _created;
        public DateTime Created
        {
            get
            {
                return _created;
            }
            set
            {
                if (_created != value)
                {
                    _created = value;
                    RaisePropertyChanged("Created");
                }
            }
        }        

        private byte[] _image;
        public byte[] Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    RaisePropertyChanged("Image");
                }
            }
        }        

    }
}
