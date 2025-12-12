using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;

namespace CRM
{
    public static class SqliteHelper
    {
        // Le chemin de la base de données est relatif au dossier d'exécution (bin/Debug)
        private static string DbPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "crm.db");

        public static void InitializeDatabase()
        {
            using var connection = new SqliteConnection($"Data Source={DbPath}");
            connection.Open();

            // Création de la table Clients
            var createClientsTable = connection.CreateCommand();
            createClientsTable.CommandText =
                @"CREATE TABLE IF NOT EXISTS Clients (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nom TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Telephone TEXT NOT NULL,
                    DateInscription TEXT NOT NULL
                )";
            createClientsTable.ExecuteNonQuery();

            // Création de la table Leads
            var createLeadsTable = connection.CreateCommand();
            createLeadsTable.CommandText =
                @"CREATE TABLE IF NOT EXISTS Leads (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClientId INTEGER, 
                    Description TEXT NOT NULL,
                    Statut TEXT NOT NULL,
                    DateCreation TEXT NOT NULL,
                    FOREIGN KEY(ClientId) REFERENCES Clients(Id)
                )";
            createLeadsTable.ExecuteNonQuery();

            // Création de la table Ventes
            var createVentesTable = connection.CreateCommand();
            createVentesTable.CommandText =
                @"CREATE TABLE IF NOT EXISTS Ventes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ClientId INTEGER NOT NULL,
                    Montant REAL NOT NULL,
                    Description TEXT NOT NULL,
                    DateVente TEXT NOT NULL,
                    FOREIGN KEY(ClientId) REFERENCES Clients(Id)
                )";
            createVentesTable.ExecuteNonQuery();
        }

        // --- CLIENTS ---

        public static List<Client> GetClients()
        {
            var list = new List<Client>();
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Nom, Email, Telephone, DateInscription FROM Clients ORDER BY Id DESC";
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var client = new Client();
                client.Id = rdr.GetInt32(0);
                client.Nom = rdr.GetString(1);
                client.Email = rdr.GetString(2);
                client.Telephone = rdr.GetString(3);

                if (!rdr.IsDBNull(4))
                    client.DateInscription = DateTime.Parse(rdr.GetString(4));

                list.Add(client);
            }
            return list;
        }

        public static int AddClient(Client client)
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Clients (Nom, Email, Telephone, DateInscription) VALUES ($nom, $email, $tel, $date); SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("$nom", client.Nom);
            cmd.Parameters.AddWithValue("$email", client.Email);
            cmd.Parameters.AddWithValue("$tel", client.Telephone);
            cmd.Parameters.AddWithValue("$date", client.DateInscription.ToString("yyyy-MM-dd HH:mm:ss"));

            // Correction CS8605 : conversion sécurisée
            object result = cmd.ExecuteScalar();
            if (result is long idValue)
            {
                client.Id = (int)idValue;
                return client.Id;
            }
            return 0;
        }

        public static void DeleteClient(int clientId)
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var trans = conn.BeginTransaction();

            // 1. Supprimer les Ventes
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Ventes WHERE ClientId=$id";
                cmd.Parameters.AddWithValue("$id", clientId);
                cmd.ExecuteNonQuery();
            }
            // 2. Supprimer les Leads
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Leads WHERE ClientId=$id";
                cmd.Parameters.AddWithValue("$id", clientId);
                cmd.ExecuteNonQuery();
            }
            // 3. Supprimer le Client
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Clients WHERE Id=$id";
                cmd.Parameters.AddWithValue("$id", clientId);
                cmd.ExecuteNonQuery();
            }
            trans.Commit();
        }

        // --- LEADS ---

        public static List<Lead> GetLeads()
        {
            var list = new List<Lead>();
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, ClientId, Description, Statut, DateCreation FROM Leads ORDER BY Id DESC";
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Lead
                {
                    Id = rdr.GetInt32(0),
                    ClientId = rdr.GetInt32(1),
                    Description = rdr.GetString(2),
                    Statut = rdr.GetString(3),
                    DateCreation = DateTime.Parse(rdr.GetString(4))
                });
            }
            return list;
        }

        public static int AddLead(Lead lead)
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Leads (ClientId, Description, Statut, DateCreation) VALUES ($clientid, $desc, $statut, $date); SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("$clientid", lead.ClientId);
            cmd.Parameters.AddWithValue("$desc", lead.Description);
            cmd.Parameters.AddWithValue("$statut", lead.Statut);
            cmd.Parameters.AddWithValue("$date", lead.DateCreation.ToString("yyyy-MM-dd HH:mm:ss"));

            object result = cmd.ExecuteScalar();
            if (result is long idValue)
            {
                lead.Id = (int)idValue;
                return lead.Id;
            }
            return 0;
        }

        public static void DeleteLead(int leadId)
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Leads WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", leadId);
            cmd.ExecuteNonQuery();
        }


        // --- VENTES ---

        public static List<Vente> GetVentes()
        {
            var list = new List<Vente>();
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, ClientId, Montant, Description, DateVente FROM Ventes ORDER BY Id DESC";
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Vente
                {
                    Id = rdr.GetInt32(0),
                    ClientId = rdr.GetInt32(1),
                    Montant = rdr.GetDouble(2),
                    Description = rdr.GetString(3),
                    DateVente = DateTime.Parse(rdr.GetString(4))
                });
            }
            return list;
        }

        public static int AddVente(Vente vente)
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO Ventes (ClientId, Montant, Description, DateVente) VALUES ($clientid, $montant, $desc, $date); SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("$clientid", vente.ClientId);
            cmd.Parameters.AddWithValue("$montant", vente.Montant);
            cmd.Parameters.AddWithValue("$desc", vente.Description);
            cmd.Parameters.AddWithValue("$date", vente.DateVente.ToString("yyyy-MM-dd HH:mm:ss"));

            object result = cmd.ExecuteScalar();
            if (result is long idValue)
            {
                vente.Id = (int)idValue;
                return vente.Id;
            }
            return 0;
        }

        // Extrait de SqliteHelper.cs

        public static void UpdateClient(Client client)
        {
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();

            // Requête SQL pour mettre à jour la ligne où l'Id correspond
            cmd.CommandText =
                @"UPDATE Clients SET 
            Nom = $nom, 
            Email = $email, 
            Telephone = $tel
          WHERE Id = $id";

            cmd.Parameters.AddWithValue("$id", client.Id);
            cmd.Parameters.AddWithValue("$nom", client.Nom);
            cmd.Parameters.AddWithValue("$email", client.Email);
            cmd.Parameters.AddWithValue("$tel", client.Telephone);

            cmd.ExecuteNonQuery();
        }
    }


}