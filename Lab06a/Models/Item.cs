using System;
using Xamarin.Forms;

namespace Lab06a.Models
{
    public class Item : BindableObject
    {
        public string Id { get; set; }
        private string _text;
        private string _nazw;
        private string _nr;
        private string _plec;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                if (value != _text)
                {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return _nazw;
            }
            set
            {
                if (value != _nazw)
                {
                    _nazw = value;
                    OnPropertyChanged(nameof(Nazwisko));
                }
            }
        }

        public string Numer
        {
            get
            {
                return _nr;
            }
            set
            {
                if (value != _nr)
                {
                    _nr = value;
                    OnPropertyChanged(nameof(Numer));
                }
            }
        }

        public string Plec
        {
                get
            {
                    return _plec;
                }
                set
            {
                    if (value != _plec)
                    {
                        _plec = value;
                        OnPropertyChanged(nameof(Plec));
                    }
                }
            }
        }
    }