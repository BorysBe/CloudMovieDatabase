using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MainService.Model
{
    [DataContract]
    public class Actor
    {
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        public string LastName { get; set; }

        [DataMember]
        public DateTime Birthday { get; set; }

        [DataMember]
        public List<Movie> Filmography { get; set; } = new List<Movie>();
    }
}