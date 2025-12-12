// Requires the NuGet package Microsoft.Data.Sqlite:
//    dotnet add package Microsoft.Data.Sqlite


namespace CRM
{
    internal interface ISqliteHelper
    {
        static abstract int AddClient(Client client);
        static abstract int AddLead(Lead lead);
        static abstract int AddVente(Vente vente);
        static abstract void DeleteClient(int clientId);
        static abstract List<Client> GetClients();
        static abstract List<Lead> GetLeadsForClient(int clientId);
        static abstract void InitializeDatabase();
        static abstract void UpdateLeadStatus(int leadId, string newStatus);
    }
}