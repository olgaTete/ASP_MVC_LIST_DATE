using ListDate2.Models.Entities;
using ListDate2.Models.View;

namespace ListDate2.Models.Repo
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        List<Person> All();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Remove(int id);
    }
}
