namespace RestExcercise.Models
{
    public class IPA
    {
        public int Id { get; set; }
        public double Proof { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public IPA(int id, double proof, string name, string brand)
        {
            Id = id;
            Proof = proof;
            Name = name;
            Brand = brand;
        }

        public IPA()
        {
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
