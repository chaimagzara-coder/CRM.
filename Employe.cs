using System;

public class Employe
{
    public int Id { get; set; }
    public required string Nom { get; set; }
    public required string EmailProfessionnel { get; set; }
    public required string Role { get; set; } // exemple : Commercial, Manager

    public void AssignerLead(Lead lead)
    {
        lead.AssigneA = this;
    }
}
