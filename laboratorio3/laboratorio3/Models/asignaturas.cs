﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio3.Models
{
    public class asignaturas
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public int unidades_valorativas { get; set; }
        public string? ciclo { get; set; }
        public int inscritos { get; set; }

    }
}
