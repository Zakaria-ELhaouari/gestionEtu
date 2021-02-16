using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstPrjAspCore.Models.RepositorIes
{
    public class EtudiantsDbRepository : ISchool<Etudiant>
    {
        
        GestionEtuDbContext db;
        public EtudiantsDbRepository(GestionEtuDbContext _db)
        {
            db = _db;
        }
        public void Add(Etudiant eEntity)
        {
            db.Etudiants.Add(eEntity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var Etu = find(id);
            db.Etudiants.Remove(Etu);
            db.SaveChanges();
        }

        public Etudiant find(int id)
        {
            var Etu = db.Etudiants.SingleOrDefault(Etud => Etud.id == id);
            return Etu;
        }

        public IList<Etudiant> List()
        {
            return db.Etudiants.ToList();
        }

        public void Update(int id, Etudiant newEtudiant)
        {
            db.Update(newEtudiant);
            db.SaveChanges();
        }
    }
}