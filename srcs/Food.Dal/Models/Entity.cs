using System.ComponentModel.DataAnnotations;
using IDal.Models;

namespace Food.Dal.Models
{
    public class Entity : IEntity
    {
        [Key]
        public int? Id { get; set; }
    }
}
