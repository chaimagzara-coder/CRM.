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
