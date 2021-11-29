
namespace TraningSessionApi.Entities
{
    public class Weapon : BaseEntity
    {
        public string Type { get; set; }

        public string Caliber { get; set; }

        public bool Favorit { get; set; }
    }
}
