namespace Bismark.Escobar.Models
{
    public class Cliente
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Generos Sexo { get; set; }
        public decimal Ingresos { get; set; }

    }
}
