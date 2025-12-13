<<<<<<< HEAD
﻿using System;

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
=======
using System;

public class Vente
{
    public int Id { get; set; }
    public required string Produit { get; set; }
    public double Montant { get; set; }
    public DateTime DateVente { get; set; } = DateTime.Now;

    public required Client Client { get; set; }
    public required Employe EmployeResponsable { get; set; }
}
>>>>>>> e5661b02a036e3233ff0c69dafca978054cfe095
