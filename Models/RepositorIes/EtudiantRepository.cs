using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstPrjAspCore.Models.RepositorIes
{
    public class EtudiantRepository : ISchool<Etudiant>
    {
        //List<Etudiant> Etudiants;

        //public EtudiantRepository()
        //{
        //    Etudiants = new List<Etudiant>();
        //    Etudiants.Add(new Etudiant() { id = 1, nom = "zack", prenome = "mery", CIN = "EE893", Adress = "marrakech" });
        //    Etudiants.Add(new Etudiant() { id = 2, nom = "anaf", prenome = "mery", CIN = "EF903", Adress = "marrakech" });
        //}
        //public Etudiant Get(int id)
        //{
        //    return Etudiants.SingleOrDefault(etd => etd.id == id);
        //}

        //public IEnumerable<Etudiant> GetEntitis()
        //{
        //    return Etudiants;
        //}
        List<Etudiant> Etudiants;
        public EtudiantRepository()
        {
            Etudiants = new List<Etudiant>()
            {
                new Etudiant{id = 1, nom = "zack", prenome = "mery", CIN = "EE893", Adress = "marrakech"},
                new Etudiant{id = 2, nom = "anaf", prenome = "mery", CIN = "EF903", Adress = "marrakech"},
            };
        }
        public void Add(Etudiant eEntity)
        {
            eEntity.id = Etudiants.Max(etu => etu.id) + 1;
            Etudiants.Add(eEntity);
        }

        public void Delete(int id)
        {
            var Etu = find(id);
            Etudiants.Remove(Etu);
        }

        public Etudiant find(int id)
        {
            var Etu = Etudiants.SingleOrDefault(Etud => Etud.id == id);
            return Etu;
        }

        public IList<Etudiant> List()
        {
            return Etudiants;
        }

        public void Update(int id, Etudiant newEtudiant)
        {
            var Etu = find(id);
            Etu.nom = newEtudiant.nom;
            Etu.prenome = newEtudiant.prenome;
            Etu.CIN = newEtudiant.CIN;
            Etu.Adress = newEtudiant.CIN;

        }
    }
}
