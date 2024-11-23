namespace Dominio;
public class Sistema
{
	private static Sistema _instancia;

	public List<Usuario> listaUsuario = new List<Usuario>();
	public List<Articulo> listaArticulos = new List<Articulo>();
	public List<Publicacion> listaPublicaciones = new List<Publicacion>();

	public Sistema() { }


	#region Patrón Singleton 

	public static Sistema Instancia
	{
		get
		{
			if (_instancia == null)
			{
				_instancia = new Sistema();
			}

			return _instancia;
		}
	}
	#endregion

	// PRECARGA DE DATOS.
	private void PrecargarClientes()
	{
		listaUsuario.AddRange(new List<Cliente>
		{
		new Cliente("Pedro", "García", "pedro.garcia@email.com", "pass1234", 1500.75m),
		new Cliente("Ana", "Lopez", "ana.lopez@email.com", "anaPass99", 2100.50m),
		new Cliente("Carlos", "Martinez", "carlos.martinez@email.com", "carlos123", 1800.00m),
		new Cliente("Lucia", "Perez", "lucia.perez@email.com", "luciaSecure", 1350.30m),
		new Cliente("Juan", "Ramirez", "juan.ramirez@email.com", "juanRpass", 2500.40m),
		new Cliente("Laura", "Sanchez", "laura.sanchez@email.com", "laura!123", 3200.75m),
		new Cliente("Miguel", "Fernandez", "miguel.fernandez@email.com", "miguelPass", 1100.20m),
		new Cliente("Sofia", "Gomez", "sofia.gomez@email.com", "sofiaSafe", 2700.85m),
		new Cliente("Diego", "Torres", "diego.torres@email.com", "diegoPass1", 1450.90m),
		new Cliente("Valeria", "Castro", "valeria.castro@email.com", "valeria1234", 1980.60m),

		});
	}
	private void PrecargarArticulos()
	{
		listaArticulos.AddRange(new List<Articulo>
		{
			new Articulo("Teclado Mecanico", "Electronica", 79.99f),
			new Articulo("Mouse Gamer", "Electronica", 49.99f),
			new Articulo("Monitor 24 pulgadas", "Electronica", 159.99f),
			new Articulo("Silla ergonomica", "Mobiliario", 299.99f),
			new Articulo("Escritorio", "Mobiliario", 199.99f),
			new Articulo("Auriculares Bluetooth", "Electronica", 89.99f),
			new Articulo("Laptop", "Electronica", 1200.00f),
			new Articulo("Smartphone", "Electronica", 699.99f),
			new Articulo("Tablet", "Electronica", 499.99f),
			new Articulo("Lampara de escritorio", "Mobiliario", 39.99f),
			new Articulo("Impresora", "Electronica", 150.00f),
			new Articulo("Router Wi-Fi", "Electronica", 59.99f),
			new Articulo("Disco duro externo", "Electronica", 89.99f),
			new Articulo("Memoria USB", "Electronica", 19.99f),
			new Articulo("Camara Web", "Electronica", 79.99f),
			new Articulo("Microfono", "Electronica", 49.99f),
			new Articulo("Cargador portatil", "Accesorios", 25.99f),
			new Articulo("Ventilador de escritorio", "Mobiliario", 45.99f),
			new Articulo("Cafetera", "Electrodomesticos", 99.99f),
			new Articulo("Cargador inalambrico", "Electronica", 29.99f),
			new Articulo("Smartwatch", "Electronica", 199.99f),
			new Articulo("Bateria externa", "Accesorios", 49.99f),
			new Articulo("Altavoces Bluetooth", "Electronica", 129.99f),
			new Articulo("Reloj de pared", "Mobiliario", 19.99f),
			new Articulo("Taza termica", "Accesorios", 15.99f),
			new Articulo("Libreta de notas", "Papeleria", 9.99f),
			new Articulo("Boligrafo", "Papeleria", 1.99f),
			new Articulo("Mousepad", "Accesorios", 12.99f),
			new Articulo("Camara de seguridad", "Electronica", 99.99f),
			new Articulo("Enrutador", "Electronica", 79.99f),
			new Articulo("Proyector", "Electronica", 259.99f),
			new Articulo("Parlante portatil", "Electronica", 89.99f),
			new Articulo("Linterna LED", "Accesorios", 19.99f),
			new Articulo("Ventilador de techo", "Mobiliario", 150.00f),
			new Articulo("Refrigerador", "Electrodomesticos", 799.99f),
			new Articulo("Licuadora", "Electrodomesticos", 49.99f),
			new Articulo("Aspiradora", "Electrodomesticos", 199.99f),
			new Articulo("Plancha", "Electrodomesticos", 35.99f),
			new Articulo("Planchita de cabello", "Electrodomesticos", 29.99f),
			new Articulo("Estuche de celular", "Accesorios", 9.99f),
			new Articulo("Protector de pantalla", "Accesorios", 4.99f),
			new Articulo("Cuchillo de chef", "Cocina", 24.99f),
			new Articulo("Juego de ollas", "Cocina", 129.99f),
			new Articulo("Tostadora", "Electrodomesticos", 29.99f),
			new Articulo("Parrilla electrica", "Electrodomesticos", 69.99f),
			new Articulo("Termo", "Accesorios", 19.99f),
			new Articulo("Botella de agua", "Accesorios", 15.99f),
			new Articulo("Audifonos deportivos", "Accesorios", 29.99f),
			new Articulo("Bicicleta", "Deportes", 499.99f)

		});
	}
	private void PrecargarAdministradores()
	{
		listaUsuario.AddRange(new List<Administrador>
		{
			new Administrador("Carlos", "Ramírez", "carlos.ramirez@email.com", "admin1234"),
			new Administrador("Lucía", "Castro", "lucia.castro@email.com", "admin5678")
		});
	}
	private void PrecargarPublicaciones()
	{
		listaPublicaciones.AddRange(new List<Publicacion>
	{
		new Venta("Venta de Teclados", "venta", new DateTime(2024, 1, 1), null, true, 69.99f), // Abierta
		new Venta("Venta de Laptops", "venta", new DateTime(2024, 1, 2), null, false, 1199.99f), // Abierta
		new Venta("Venta de Sillas", "venta", new DateTime(2024, 1, 3), new DateTime(2024, 1, 12), false, 249.99f), // Cerrada
		new Venta("Venta de Monitores", "venta", new DateTime(2024, 1, 4), new DateTime(2024, 1, 13), true, 149.99f), // Cerrada
		new Venta("Venta de Smartphones", "venta", new DateTime(2024, 1, 5), null, false, 699.99f), // Abierta
		new Venta("Venta de Auriculares", "venta", new DateTime(2024, 1, 6), null, true, 79.99f), // Abierta
		new Venta("Venta de Impresoras", "venta", new DateTime(2024, 1, 7), new DateTime(2024, 1, 16), false, 129.99f), // Cerrada
		new Venta("Venta de Cafeteras", "venta", new DateTime(2024, 1, 8), new DateTime(2024, 1, 17), true, 99.99f), // Cerrada
		new Venta("Venta de Ventiladores", "venta", new DateTime(2024, 1, 9), null, false, 45.99f), // Abierta
		new Venta("Venta de Licuadoras", "venta", new DateTime(2024, 1, 10), new DateTime(2024, 1, 19), true, 49.99f), // Cerrada
		new Subasta("Subasta de Bicicletas", "subasta", new DateTime(2024, 1, 1), new DateTime(2024, 1, 10), 100.00f), // Cerrada
		new Subasta("Subasta de Relojes", "subasta", new DateTime(2024, 1, 2), new DateTime(2024, 1, 11), 200.00f),   // Cerrada
		new Subasta("Subasta de Teléfonos", "subasta", new DateTime(2024, 1, 3), null, 300.00f), // Abierta
		new Subasta("Subasta de Televisores", "subasta", new DateTime(2024, 1, 4), null, 400.00f), // Abierta
		new Subasta("Subasta de Cámaras", "subasta", new DateTime(2024, 1, 5), new DateTime(2024, 1, 14), 500.00f),   // Cerrada
		new Subasta("Subasta de Libros", "subasta", new DateTime(2024, 1, 6), null, 50.00f), // Abierta
		new Subasta("Subasta de Ropa", "subasta", new DateTime(2024, 1, 7), new DateTime(2024, 1, 16), 150.00f),      // Cerrada
		new Subasta("Subasta de Juguetes", "subasta", new DateTime(2024, 1, 8), null, 75.00f), // Abierta
		new Subasta("Subasta de Muebles", "subasta", new DateTime(2024, 1, 9), null, 600.00f), // Abierta
		new Subasta("Subasta de Computadoras", "subasta", new DateTime(2024, 1, 10), null, 700.00f) // Abierta


	});
		foreach (var publicacion in listaPublicaciones)
		{
			publicacion.ActualizarEstado(); 
		}

	}
	public void PrecargaDeDatos()
	{
		PrecargarPublicaciones();
		PrecargarArticulos();
		PrecargarAdministradores();
		PrecargarClientes();

	}


