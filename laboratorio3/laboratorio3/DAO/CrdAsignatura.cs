using laboratorio3.Data;
using laboratorio3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio3.DAO
{
    public class CrdAsignatura
    {
        AsignaturaContext db = new AsignaturaContext();

        public  CrdAsignatura Asignaturaindivi(int id)
        {
            var buscar = db.Asignatura.FirstOrDefault(x => x.id == id);
            return buscar;
        }

    }
}
