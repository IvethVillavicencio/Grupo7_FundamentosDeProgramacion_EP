// VALIDACION
SubProceso pos <- BuscarIndicePorCodigo(codigos, cantidad, codigoBuscado)
	Definir pos, i Como Entero
	pos <- -1
	Para i <- 1 Hasta cantidad Con Paso 1 Hacer
		Si codigos[i] = codigoBuscado Entonces
			pos <- i
		FinSi
	FinPara
FinSubProceso

SubProceso esValido <- ValidarCodigo(codigos, cantidad, cod)
	Definir esValido Como Logico
	Si cod <= 0 Entonces
		Escribir "Error: El código debe ser mayor a 0."
		esValido <- Falso
	Sino
		Si BuscarIndicePorCodigo(codigos, cantidad, cod) <> -1 Entonces
			Escribir "Error: El código ya existe."
			esValido <- Falso
		Sino
			esValido <- Verdadero
		FinSi
	FinSi
FinSubProceso

SubProceso esValido <- ValidarPrecio(prc)
	Definir esValido Como Logico
	Si prc > 0 Entonces
		esValido <- Verdadero
	Sino
		Escribir "Error: El precio debe ser mayor a 0."
		esValido <- Falso
	FinSi
FinSubProceso

SubProceso esValido <- ValidarStock(stk)
	Definir esValido Como Logico
	Si stk >= 0 Entonces
		esValido <- Verdadero
	Sino
		Escribir "Error: El stock no puede ser negativo."
		esValido <- Falso
	FinSi
FinSubProceso

SubProceso esValido <- ValidarDatos(nom, cat, prc, stk)
	Definir esValido Como Logico
	Si Longitud(nom) = 0 O Longitud(cat) = 0 Entonces
		Escribir "Error: Datos de texto no pueden estar vacíos."
		esValido <- Falso
	Sino
		Si ValidarPrecio(prc) Y ValidarStock(stk) Entonces
			esValido <- Verdadero
		Sino
			esValido <- Falso
		FinSi
	FinSi
FinSubProceso

// GESTION DE PRODUCTOS
//MOSTRAR
SubProceso MostrarProducto(productos, indice)
	Escribir Sin Bajar "Codigo: ", productos[indice, 1], " | Nombre: ", productos[indice, 2]
	Escribir "| Categoria: ", productos[indice, 3], " | Precio: S/", productos[indice, 4]
	Escribir " | Stock: ", productos[indice, 5]
FinSubProceso

SubProceso MostrarProductos(productos, cantidad)
	Definir i Como Entero
	Si cantidad = 0 Entonces
		Escribir "No hay productos registrados."
	Sino
		Para i <- 1 Hasta cantidad Con Paso 1 Hacer
			MostrarProducto(productos, i)
		FinPara
	FinSi
FinSubProceso
//REGISTRAR
SubProceso RegistrarProducto(codigos, productos, cantidad Por Referencia, capacidad)
	Definir cod, stk Como Entero
	Definir nom, cat Como Cadena
	Definir prc Como Real
	
	Si cantidad >= capacidad Entonces
		Escribir "Capacidad máxima alcanzada."
	Sino
		Escribir "Codigo del producto:"
		Leer cod
		Si ValidarCodigo(codigos, cantidad, cod) Entonces
			Escribir "Nombre del producto:"
			Leer nom
			Escribir "Categoria:"
			Leer cat
			Escribir "Precio:"
			Leer prc
			Escribir "Cantidad en stock:"
			Leer stk
			
			Si ValidarDatos(nom, cat, prc, stk) Entonces
				cantidad <- cantidad + 1
				codigos[cantidad] <- cod
				productos[cantidad, 1] <- ConvertirATexto(cod)
				productos[cantidad, 2] <- nom
				productos[cantidad, 3] <- cat
				productos[cantidad, 4] <- ConvertirATexto(prc)
				productos[cantidad, 5] <- ConvertirATexto(stk)
				Escribir "Producto registrado correctamente."
			FinSi
		FinSi
	FinSi
FinSubProceso
//BUSCAR POR CODIGO
SubProceso BuscarPorCodigo(productos, cantidad)
	Definir codBuscado, i Como Entero
	Definir hallado Como Logico
	hallado <- Falso
	Escribir "Codigo a buscar:"
	Leer codBuscado
	
	Para i <- 1 Hasta cantidad Con Paso 1 Hacer
		Si ConvertirANumero(productos[i, 1]) = codBuscado Entonces
			Escribir "Producto encontrado:"
			MostrarProducto(productos, i)
			hallado <- Verdadero
		FinSi
	FinPara
	Si NO hallado Entonces
		Escribir "Producto no encontrado."
	FinSi