	public List<Cliente> ListarClientes()
	{
		List<Cliente> listaAuxiliar = new List<Cliente>();


		foreach (Usuario unUsuario in listaUsuario)
		{
			if (unUsuario is Cliente unCliente)
			{
				listaAuxiliar.Add(unCliente);
			}
		}

		if (listaAuxiliar.Count == 0)
		{
			throw new Exception("No se encontró ningún cliente.");
		}

		return listaAuxiliar;
	}

	public List<Administrador> ListarAdministradores()
	{
		List<Administrador> listaAuxiliar = new List<Administrador>();


		foreach (Usuario unUsuario in listaUsuario)
		{
			if (unUsuario is Administrador unAdm)
			{
				listaAuxiliar.Add(unAdm);
			}
		}

		if (listaAuxiliar.Count == 0)
		{
			throw new Exception("No se encontró ningún Administrador.");
		}

		return listaAuxiliar;
	}

	public List<Articulo> FiltrarArticulos(string categoriaSelected)
	{
		List<Articulo> articulosFinded = new List<Articulo>();

		foreach (Articulo art in listaArticulos)
		{
			if (string.Equals(art.Categoria, categoriaSelected, StringComparison.OrdinalIgnoreCase))
			{
				articulosFinded.Add(art);
			}


		}


		if (articulosFinded.Count == 0)
		{
			throw new Exception("No se encontró ningún artículo.");
		};


		return articulosFinded;
	}

