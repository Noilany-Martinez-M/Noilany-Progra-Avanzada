using System;

namespace ufide.mascotas.Models.Entities
{
    public static class MascotaFactory
    {
        public static Mascota Crear(TipoEspecie especie, string nombre, int
        mesNacimiento, int anioNacimiento)
        {
            Mascota mascota;
            switch (especie)
            {
                case TipoEspecie.CANINO:
                    mascota = new Perro(nombre, mesNacimiento, anioNacimiento);
                    break;
                case TipoEspecie.FELINO:
                    mascota = new Gato(nombre, mesNacimiento, anioNacimiento);
                    break;
                case TipoEspecie.REPTIL:
                    mascota = new Tortuga(nombre, mesNacimiento, anioNacimiento);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("especie");
            }
            return mascota;
        }
    }
}