using System;


namespace WebAPI.Data.DataModels
{
    public class ServicePackage
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DurationTime { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
