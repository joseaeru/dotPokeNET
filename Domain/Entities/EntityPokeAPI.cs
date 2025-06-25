using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public sealed class EntityPokeAPI : EntityBase
    {
        //Domain -> https://pokeapi.co
        //Permalink -> /api
        //Slug -> /v2
        //Resource -> /berry
        //Parameter -> /{id or name}/

        [Key]
        public Guid Id { get; set; }

        public string Domain { get; set; } = string.Empty;
        public string Permalink { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int ResourceCode { get; set; }
        public string Parameter { get; set; } = string.Empty;
        public string InternalID { get; set; } = string.Empty;


        public EntityResource? Resource { get; set; }=null;
    }
}
