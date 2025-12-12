using System;
using System.Collections.Generic;

namespace CRM
{
    public class Client
    {
        // Constructeur utilisé pour la création initiale
        public Client(string email, string nom, string telephone)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Nom = nom ?? throw new ArgumentNullException(nameof(nom));
            Telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
        }

        // Constructeur par défaut nécessaire pour les désérialiseurs (GetClients)
        // Les = null! résolvent l'avertissement CS8618
        public Client() { }

        public int Id { get; set; }
        public string Nom { get; set; } = null!;      // Correction CS8618
        public string Email { get; set; } = null!;    // Correction CS8618
        public string Telephone { get; set; } = null!; // Correction CS8618
        public DateTime DateInscription { get; set; } = DateTime.Now;
    }
}