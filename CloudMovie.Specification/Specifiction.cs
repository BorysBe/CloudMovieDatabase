using System;
using Xunit;

namespace CloudMovie.Specification
{
    public class Specification
    {
        [Fact] public void Add_new_movie_to_the_system() { Fail(); }
        [Fact] public void Add_new_actor() { Fail(); }
        [Fact] public void Link_existing_actor_to_existing_movie() { Fail(); }
        [Fact] public void Update_information_about_existing_movie() { Fail(); }
        [Fact] public void Delete_existing_movie() { Fail(); }
        [Fact] public void List_movies_all_and_by_year() { Fail(); }
        [Fact] public void List_actors_starring_in_a_movie() { Fail(); }
        [Fact] public void List_movies_with_given_actor() { Fail(); }
        [Fact] public void Cannot_add_new_movie_without_actors() { Fail(); }
        [Fact] public void Movies_year_cannot_be_a_future_year() { Fail(); }
        [Fact] public void Actors_first_and_last_name_cannot_be_empty() { Fail(); }
        
        private void Fail()
        {
            Assert.True(false, "Not finished test");
        }
    }
}

