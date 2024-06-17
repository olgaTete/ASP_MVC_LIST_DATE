namespace ListDate2.Models.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        
        public Person(string name, string phoneNumber, string city)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }
    }
}
