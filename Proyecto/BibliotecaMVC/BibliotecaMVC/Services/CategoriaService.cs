using BibliotecaMVC.Models;
using Microsoft.Data.SqlClient;

namespace BibliotecaMVC.Services
{
    public class CategoriaService
    {
        private readonly string _connectionString;

        public CategoriaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("BibliotecaDB")!;
        }

        public IEnumerable<Categoria> ObtenerTodos()
        {
            var categorias = new List<Categoria>();
            const string sql = "SELECT ID, Nombre, Descripcion FROM Categorias ORDER BY Nombre";

            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand(sql, conexion);
            conexion.Open();

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                categorias.Add(MapearCategoria(lector));
            }

            return categorias;
        }

        public Categoria? ObtenerPorId(int id)
        {
            const string sql = "SELECT ID, Nombre, Descripcion FROM Categorias WHERE ID = @ID";

            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@ID", id);
            conexion.Open();

            using var lector = comando.ExecuteReader();
            return lector.Read() ? MapearCategoria(lector) : null;
        }

        public void Agregar(Categoria categoria)
        {
            const string sql = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)";

            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand(sql, conexion);
            AgregarParametros(comando, categoria);
            conexion.Open();
            comando.ExecuteNonQuery();
        }

        public bool Actualizar(int id, Categoria categoria)
        {
            const string sql = "UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE ID = @ID";

            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@ID", id);
            AgregarParametros(comando, categoria);
            conexion.Open();

            return comando.ExecuteNonQuery() > 0;
        }

        public bool Eliminar(int id)
        {
            const string sql = "DELETE FROM Categorias WHERE ID = @ID";

            using var conexion = new SqlConnection(_connectionString);
            using var comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@ID", id);
            conexion.Open();

            return comando.ExecuteNonQuery() > 0;
        }

        private static Categoria MapearCategoria(SqlDataReader lector)
        {
            return new Categoria
            {
                ID = lector.GetInt32(0),
                Nombre = lector.GetString(1),
                Descripcion = lector.IsDBNull(2) ? string.Empty : lector.GetString(2)
            };
        }

        private static void AgregarParametros(SqlCommand comando, Categoria categoria)
        {
            comando.Parameters.AddWithValue("@Nombre", categoria.Nombre);
            comando.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
        }
    }
}
