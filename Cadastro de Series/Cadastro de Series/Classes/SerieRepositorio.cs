using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dio.Series.interfaces;
using System.Data.SQLite;
using Dio.Series;
using System.Data;

namespace DIO.Series
{
    public class SerieRepositorio
    {
        private static SQLiteConnection conexao;
        public static string caminho = Environment.CurrentDirectory;
        public static string nomeBanco = "cadastro_series.db";
        public static string caminhoBanco = caminho + @"\banco\";

        private static SQLiteConnection conexaoBanco()
        {
            conexao = new SQLiteConnection("Data Source = " + caminhoBanco + nomeBanco);
            conexao.Open();
            return conexao;
        }

        public void Atualiza(int id, string titulo, string genero, int ano, String descricao)
        {
            var comando = conexaoBanco().CreateCommand();
            comando.CommandText = "UPDATE series SET titulo = @titulo, genero = @genero, ano = @ano, descricao = @descricao WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@titulo", titulo);
            comando.Parameters.AddWithValue("@genero", genero);
            comando.Parameters.AddWithValue("@ano", ano);
            comando.Parameters.AddWithValue("@descricao", descricao);

            comando.ExecuteNonQuery();
            Console.WriteLine(" ");
            Console.WriteLine("Série atualizada com sucesso!");
            conexaoBanco().Close();
        }

        public void Exclui(int id)
        {
            var comando = conexaoBanco().CreateCommand();
            comando.CommandText = "DELETE FROM series WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
            Console.WriteLine("Série excluída com sucesso!");
            conexaoBanco().Close();
        }

        public void Insere(string titulo, string genero, int ano, String descricao)
        {
            var comando = conexaoBanco().CreateCommand();
            comando.CommandText = "INSERT INTO series (titulo, genero, ano, descricao) VALUES (@titulo, @genero, @ano, @descricao)";
            comando.Parameters.AddWithValue("@titulo", titulo);
            comando.Parameters.AddWithValue("@genero", genero);
            comando.Parameters.AddWithValue("@ano", ano);
            comando.Parameters.AddWithValue("@descricao", descricao);

            comando.ExecuteNonQuery();
            Console.WriteLine(" ");
            Console.WriteLine("Série cadastrada com sucesso!");
            conexaoBanco().Close();
        }

        public void Lista()
        {
            //Fonte: https://docs.microsoft.com/pt-br/azure/azure-sql/database/connect-query-dotnet-visual-studio
            {
                Console.WriteLine("\nCadastro de Séries");
                Console.WriteLine("=========================================\n");

                var comando = conexaoBanco().CreateCommand();
                comando.CommandText = "SELECT * FROM series";
                {
                    conexaoBanco();
                    using SQLiteDataReader reader = comando.ExecuteReader();
                    {
                        string str = " ";
                        char pad = '-';

                        Console.WriteLine("|" + str.PadLeft(96, pad));
                        Console.WriteLine("|  ID |        TÍtulo        |       Gênero        |        Ano        |        Descrição      |");

                        while (reader.Read())
                        {
                            Console.WriteLine("|" + str.PadLeft(96, pad));
                            Console.WriteLine("|  {0}  |     {1}     |     {2}     |     {3}     |     {4}     |", 
                            reader.GetInt32(0), 
                            reader.GetString(1), 
                            reader.GetString(2), 
                            reader.GetInt32(3), 
                            reader.GetString(4));
                        }
                
                        Console.WriteLine("|" + str.PadLeft(96, pad));
                        Console.WriteLine("");
                    }
                }
                conexaoBanco().Close();
            }
            
        }

        public void RetornaPorId(int id)
        {
            SQLiteDataReader dr;

            var comando = conexaoBanco().CreateCommand();
            comando.CommandText = "SELECT * FROM series WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);

            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Título: " + dr["titulo"]);
                Console.WriteLine("Gênero: " + dr["genero"]);
                Console.WriteLine("Ano: " + dr["ano"]);
                Console.WriteLine("Descrição: " + dr["descricao"]);
            }

            conexaoBanco().Close();
        }
    }
}
