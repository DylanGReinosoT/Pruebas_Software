using GestionProductos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectProductos
{
	public class ProductControllerTest
	{
		[Fact]
		public void Test1()
		{
			//Configuracion de una prueba
			var producto = new Producto { Nombre = "Prueba", Precio = 10 };
			//Valicacion
			Assert.True(producto.Precio >= 0, "El precio es no es negativo");
		}
	}
}
