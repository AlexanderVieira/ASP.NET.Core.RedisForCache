namespace AVS.RegisCache.API.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Region { get; set; }
        public string Nationality { get; set; }

        public override string ToString()
        {
            return $"{Name} + {Capital} + {Region} + {Nationality}";
        } 
    }
}