	//SE MODIFICÓ EL MÉTODO PARA QUE RETORNE LAS PUBLICACIONES ORDENADAS POR FECHA. 
	public List<Publicacion> ObtenerPublicaciones()
	{
		listaPublicaciones.Sort();


		if (listaPublicaciones.Count == 0) 
		{
			throw new Exception("No existen publicaciones"); 
		}
		return listaPublicaciones;
	}

	public List<Subasta> ObtenerSubastas()
	{
		List<Subasta> listaSubastas = new List<Subasta>();

		foreach (var unaPublicacion in listaPublicaciones)
		{

			if (unaPublicacion is Subasta subasta)
			{
				listaSubastas.Add(subasta);
			}
		}

		return listaSubastas;
	}


	public List<Publicacion> LisatrPublicacionesPorFecha(string dateStart, string dateEnd)
	{
		DateTime dateStartCasted = DateTime.Parse(dateStart);
		DateTime dateEndCasted = DateTime.Parse(dateEnd);
		List<Publicacion> valuesFinded = new List<Publicacion>();
		foreach (Publicacion element in listaPublicaciones)
		{
			if (element.FechaPublicacion >= dateStartCasted && element.FechaFinalizacion <= dateEndCasted)
			{
				valuesFinded.Add(element);
			}
		}

		return
		valuesFinded;
	}

	public void AgregarArticulo(Articulo unArticulo)
	{
		unArticulo.Validar();
		listaArticulos.Add(unArticulo);
	}



	/*Comienzo testeo de frontEnd con Dominio*/
	public string IsRegister(string inputGmail, string inputPass)
	{
		string isRegister = "";


		foreach (Usuario unUsuario in listaUsuario)
		{
			if (unUsuario is Cliente unCliente && unUsuario.Email.Contains(inputGmail) && unUsuario.Contrasenia.Contains(inputPass))
			{
				isRegister = "client";
			}
			else if (unUsuario is Administrador administrador && unUsuario.Email.Contains(inputGmail) && unUsuario.Contrasenia.Contains(inputPass))
			{
				isRegister = "admin";
			}
		}
		return isRegister;
	}


