using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalLibrary.Services.Common.DTOs
{
    public class LocationDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int GroupID { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationAddress { get; set; }
        public string LocationCity { get; set; }
        public short LocationCountryID { get; set; }
        public bool Active { get; set; }
    }
}
