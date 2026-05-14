using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;

namespace KeszletManager
{
    public class Termek
    {
        public int Id { get; set; }
        public string Nev { get; set; } = "";
        public decimal Ar { get; set; }
        public int Mennyiseg { get; set; }
    }

    public static class DatabaseHelper
    {
        private static readonly string DbPath = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
            "KeszletManager", "keszlet.db");

        private static string ConnectionString => $"Data Source={DbPath}";

        public static void AdatbazisLetrehozasa()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DbPath)!);

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS Termekek (
                    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nev       TEXT    NOT NULL,
                    Ar        REAL    NOT NULL,
                    Mennyiseg INTEGER NOT NULL
                );";

            using var cmd = new SqliteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        public static List<Termek> OsszeTermekLekerese()
        {
            var lista = new List<Termek>();

            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            string sql = "SELECT Id, Nev, Ar, Mennyiseg FROM Termekek ORDER BY Nev;";
            using var cmd = new SqliteCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Termek
                {
                    Id = reader.GetInt32(0),
                    Nev = reader.GetString(1),
                    Ar = (decimal)reader.GetDouble(2),
                    Mennyiseg = reader.GetInt32(3)
                });
            }

            return lista;
        }

        public static void TermekHozzaadasa(Termek t)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            string sql = "INSERT INTO Termekek (Nev, Ar, Mennyiseg) VALUES (@nev, @ar, @mennyiseg);";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nev", t.Nev);
            cmd.Parameters.AddWithValue("@ar", (double)t.Ar);
            cmd.Parameters.AddWithValue("@mennyiseg", t.Mennyiseg);
            cmd.ExecuteNonQuery();
        }

        public static void TermekFrissitese(Termek t)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            string sql = "UPDATE Termekek SET Nev=@nev, Ar=@ar, Mennyiseg=@mennyiseg WHERE Id=@id;";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nev", t.Nev);
            cmd.Parameters.AddWithValue("@ar", (double)t.Ar);
            cmd.Parameters.AddWithValue("@mennyiseg", t.Mennyiseg);
            cmd.Parameters.AddWithValue("@id", t.Id);
            cmd.ExecuteNonQuery();
        }

        public static void TermekTorlese(int id)
        {
            using var conn = new SqliteConnection(ConnectionString);
            conn.Open();

            string sql = "DELETE FROM Termekek WHERE Id=@id;";
            using var cmd = new SqliteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
