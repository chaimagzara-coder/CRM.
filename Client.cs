using System;
using System.Collections.Generic;

public class Client
{
    public int Id { get; set; }
    public required string Nom { get; set; }
    public required string Email { get; set; }
    public required string Telephone { get; set; }
    public DateTime DateInscription { get; set; } = DateTime.Now;

    public Client(List<Lead> leads)
    {
        Leads = leads ?? throw new ArgumentNullException(nameof(leads));
    }

    public List<Lead> Leads { get; set; } = [];
    public List<Vente> Ventes { get; set; } = new List<Vente>();

    public void AjouterLead(Lead lead)
    {
        Leads.Add(lead);
    }

    public void AjouterVente(Vente vente)
    {
        Ventes.Add(vente);
    }
}
