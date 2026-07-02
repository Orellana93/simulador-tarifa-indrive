Algoritmo CalculeSLA
	Escribir "Ingrese la fecha y hora de creación del ticket: (AAAAMMDD-HHMMSS)"
	Leer fechaCreacion
	Escribir "Ingrese la fecha y hora de Resolución del ticket: (AAAAMMDD-HHMMSS)"
	Leer fechaResolución
	
	Definir fechacrea, horacrea, fechaReso, horaReso Como Caracter
	Definir cantidadhoras, cantidaddias Como Entero
	Definir cumplio Como Logico
	
	cumplio = Verdadero
	si fechaCreacion <> "" Entonces
		fechacrea <- ObtieneFecha(fechaCreacion)		
		horacrea <- ObtieneHora(fechaCreacion)
	FinSi
	
	si fechaResolución <> "" Entonces
		fechaReso <- ObtieneFecha(fechaResolución)		
		horaReso <- ObtieneHora(fechaResolución)
	FinSi
	
	si fechacrea = fechaReso Entonces
		cantidadhoras = ConvertirANumero(horaReso) - ConvertirANumero(horacrea)
	SiNo
		si fechacrea > fechaReso Entonces
			Escribir "Error: Debe ingresar la fecha de resolución mayor a la de creación"
			cumplio = Falso
		SiNo
			cantidaddias = 	ConvertirANumero(fechaReso) - ConvertirANumero(fechacrea)
			cantidadhoras = (ConvertirANumero(horaReso) - ConvertirANumero(horacrea)) + (cantidaddias * 8)			
		FinSi
	FinSi
	si cumplio = Verdadero
		si cantidadhoras > 8 Entonces
			cumplio = falso
		sino 
			cumplio = Verdadero
		FinSi
		MostrarSLAFinal(cumplio,cantidadhoras)		
	finsi
FinAlgoritmo

Funcion MostrarSLAFinal(_cumplio, _cantidadhoras)
	Escribir "========================================================" 
	si _cumplio = Verdadero Entonces
		Escribir " SLA Cumplido (Hora laboradas: " _cantidadhoras
	SiNo
		Escribir " SLA No Cumplido (Horas Exceso: " _cantidadhoras - 8
	FinSi
	Escribir "========================================================"
FinFuncion

Funcion fechanueva <- ObtieneFecha(_fecha)
	fechanueva = SubCadena(_fecha,1,8)	
FinFuncion

Funcion horanueva <- ObtieneHora(_fecha)
	horanueva = SubCadena(_fecha,10,2)
FinFuncion
