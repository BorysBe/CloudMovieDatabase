using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MainService.Model
{
    [DataContract]
    public class Actor
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public List<Movie> Filmography { get; set; } = new List<Movie>();
    }
}