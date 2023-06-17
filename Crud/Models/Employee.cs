namespace Crud.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Photo { get; set; }  
        public int? Age { get; set; }
        public string getNameAndAge()
        {
            return "Nome: " + Name + " idade: " + Age;
        }
    }
}