	public bool NewClientRegister(string firstName, string lastName, string email, string password)
	{
		bool succeed = false;
		bool isRegister = false;


		foreach (Usuario unUsuario in listaUsuario)
		{
			if (unUsuario.Email.Equals(email) && unUsuario.Contrasenia.Equals(password))
			{
				isRegister = true;
			}
		}

		if (isRegister)
		{
			succeed = false;
		}
		else
		{
			listaUsuario.Add(new Cliente(firstName, lastName, email, password, 0.0m));
			succeed = true;
		}

		return succeed;
	}

	//MÉTODO PARA OBTENER EL USUARIO SEGÚN SU ID...

	public Usuario? ObtenerUsuarioPorId(int id) 
	{
		foreach (Usuario unUsuario in listaUsuario) 
		{
			if (unUsuario.Id == id) 
			{
				return unUsuario; 
			}
		}

		return null; 
	}



	//MÉTODO PARA OBTENER EL USUARIO SEGÚN UN EMAIL Y CONTRASEÑA... 

	public Usuario? ObtenerUsuario(string email, string contraseña)
	{
		foreach (Usuario unUsuario in listaUsuario)
		{
			if (unUsuario.Email == email && unUsuario.Contrasenia == contraseña)
			{
				return unUsuario; 
			}
		}

		return null; 
	}

	//MÉTODO PARA DETERMINAR SI EXISTE EL USUARIO SEGÚN EL MAIL INGRESADO... 

	public void ExisteUsuario(Usuario usuarioIngresado) 
	{
		foreach (Usuario unUsuario in listaUsuario) 
		{
			if (unUsuario.Equals(usuarioIngresado)) 
			{
				throw new Exception("El usuario ingresado ya está presente en el sistema."); 
			}
		}
	}

	//MÉTODO PARA AGREGAR UN USUARIO QUE RECIÉN NOS REGISTRAN... 

	public void AgregarCliente(Usuario clienteRecibido) 
	{
		try
		{
			ExisteUsuario(clienteRecibido);
            clienteRecibido.Validar();
			listaUsuario.Add(clienteRecibido); 
		}
		catch (Exception ex) 
		{
			throw ex; 
		}
	}

	//MÉTODO PARA OBTENER UN CLIENTE POR SU MAIL... 
	public Cliente? ObtenerClienteMail(string email) 
	{
		foreach (Usuario unUsuario in listaUsuario) 
		{
			if (unUsuario is Cliente && unUsuario.Email== email) 
			{
				return unUsuario as Cliente; 
			}
		}

		return null; 
	}

	//MÉTODO PARA OBTENER UNA PUBLICACIÓN POR ID. 
	public Publicacion? ObtenerPublicacionPorId(int idPublicacion) 
	{
		foreach (Publicacion unaPublicacion in listaPublicaciones) 
		{
			if (unaPublicacion.Id == idPublicacion) 
			{
				return unaPublicacion; 
			}
		}

		return null; 
	}

	//MÉTODO PARA OBTENER LA VENTA SEGÚN EL ID. 
	public Venta? ObtenerVentaPorId(int unaVenta) 
	{
		foreach (Publicacion unaPublicacion in listaPublicaciones) 
		{
			if (unaPublicacion.Id == unaVenta) 
			{
				return unaPublicacion as Venta; 
			}
		}

		return null; 
	}

	//MÉTODO PARA PROCESAR LA COMPRA DE UNA PUBLICACIÓN. 
	public void ProcesarCompra(string emailCliente, int idPublicacion) 
	{
		Publicacion? unaPublicacion = ObtenerPublicacionPorId(idPublicacion); 
		Venta? unaVenta = ObtenerVentaPorId(idPublicacion);
		Cliente? unCliente = ObtenerClienteMail(emailCliente);
		try
		{
			unaPublicacion.PublicacionEstaAbierta(unaPublicacion); 
			unCliente.ValidarSaldoSuficiente(decimal.Parse(unaVenta.PrecioVenta.ToString()));
			unaVenta.CerrarPublicacion(unCliente); 
		}
		catch (Exception ex) 
		{
			throw ex; 
		}
	}


}




