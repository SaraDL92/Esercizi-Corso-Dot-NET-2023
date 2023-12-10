using System;

namespace data.Models
{
    public class song
    {
        private string _name;

        public string Title { get => _name; set => _name = value; }
        public song(string name) { _name = name; }
    }
}
