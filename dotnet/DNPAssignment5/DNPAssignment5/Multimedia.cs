using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNPAssignment5
{
    public class Multimedia : INotifyPropertyChanged
    {
        public enum MediaType
        {
            DVD,
            CD
        };
        private string title;
        private string artist;
        private string genre;
        private MediaType type;
        private string fullDetails;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Title");
                OnPropertyChanged("FullDetails");
            }
        }

        public string Artist
        {
            get { return artist; }
            set
            {
                artist = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Artist");
                OnPropertyChanged("FullDetails");
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Genre");
                OnPropertyChanged("FullDetails");
            }
        }

        public MediaType Type
        {
            get { return type; }
            set
            {
                type = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Type");
                OnPropertyChanged("FullDetails");
            }
        }

        public string FullDetails
        {
            get {
                fullDetails = title + " " + artist + " " + genre;
                if(!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(artist) && !string.IsNullOrWhiteSpace(genre))
                {
                    fullDetails += " " + type;
                }
                return fullDetails;
            }
            set
            {
                fullDetails = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("FullDetails");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