FinSubProceso
//BUSCAR POR NOMBRE
SubProceso BuscarPorNombre(productos, cantidad)
	Definir nomBuscado Como Cadena
	Definir i Como Entero
	Definir hallado Como Logico
	hallado <- Falso
	Escribir "Nombre del producto:"
	Leer nomBuscado
	
	Para i <- 1 Hasta cantidad Con Paso 1 Hacer
		Si productos[i, 2] = nomBuscado Entonces
			MostrarProducto(productos, i)
			hallado <- Verdadero
		FinSi
	FinPara
	Si NO hallado Entonces
		Escribir "Producto no encontrado."
	FinSi
FinSubProceso
//MODIFICAR
SubProceso ModificarProducto(codigos, productos, cantidad)
	Definir codBuscado, pos, nuevoStock Como Entero
	Definir nuevoNom, nuevaCat Como Cadena
	Definir nuevoPrecio Como Real
	
	Escribir "Codigo del producto a modificar:"
	Leer codBuscado
	pos <- BuscarIndicePorCodigo(codigos, cantidad, codBuscado)
	
	Si pos = -1 Entonces
		Escribir "Producto no encontrado."
	Sino
		Escribir "Nuevo nombre:"
		Leer nuevoNom
		Escribir "Nueva categoría:"
		Leer nuevaCat
		Escribir "Nuevo precio:"
		Leer nuevoPrecio
		Escribir "Nuevo stock:"
		Leer nuevoStock
		
		Si ValidarDatos(nuevoNom, nuevaCat, nuevoPrecio, nuevoStock) Entonces
			productos[pos, 2] <- nuevoNom
			productos[pos, 3] <- nuevaCat
			productos[pos, 4] <- ConvertirATexto(nuevoPrecio)
			productos[pos, 5] <- ConvertirATexto(nuevoStock)
			Escribir "Producto modificado correctamente."
		FinSi
	FinSi
FinSubProceso
//ELIMINAR
SubProceso EliminarProducto(codigos, productos, cantidad Por Referencia)
	Definir codBuscado, pos, i, col Como Entero
	Escribir "Codigo a eliminar:"
	Leer codBuscado
	pos <- BuscarIndicePorCodigo(codigos, cantidad, codBuscado)
	
	Si pos = -1 Entonces
		Escribir "Producto no encontrado."
	Sino
		Para i <- pos Hasta cantidad - 1 Con Paso 1 Hacer
			codigos[i] <- codigos[i + 1]
			Para col <- 1 Hasta 5 Con Paso 1 Hacer
				productos[i, col] <- productos[i + 1, col]
			FinPara
		FinPara
		cantidad <- cantidad - 1
		Escribir "Producto eliminado correctamente."
	FinSi
FinSubProceso

// ORDENAMIENTO

SubProceso IntercambiarFilas(codigos, productos, i, j)
	Definir auxCod, col Como Entero
	Definir auxTexto Como Cadena
	
	auxCod <- codigos[i]
	codigos[i] <- codigos[j]
	codigos[j] <- auxCod
	
	Para col <- 1 Hasta 5 Con Paso 1 Hacer
		auxTexto <- productos[i, col]
		productos[i, col] <- productos[j, col]
		productos[j, col] <- auxTexto
	FinPara
FinSubProceso
//BURBUJA
SubProceso OrdenarBurbuja(codigos, productos, cantidad)
	Definir i, j Como Entero
	Para i <- 1 Hasta cantidad - 1 Con Paso 1 Hacer
		Para j <- 1 Hasta cantidad - i Con Paso 1 Hacer
			Si codigos[j] > codigos[j + 1] Entonces
				IntercambiarFilas(codigos, productos, j, j + 1)
			FinSi
		FinPara
	FinPara
	Escribir "Productos ordenados por burbuja."
	MostrarProductos(productos, cantidad)
FinSubProceso
//SELECCION
SubProceso OrdenarSeleccion(codigos, productos, cantidad)
	Definir i, j, minIdx Como Entero
	Para i <- 1 Hasta cantidad - 1 Con Paso 1 Hacer
		minIdx <- i
		Para j <- i + 1 Hasta cantidad Con Paso 1 Hacer
			Si codigos[j] < codigos[minIdx] Entonces
				minIdx <- j
			FinSi
		FinPara
		Si minIdx <> i Entonces
			IntercambiarFilas(codigos, productos, i, minIdx)
		FinSi
	FinPara
	Escribir "Productos ordenados por seleccion."
	MostrarProductos(productos, cantidad)
