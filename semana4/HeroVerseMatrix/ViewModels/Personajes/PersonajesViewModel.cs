using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeroVerseMatrix.Domain.ViewModels.Personajes
{
    public class PersonajeViewModel
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }

        public string CasaMatriz { get; set; }

        public bool EsHeroe { get; set; }

    }
}