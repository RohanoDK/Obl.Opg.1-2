using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace BeerLibrary
{
    public class Beer
    {
        private int _id;
        private string _beername;
        private double _abv;

        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Id), "Id must be a positive integer.");
                _id = value;
            }
        }

        public string BeerName
        {
            get { return _beername; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 4)
                    throw new ArgumentException("Name must not be null and must be at least 4 characters long.", nameof(BeerName));
                _beername = value;
            }
        }

        public double Abv
        {
            get { return _abv; }
            set
            {
                if (value < 0 || value > 67)
                    throw new ArgumentOutOfRangeException(nameof(Abv), "ABV must be between 0 and 67.");
                _abv = value;
            }
        }

        public Beer(int id, string name, double abv)
        {
            Id = id;
            BeerName = name;
            Abv = abv;
        }

        public Beer()
        {
        }

        public override string ToString()
        {
            return $"{Id} {BeerName} {Abv}";
        }
    }
}
