using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class City {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Latitude { get; set; }
        public string Longtitude { get; set; }

        public City(int id, string name, string latitude, string longtitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longtitude = longtitude;
        }
    }
}
