using System.ComponentModel.DataAnnotations;

namespace DanielVizcarra_EjercicioCF.Models
{
    public class PromoDV
    {
        [Key]
        public int PromoID { get; set; }
        
        public string? Descripcion { get; set; }
        public DateTime FechaPromo { get; set; }

        public int BurgerID { get; set; }
        public BurgerDV? Burger { get; set; }

    }
}
