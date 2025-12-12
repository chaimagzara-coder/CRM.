// Requires the NuGet package Microsoft.Data.Sqlite:
//    dotnet add package Microsoft.Data.Sqlite


namespace CRM
{
    internal class SQLiteConnection : IDisposable
    {
        private string v;

        public SQLiteConnection(string v)
        {
            this.v = v;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}