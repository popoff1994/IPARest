using RestExcercise.Models;


namespace RestExcercise.Managers
{
    public class IPAsManager
    {
        private static int _nextId = 1;
        private static readonly List<IPA> Data = new List<IPA>
        {
            new IPA{Id = _nextId++, Proof = 7.5, Name = "Wipeout IPA", Brand = "Port Brewing" },
            new IPA{Id = _nextId++, Proof = 6.0, Name = "Interboro", Brand = "Premiere" },
            new IPA{Id = _nextId++, Proof = 8.0, Name = "Citra", Brand = "Kern River"}
        };
           
        public List<IPA> GetAll(string substring, double proof)
        {
            
            if (substring != null)
            {
                List<IPA> ipas = Data.FindAll(ipa => ipa.Name.Contains(substring));
                return ipas;
            }
            else if(proof > 0)
            {
                List<IPA> ipas = Data.FindAll(ipa => ipa.Proof.Equals(proof));
                return ipas;
            }
            else
            return new List<IPA>(Data);
        }

        public IPA GetById(int id)
        {
            return Data.Find(ipa => ipa.Id == id);
        }
           
        public IPA Add(IPA newIPA)
        {
            newIPA.Id = _nextId++;
            Data.Add(newIPA);
            return newIPA;
        }

        public IPA Delete(int id)
        {
            IPA ipa = Data.Find(ipa1 => ipa1.Id == id);
            if (ipa == null) return null;
            Data.Remove(ipa);
            return ipa;
        }
        public IPA Update(int id, IPA updates)
        {
            IPA ipa = Data.Find(ipa1 => ipa1.Id == id);
            if (ipa == null) return null;
            ipa.Proof = updates.Proof;
            ipa.Name = updates.Name;
            ipa.Brand = updates.Brand;
            return ipa;
        }
    }
}
