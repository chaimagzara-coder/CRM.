using System;

namespace CRM
{
    public class Lead
    {
        // Constructeur par défaut (nécessaire pour SqliteHelper.GetLeads)
        public Lead() { }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Statut { get; set; } = "Nouveau"; // Changé 'New' en 'Nouveau' pour cohérence
        public DateTime DateCreation { get; set; } = DateTime.Now;
    }
}