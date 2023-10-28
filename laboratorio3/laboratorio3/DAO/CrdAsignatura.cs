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
        public asignaturas AsignaturaIndivi(int Id)
        {
            var buscar = db.asignaturas.FirstOrDefault(x => x.id == Id);
            return buscar;
        }

        public void CreateAsig(asignaturas Asig)
        {
            asignaturas asignaturas = new asignaturas();
            asignaturas.nombre = Asig.nombre;
            asignaturas.unidades_valorativas = Asig.unidades_valorativas;
            asignaturas.ciclo = Asig.ciclo;
            asignaturas.inscritos = Asig.inscritos;

            db.Add(asignaturas);
            db.SaveChanges();
        }

        public void UpdateAsig(asignaturas asignaturas, int L)
        {
            var buscar = AsignaturaIndivi(asignaturas.id);
            if (buscar == null)
            {
                Console.WriteLine("el id no existente");
            }
            else
            {
                if (L == 1)
                {
                    buscar.nombre = asignaturas.nombre;
                }

                else if( L == 2)
                {
                    buscar.unidades_valorativas = asignaturas.unidades_valorativas;
                }

                else if (L == 3)
                {
                    buscar.ciclo = asignaturas.ciclo;
                }

                else if (L == 4)
                {
                    buscar.inscritos = asignaturas.inscritos;
                }
                db.Update(asignaturas);
                db.SaveChanges();
            }
        }
    }    
}
