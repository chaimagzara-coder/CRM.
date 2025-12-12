namespace CRM
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialisation standard de la configuration de l'application WinForms
            ApplicationConfiguration.Initialize();

            // ⭐ ÉTAPE CLÉ 1: S'assurer que le fichier de base de données (crm.db) et les tables existent.
            // Si la DB n'existe pas, SqliteHelper.InitializeDatabase() la crée.
            SqliteHelper.InitializeDatabase();

            // ⭐ ÉTAPE CLÉ 2: Lancer l'application et afficher le formulaire principal.
            Application.Run(new Form1());
        }
    }
}