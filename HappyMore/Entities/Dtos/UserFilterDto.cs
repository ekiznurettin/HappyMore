namespace Entities.Dtos
{
    public class UserFilterDto
    {
        public string UserKey { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int Interest { get; set; }
        public int LatMin { get; set; }
        public int LatMax { get; set; }
        public int LngMax { get; set; }
        public int LngMin { get; set; }
    }
}
