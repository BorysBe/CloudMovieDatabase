using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MainService.Model
{
    [DataContract]
    public class Movie
    {
        [DataMember(EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Title { get; set; }

        [DataMember] 
        public int Year { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public List<Actor> Starring { get; } = new List<Actor>();

        public Actor Add(Actor actor)
        {
            Starring.Add(actor);
            return actor;
        }

        public void SetNoActors()
        {
            Starring.Clear();
        }
    }
}
