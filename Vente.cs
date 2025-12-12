using System;

namespace CRM
{
    public class Vente
    {
        // Constructeur par défaut (nécessaire pour SqliteHelper.GetVentes)
        public Vente() { }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public double Montant { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DateVente { get; set; } = DateTime.Now;
    }
}