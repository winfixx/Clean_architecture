using System.ComponentModel.DataAnnotations.Schema;

namespace Onion_Architecture.Core.DomainModels
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
