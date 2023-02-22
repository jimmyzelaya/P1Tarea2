using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace P1Tarea2.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(60)]
        public string Nombre { get; set; }

        [MaxLength(60)]
        public string Apellidos { get; set; }

        [MaxLength(3)]
        public string Edad { get; set; }

        public string Correo { get; set; }

        [MaxLength(60)]
        public string Direccion { get; set; }
    }
}
