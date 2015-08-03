
stor repl(" ",16) to entrada
stor 0 to peso_E
stor 0 to codigo_E
stor repl(" ",16) to refe_fim
stor repl(" ",16) to peso_fim
stor .F. to barraslido
	* Abre o banco de dados
	use
	if file("mapindex.idx")
	   erase mapindex.idx
	endif
	use mapeia 
	index on CODI to mapindex
	use mapeia index mapindex


do while .T.
	clear	
	@ 13,5 say "Entre com a referencia ou cod barras" get entrada pict "999,999,99,999-9"
	read

	go top
	* Sao Seis Digitos ?
	if subs(entrada,9,1) = " "
		*1. S�o seis digitos
		peso_E = subs(entrada,1,3)
		codigo_E = subs(entrada,5,3)
		
		if peso_E = "000"
			* 1.1 come�a com 000 al�m de ter 6 digitos
			? "caso 1.1"
	
			* Fazer procura continuamente ate que ache um peso = zero.
			locate rest for codi=val(codigo_E) while peso=0
			do while .NOT. eof()
				if found() 
					exit do
				endif
				cont
			enddo
			if .NOT. found()
				? "nao encontrei..."
				exit do
			endif
		
			* O Registro ja foi encontrado.
			refe_fim = refe
			barraslido = .T.
			exit do
		else if peso_e <> "000"
			? "caso 1.2"
			* 1.2 n�o come�a com 000 al�m de ter 6 digitos

			peso_fim = val(peso_e) / 10

			* faz uma busca ate que ache o registro certo, com o peso igual da etiqueta
			locate rest for codi=val(codigo_E) while peso=peso_fim
			do while .NOT. eof()
				if found() 
					exit do
				endif
				continue
			enddo
			if .NOT. found()
				? "nao encontrei..."
				exit do
			endif

			* O Registro ja foi encontrado.

			refe_fim = refe
	
			barraslido = .T.
			exit do
		endif
	endif
	if subs(entrada,12,1) = " "
		* 2. Tem oito digitos.
		if subs(entrada,1,3) = "000"
		? "caso 2.1"
			* 2.1 come�a com 000 alem de ter 8 digitos
			codigo_E = val(subs(entrada,5,3) + subs(entrada,9,2)) + 1000
		
			* Fazer procura continuamente ate que ache um peso = zero.
			locate rest for codi=codigo_E while peso=0
			do while .NOT. eof()
				if found() 
					exit do
				endif
				continue
			enddo
			if .NOT. found()
				? "nao encontrei..."
				exit do
			endif
		
			* O Registro ja foi encontrado.
			refe_fim = refe
			barraslido = .T.
			exit do
		endif
		if subs(entrada,1,1) <> "9"
		? "caso 2.2"				
			* 2.2 primeiro digito n�o � 9, alem de ter 8 digitos
			peso_E = subs(entrada,1,3)
			codigo_E = val(subs(entrada,5,3) + subs(entrada,9,2)) + 1000
			peso_fim = val(peso_e) / 10

			* faz uma busca ate que ache o registro certo, com o peso igual da etiqueta
			locate rest for codi=codigo_E while peso=peso_fim
			do while .NOT. eof()
				if found() 
					exit do
				endif
				continue
			enddo
			if .NOT. found()
				? "nao encontrei..."
				exit do
			endif

	
			* O Registro ja foi encontrado.
			refe_fim = refe
			barraslido = .T.
			exit do
				
		else if subs(entrada,1,1) = "9"
			* 2.3 primeiro � 9, alem de ter 8 digitos
			? "caso 2.3"
			peso_E = val(subs(entrada,2,2) + subs(entrada,5,2)) 
			codigo_E = val(subs(entrada,7,1) + subs(entrada,9,2)) 
			peso_fim = peso_e / 10 + 90

			* faz uma busca ate que ache o registro certo, com o peso igual da etiqueta
			locate rest for codi=codigo_E while peso=peso_fim
			do while .NOT. eof()
				if found() 
					exit do
				endif
				continue
			enddo
			if .NOT. found()
				? "nao encontrei..."
				exit do
			endif

			* O Registro ja foi encontrado.

			refe_fim = refe
			barraslido = .T.
			exit do
		endif
	endif

exit do
enddo
*mostra os resultados

if barraslido
	? "Codigo de barras foi lido"
	? "O Peso correto (se necessario):" 
	? peso_fim
	? "A refe correta eh:"
	? refe_fim
else
	? "Voce encontrou com uma referencia convencional... o programa deve continuar do modo antigo"

endif