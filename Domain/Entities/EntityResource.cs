using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public sealed class EntityResource : EntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; } = 0;
        public string Name { get; set; } = string.Empty;

        [ForeignKey("ResourceCode")]
        public ICollection<EntityPokeAPI>? PokeAPI { get; }
    }
}
