using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MainService.Model
{
    [DataContract]
    public class Movie
    {
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
