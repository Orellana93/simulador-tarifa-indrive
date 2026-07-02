Algoritmo Facturacion_Validacion	
	//ingresar valores
	Escribir "Ingrese el número de la Factura o Boleta (Formato: YXXX-XXXXXXXX)"
	Leer factura	
	letra_inicial = SubCadena(factura,1,1)
	conforme = ValidarFactura(factura,letra_inicial)	
	MostrarRespuesta(conforme,letra_inicial)
FinAlgoritmo

Funcion esvalida <- ValidarFactura(_factura, _inicial)
	//Formato inicial YXXX-XXXXXXXX
	//VALIDAMOS la primera letra con la cantidad de dígitos a su derecha antes del guíon
	Definir i Como Entero
	esvalida = Verdadero	
	contador = 1
	letra_guion = SubCadena(_factura,5,5) // Obtenemos el guión y lo validamos
	si Longitud(_factura) <= 13 ENTONCES
		si letra_guion = "-" Entonces		
			si LetraValida(_inicial) = Verdadero Entonces
				//Validamos los 3 siguiente dígitos hasta antes del guíon "YXXX"
				Repetir
					contador = contador + 1
					cadenavalida <- Subcadena(_factura, contador, contador)
					
					Si cadenavalida = "" Entonces
						esvalida = falso
					sino
						esvalida = ValidaNumero(cadenavalida)
					FinSi		
				Hasta Que (contador = 4) O (esvalida = Falso)
				Si esvalida = Verdadero Entonces
					contador = 5
					Repetir
						contador = contador + 1
						cadenavalida <- Subcadena(_factura, contador, contador)
						
						Si cadenavalida = "" Entonces
							esvalida = falso
						sino
							esvalida = ValidaNumero(cadenavalida)
						FinSi		
					Hasta Que (contador = 13) O (esvalida = Falso)				
				FinSi
			SiNo
				esvalida = Falso
			FinSi	
		SiNo
			esvalida = Falso
		FinSi	
	Sino
		esvalida = Falso
	FinSi	
FinFuncion

Funcion esLetraValida <- LetraValida(_valor)
	// Validamos que inicie con la letra correcta "B" o "F"
	esLetraValida = Falso
	SI _valor = "B" O _valor = "F" Entonces
		esLetraValida = Verdadero
	FinSi		
FinFuncion

Funcion esNumero <- ValidaNumero(_valor)
	// Validamos que el valor sea número
	Segun _valor Hacer
		"0":
			esNumero = Verdadero
		"1":
			esNumero = Verdadero
		"2":
			esNumero = Verdadero
		"3":
			esNumero = Verdadero
		"4":
			esNumero = Verdadero
		"5":
			esNumero = Verdadero
		"6":
			esNumero = Verdadero
		"7":
			esNumero = Verdadero
		"8":
			esNumero = Verdadero
		"9":
			esNumero = Verdadero
		De Otro Modo:
			esNumero = Falso
	Fin Segun	
FinFuncion

Funcion MostrarRespuesta(conforme,_letra_inicial)
	Escribir "========================================================"		
	Si _letra_inicial = "B" Entonces
		Escribir "============= VALIDACIÓN BOLETA INGRESADA =============="
	SiNo
		Escribir "============= VALIDACIÓN FACTURA INGRESADA ============="
	FinSi	
	Escribir "========================================================"
	si conforme = Verdadero Entonces
		Escribir "Formato ingresado es Correcto"
	SiNo
		Escribir "Formato ingresado es incorrecto; Formato: YXXX-XXXXXXXX"
	FinSi	
	Escribir "========================================================"
FinFuncion