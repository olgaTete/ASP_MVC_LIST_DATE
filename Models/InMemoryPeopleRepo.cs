using ListDate2.Models.Entities;
using ListDate2.Models.Repo;

namespace ListDate2.Models
{
     public class InMemoryPeopleRepo : IPeopleRepo
        {
            private static List<Person> personList = new List<Person>();
            private static int idCounter = 0;

            public Person Create(Person person)
            {
                person.Id = ++idCounter;
                personList.Add(person);
                return person;
            }
            public List<Person> Read()
            {
                return personList.ToList();
            }
            public Person Read(int id)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    if (personList[i].Id == id)
                    {
                        return personList[i];
                    }
                }
                return null;
            }
            public bool Update(Person person)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    if (personList[i].Id == person.Id)
                    {
                        personList[i] = person;
                        return true;
                    }
                }
                return false;
            }
            public bool Delete(Person person)
            {

                personList.Remove(person);
                return true;

            }

        }
}
