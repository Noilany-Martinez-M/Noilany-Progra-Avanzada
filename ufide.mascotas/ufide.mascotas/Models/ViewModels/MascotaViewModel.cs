using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ufide.mascotas.Models.Entities;

namespace ufide.mascotas.Models.ViewModels
{
    public class MascotaViewModel
    {
        [Required(ErrorMessage = "Seleccione una especie.")]
        public TipoEspecie? TipoEspecie { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(60, ErrorMessage = "El nombre no puede superar 60 caracteres.")]
        public string Nombre { get; set; }

        [Range(1970, 2026, ErrorMessage = "Seleccione un año entre 1970 y 2026.")]
        public int AnioNacimiento { get; set; }

        [Range(1,12, ErrorMessage ="Seleccione un mes entre 1(enero) y 12(diciembre)")]
        public int MesNacimiento { get; set;  }

        public int Id { get; }
        public IEnumerable<SelectListItem> Especies { get; set; }
        public IEnumerable<SelectListItem> Anios { get; set; }
        public IEnumerable<SelectListItem> Meses { get; set; }
    }
}