FinSubProceso

// COMPLEMENTO

SubProceso ConsultarInventario(productos, cantidad)
	Definir i, unidades, agotados, stk Como Entero
	Definir valorTotal, prc Como Real
	unidades <- 0
	agotados <- 0
	valorTotal <- 0
	
	Para i <- 1 Hasta cantidad Con Paso 1 Hacer
		prc <- ConvertirANumero(productos[i, 4])
		stk <- ConvertirANumero(productos[i, 5])
		unidades <- unidades + stk
		valorTotal <- valorTotal + (prc * stk)
		Si stk = 0 Entonces
			agotados <- agotados + 1
		FinSi
	FinPara
	
	Escribir "=== RESUMEN DE INVENTARIO ==="
	Escribir "Tipos de productos: ", cantidad
	Escribir "Unidades disponibles: ", unidades
	Escribir "Productos agotados: ", agotados
	Escribir "Valor del inventario: S/ ", valorTotal
FinSubProceso

SubProceso RegistrarVenta(codigos, productos, cantidad)
	Definir cod, cantVender, pos, stockActual, nuevoStock Como Entero
	Definir precioUnit, total Como Real
	
	Escribir "Codigo del producto:"
	Leer cod
	pos <- BuscarIndicePorCodigo(codigos, cantidad, cod)
	
	Si pos = -1 Entonces
		Escribir "Producto no encontrado."
	Sino
		MostrarProducto(productos, pos)
		Escribir "Cantidad a vender:"
		Leer cantVender
		stockActual <- ConvertirANumero(productos[pos, 5])
		
		Si cantVender > 0 Y cantVender <= stockActual Entonces
			precioUnit <- ConvertirANumero(productos[pos, 4])
			total <- cantVender * precioUnit
			nuevoStock <- stockActual - cantVender
			productos[pos, 5] <- ConvertirATexto(nuevoStock)
			
			Escribir "=== RESUMEN DE VENTA ==="
			Escribir "Producto: ", productos[pos, 2]
			Escribir "Precio unitario: S/ ", precioUnit
			Escribir "Cantidad vendida: ", cantVender
			Escribir "Importe total: S/ ", total
			Escribir "Stock restante: ", nuevoStock
			Escribir "Venta registrada correctamente."
		Sino
			Escribir "Error: Cantidad no válida o stock insuficiente."
		FinSi
	FinSi
FinSubProceso

// MENU DE BOTICA

Algoritmo BoticaVILLACOZ
	Definir capacidad, cantidad, opc Como Entero
	capacidad <- 100
	cantidad <- 0
	
	Dimension codigos[100]
	Dimension productos[100, 5]
	
	Repetir
		Escribir ""
		Escribir "=== BOTICA VILLACOZ ==="
		Escribir "1. Registrar producto"
		Escribir "2. Mostrar productos"
		Escribir "3. Buscar por codigo"
		Escribir "4. Ordenar por burbuja"
		Escribir "5. Modificar producto"
		Escribir "6. Eliminar producto"
		Escribir "7. Consultar inventario"
		Escribir "8. Buscar por nombre"
		Escribir "9. Ordenar por seleccion"
		Escribir "10. Registrar venta"
		Escribir "11. Salir"
		Escribir "Seleccione una opcion:"
		Leer opc
		
		Si opc = 1 Entonces
			RegistrarProducto(codigos, productos, cantidad, capacidad)
		Sino Si opc = 2 Entonces
				MostrarProductos(productos, cantidad)
			Sino Si opc = 3 Entonces
					BuscarPorCodigo(productos, cantidad)
				Sino Si opc = 4 Entonces
						OrdenarBurbuja(codigos, productos, cantidad)
					Sino Si opc = 5 Entonces
							ModificarProducto(codigos, productos, cantidad)
						Sino Si opc = 6 Entonces
								EliminarProducto(codigos, productos, cantidad)
							Sino Si opc = 7 Entonces
									ConsultarInventario(productos, cantidad)
								Sino Si opc = 8 Entonces
										BuscarPorNombre(productos, cantidad)
									Sino Si opc = 9 Entonces
											OrdenarSeleccion(codigos, productos, cantidad)
										Sino Si opc = 10 Entonces
												RegistrarVenta(codigos, productos, cantidad)
											Sino Si opc = 11 Entonces
													Escribir "Saliendo del programa..."
												Sino
													Escribir "Opción inválida."
												FinSi
											FinSi
										FinSi
									FinSi
								FinSi
							FinSi
						FinSi
					FinSi
				FinSi
			FinSi
		FinSi
	Hasta Que opc = 11
FinAlgoritmo