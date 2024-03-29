﻿using System;
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

        protected bool Equals(Actor other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && Birthday.Equals(other.Birthday);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Actor) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Birthday);
        }
    }
}