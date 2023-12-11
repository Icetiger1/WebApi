using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    public class UserContact
    {
        [Key]
        public Guid Id { get; set; }
        public string FirsName { get; set; }
        public string LastName {  get; set; }
        public string Telephone {  get; set; }
        public string Description { get; set; }
        public DateTime TimeCerated { get; set; }

    }
}
