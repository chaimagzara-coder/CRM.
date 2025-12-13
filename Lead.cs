<<<<<<< HEAD
﻿using System;

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
=======
using System;

public class Lead
{
    public int Id { get; set; }
    public required string Source { get; set; } // exemple : Facebook, Site Web, Appel
    public string Etat { get; set; } = "Nouveau";
    public required string Description { get; set; }
    public DateTime DateCreation { get; set; } = DateTime.Now;

    public required Employe AssigneA { get; set; }
    public required Client ClientLie { get; set; }

    public void ChangerEtat(string nouvelEtat)
    {
        Etat = nouvelEtat;
    }
}

>>>>>>> e5661b02a036e3233ff0c69dafca978054cfe095
