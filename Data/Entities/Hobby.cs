

using System;


namespace DotNetWebApiPaginationHateoas.Data.Entities
{
    public class Hobby
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}