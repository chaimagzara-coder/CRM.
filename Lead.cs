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

