
using Application.Features;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Migrations
{
    public static class InitialData
    {
        public static async Task Add(DotPokeNETContext context)
        {
            foreach (BaseDTO.ValidResources resource in Enum.GetValues(typeof(BaseDTO.ValidResources)))
            {
                if (resource == BaseDTO.ValidResources.NONE ||
                    resource == BaseDTO.ValidResources.ALL)
                    continue;

                EntityResource newResource = new()
                {
                    Code = (int)resource,
                    Name = resource.ToString().Replace('_', '-').ToLowerInvariant(),
                    Status = 'A',
                    DateCreated = DateTimeOffset.Now
                };

                await context.Resource.AddAsync(newResource);

                EntityPokeAPI newEndPoint = new()
                {
                    Id = Guid.NewGuid(),
                    ResourceCode = (int)resource,
                    InternalID = $"{resource}",
                    Domain = "https://pokeapi.co",
                    Slug = "/v2",
                    Permalink = "/api",
                    Parameter = "/{param}",
                    Status = 'A',
                    DateCreated = DateTimeOffset.Now
                };

                await context.PokeAPI.AddAsync(newEndPoint);
            }

            int result = await context.SaveChangesAsync();

            if (result != 0)
            {
                int var = 0;
            }
        }
    }
}
