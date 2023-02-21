using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Biblioteca_da_Patricia.Opcoes
{
    public class BancoDeDados
    {
        private SQLiteConnection sqliteConnection;
        public static readonly string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string banco = Path.Combine(BasePath, nameof(BancoDeDados) + ".sqlite");
        private static readonly string DatabaseName = "BibliotecaPaty";
        private readonly string TableName = "Livro";
        public static string ConnectionString = $"Data Source={banco}; Version=3;";

        public BancoDeDados()
        {
            if (!File.Exists(banco))
            {
                CriarBancoSQLite();
            }

            sqliteConnection = GetDbConnection();
        }

        private SQLiteConnection GetDbConnection()
        {
            sqliteConnection = new SQLiteConnection(ConnectionString);
            sqliteConnection.Open();
            return sqliteConnection;
        }

        private void CriarBancoSQLite()
        {
            try
            {
                SQLiteConnection.CreateFile(banco);
                GetDbConnection();
                CriarTabelaSQlite();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro BancoDeDados CriarBancoSQLite: {ex}", "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = $"CREATE TABLE IF NOT EXISTS {TableName}(Nome Varchar(50), Autor Varchar(25), Genero Varchar(25), SubGenero Varchar(30), Pratileira Varchar(2), Ano Varchar(4), Lido Bit)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error BancoDeDados CreiarTabelaSQLite: {ex}", "Tabela", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int Contador()
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM [Livro]";

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count + 1;
            }
        }

        public DataTable GetAll()
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM [Livro]";
                DataSet ds = new DataSet();
                SQLiteDataAdapter sqlDataAdapter = new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);

                sqlDataAdapter.Fill(ds);
                return ds.Tables[0];
            }
        }

        public void Add(string nome, string autor, string genero, string subGenero, string pratileira, string ano, bool lido)
        {
            try
            {
                using (var cmd = sqliteConnection.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO {TableName}(Nome, Autor, Genero, SubGenero, Pratileira, Ano, Lido) VALUES (@Nome, @Autor, @Genero, @SubGenero, @Pratileira, @Ano, @Lido)";
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Autor", autor);
                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@SubGenero", subGenero);
                    cmd.Parameters.AddWithValue("@Pratileira", pratileira);
                    cmd.Parameters.AddWithValue("@Ano", ano);
                    cmd.Parameters.AddWithValue("@Lido", lido);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro BancoDeDados Adicionar: {ex}", "Adicionar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Atualizar(string nome, string autor, string genero, string subGenero, string pratileira, string ano, bool lido)
        {
            //COLOCAR SEGURANÇÃO SE NÃO HOUVER LIVROS, DEIXAR TODAS OPÇÕES DESABILITADAS


            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "UPDATE [Livro] SET Nome = @Nome, Autor = @Autor, Genero = @Genero, SubGenero = @SubGenero, Pratileira = @Pratileira, Ano = @Ano, Lido = @Lido WHERE Nome =" + nome;

                cmd.Parameters.AddWithValue("@Autor", autor);
                cmd.Parameters.AddWithValue("@Genero", genero);
                cmd.Parameters.AddWithValue("@SubGenero", subGenero);
                cmd.Parameters.AddWithValue("@Pratileira", pratileira);
                cmd.Parameters.AddWithValue("@Ano", ano);
                cmd.Parameters.AddWithValue("@Lido", lido);

                cmd.ExecuteNonQuery();
            }
        }

        public bool VerificacaoNome(string nome)
        {
            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = $"SELECT COUNT(*) FROM {TableName} WHERE Nome = LOWER(@Nome)";
                cmd.Parameters.AddWithValue("@Nome", nome);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    MessageBox.Show("Esse livro já existe.", "Livro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }
            return false;
        }

        public void Delete(string nome)
        {
            try
            {
                string sql = $"DELETE FROM {TableName} Where Nome = @Nome";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, sqliteConnection))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro BancoDeDados Excluir: {ex}", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public SQLiteDataAdapter AtualizarTextChanged(string nome)
        {

            using (SQLiteCommand cmd = sqliteConnection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM [Livro] WHERE Nome ='" + nome + "'";
                return new SQLiteDataAdapter(cmd.CommandText, sqliteConnection);
            }
        }
    }
}
