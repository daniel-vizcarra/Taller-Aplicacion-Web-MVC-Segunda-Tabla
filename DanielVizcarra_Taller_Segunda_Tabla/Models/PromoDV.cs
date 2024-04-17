namespace DanielVizcarra_EjercicioCF.Models
{
    public class PromoDV
    {
        public int PromoID { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaPromo { get; set; }

        public int BurgerID { get; set; }
        public BurgerDV? Burger { get; set; }

    }
}
