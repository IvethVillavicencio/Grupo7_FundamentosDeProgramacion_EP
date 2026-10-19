Algoritmo Botica_VILLACOZ
	Definir op, c1, c2, s1, s2, cod, cant Como Entero
	Definir n1, n2, nom Como Cadena
	Definir p1, p2, precio, total, aux Como Real
	c1 <- 0
	c2 <- 0
	s1 <- 0
	s2 <- 0
	Repetir
		Escribir '=== BOTICA VILLACOZ ==='
		Escribir '1. Registrar producto'
		Escribir '2. Mostrar productos'
		Escribir '3. Buscar por codigo'
		Escribir '4. Ordenar por burbuja'
		Escribir '5. Modificar producto'
		Escribir '6. Eliminar producto'
		Escribir '7. Consultar inventario'
		Escribir '8. Buscar por nombre'
		Escribir '9. Ordenar por seleccion'
		Escribir '10. Registrar venta'
		Escribir '11. Salir'
		Leer op
		Según op Hacer
			1:
				Escribir 'Codigo, nombre, precio y stock:'
				Leer cod, nom, precio, cant
				Si c1=0 Entonces
					c1 <- cod
					n1 <- nom
					p1 <- precio
					s1 <- cant
				SiNo
					Si c2=0 Entonces
						c2 <- cod
						n2 <- nom
						p2 <- precio
						s2 <- cant
					SiNo
						Escribir 'Inventario lleno'
					FinSi
				FinSi
			2:
				Si c1<>0 Entonces
					Escribir c1, n1, p1, s1
				FinSi
				Si c2<>0 Entonces
					Escribir c2, n2, p2, s2
				FinSi
			3:
				Escribir 'Codigo a buscar:'
				Leer cod
				Si cod=c1 Entonces
					Escribir n1, p1, s1
				SiNo
					Si cod=c2 Entonces
						Escribir n2, p2, s2
					SiNo
						Escribir 'No encontrado'
					FinSi
				FinSi
			4:
				Si n1>n2 Y c2<>0 Entonces
					aux <- c1
					c1 <- c2
					c2 <- aux
					nom <- n1
					n1 <- n2
					n2 <- nom
					aux <- p1
					p1 <- p2
					p2 <- aux
					aux <- s1
					s1 <- s2
					s2 <- aux
				FinSi
				Escribir 'Ordenado por burbuja'
			5:
				Escribir 'Codigo a modificar:'
				Leer cod
				Si cod=c1 Entonces
					Escribir 'Nuevo nombre, precio y stock:'
					Leer n1, p1, s1
				SiNo
					Si cod=c2 Entonces
						Leer n2, p2, s2
					SiNo
						Escribir 'No encontrado'
					FinSi
				FinSi
			6:
				Escribir 'Codigo a eliminar:'
				Leer cod
				Si cod=c1 Entonces
					c1 <- c2
					n1 <- n2
					p1 <- p2
					s1 <- s2
					c2 <- 0
					Escribir 'Eliminado'
				SiNo
					Si cod=c2 Entonces
						c2 <- 0
						Escribir 'Eliminado'
					SiNo
						Escribir 'No encontrado'
					FinSi
				FinSi
			7:
				Escribir 'Stock producto 1:', s1
				Escribir 'Stock producto 2:', s2
			8:
				Escribir 'Nombre a buscar:'
				Leer nom
				Si nom=n1 O nom=n2 Entonces
					Escribir 'Producto encontrado'
				SiNo
					Escribir 'No encontrado'
				FinSi
			9:
				Si p1>p2 Y c2<>0 Entonces
					aux <- c1
					c1 <- c2
					c2 <- aux
					nom <- n1
					n1 <- n2
					n2 <- nom
					aux <- p1
					p1 <- p2
					p2 <- aux
					aux <- s1
					s1 <- s2
					s2 <- aux
				FinSi
				Escribir 'Ordenado por precio'
			10:
				Escribir 'Codigo y cantidad a vender:'
				Leer cod, cant
				Si cod=c1 Y cant>0 Y cant<=s1 Entonces
					total <- p1*cant
					s1 <- s1-cant
					Escribir 'Total: S/', total
				SiNo
					Si cod=c2 Y cant>0 Y cant<=s2 Entonces
						total <- p2*cant
						s2 <- s2-cant
						Escribir 'Total: S/', total
					SiNo
						Escribir 'Producto o cantidad no validos'
					FinSi
				FinSi
			11:
				Escribir 'Saliendo...'
			De Otro Modo:
				Escribir 'Opcion no valida'
		FinSegún
	Hasta Que op=11
FinAlgoritmo
