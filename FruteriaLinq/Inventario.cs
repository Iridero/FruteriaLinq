using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace FruteriaLinq
{
    public class Inventario
    {
        string rutaCategoria = "categorias.dat";
        public Inventario()
        {
            if (File.Exists(rutaCategoria))
            {
                CargarCategoria();
            }
            else
            {
                Categorias = new List<Categoria>();
            }
        }
        public List<Categoria> Categorias { get; private set; }
        /// <summary>
        /// Agrega una categoría a la lista de categorías
        /// </summary>
        /// <param name="nombre">Nombre de la nueva categoría</param>
        /// <exception cref="System.ArgumentException">Si el nombre de la categoría es nulo o está vacío</exception>
        public void AgregarCategoria(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre de la categoria no debe estar vacío");
            }
            if (Categorias.Any(cat=>cat.Nombre.ToUpper()==nombre.Trim().ToUpper()))
            {
                throw new ArgumentException("El nombre ya esta registrado");
            }
            else
            {
                int id = Categorias.Select(cat => cat.Id).LastOrDefault();
                id++;
                Categorias.Add(
                    new Categoria
                    {
                        Id = id,
                        Nombre = nombre.Trim(),
                        Eliminada=false
                    }
                    ); ;
            }
        }


        public void GuardarCategorias()
        {
            FileStream fs = new FileStream(rutaCategoria, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                formatter.Serialize(fs, Categorias);
            }
            catch
            {
                throw;
            }
            finally
            {
                fs.Close();
            }

        }

        public void CargarCategoria()
        {
            if (File.Exists(rutaCategoria))
            {
                FileStream fs = new FileStream(rutaCategoria, FileMode.Open);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Categorias = (List<Categoria>)formatter.Deserialize(fs);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    fs.Close();
                }
            }
        }
    }
}
