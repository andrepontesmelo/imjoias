using System;
using System.Threading;

namespace TransformadorBancoDeDados
{
	/// <summary>
	/// Summary description for TestePerformace.
	/// </summary>
	public class TestePerformace
	{
		public static bool modoTeste = false;
		
		//Teste de 1 s�culo: nova tabela a cada 1 mes: ou seja, 1200 records de pre�o por componente_de_custo
		public const int threads = 400;
		
		public const int valoresPorComponenteDeCusto= 12000; //1200  //valoresPorComponenteDeCusto
		public const int componenteDeCusto = 2000;
		public const int mercadorias = 100000;  //30
		public const int cadaNovaMercadoriaTemQuantosComponentesDeCusto = 50;  //30
		bool deuPau,deuPau1;
		public static MySql novo;


		public TestePerformace(MySql meuNovo) 
		{
			novo = meuNovo;
		}
		
		public  static string CaractereAleat�rio(int quantos) 
		{
			Thread.Sleep( 10 );
			Random aleat�rio = new Random();
			string final="";
			for ( short x=0; x < quantos ; x ++ ) 
			{
				char b = (char) (97+(aleat�rio.NextDouble()*148));
				final+= b.ToString();
			}
			return final;
			
		}
		public  static double DoubleAleat�rio(double at�) 
		{
			Thread.Sleep( 2 );
			Random aleat�rio = new Random();
			//Random a = new Random();
			return  (aleat�rio.NextDouble() * at�);
			
		}

		public static DateTime DataRandomica() 
		{
			
			return DateTime.Parse(IntAleat�rio(1,28).ToString() + "/" + IntAleat�rio(1,12).ToString() + "/" + IntAleat�rio(2004,2100).ToString() + " " + IntAleat�rio(1,23).ToString() + ":" + IntAleat�rio(1,59).ToString() + ":" + IntAleat�rio(1,59).ToString() );

		}
		public  static int IntAleat�rio(int minimo,double at�) 
		{
			return  (int) (DoubleAleat�rio(at�)+minimo);
			
		}
		public void GerarMercadorias() 
		{
			String novaReferencia;
			String componenteDeCusto;


				for ( int x = 0 ; x < (2.0*TestePerformace.mercadorias/threads)  ; x ++ ) 
				{
					do 
					{
						deuPau1 = false;
						try 
						{
							novaReferencia = TestePerformace.CaractereAleat�rio(40);
							novo.InserirMercadoria(TestePerformace.CaractereAleat�rio(100),TestePerformace.DoubleAleat�rio(100).ToString(),TestePerformace.DoubleAleat�rio(30).ToString(),"a",TestePerformace.IntAleat�rio(0,9).ToString(),novaReferencia,"1","0");		
							componenteDeCusto = "";

							for ( int y = 0 ; y < TestePerformace.cadaNovaMercadoriaTemQuantosComponentesDeCusto ; y++ ) 
							{
								do 
								{
									deuPau = false;
									try  
									{
									
									
										componenteDeCusto =  novo.ComandoString("SELECT codigo FROM `componentecusto ` order by RAND() LIMIT 1");
										novo.InserirVinculoMercadoriaComponenteCusto(novaReferencia,componenteDeCusto,TestePerformace.DoubleAleat�rio(1000).ToString());
									}
									catch (Exception e) 
									{
										deuPau = true;
									}
							 
								}	 while (deuPau == true);
							}

						}
						catch(Exception ) 
						{
							deuPau1 = true;

						}
					} while (deuPau1 == true);
				}
			
				

		}

		public void GerarComponenteCustoValor() 
		{
			string componenteNovoId ="";
			for ( int y = 0 ; y < (2.0*componenteDeCusto/threads)  ; y++ ) 
			{

				do 
				{
					deuPau = false;
					try  
					{
				
						componenteNovoId = CaractereAleat�rio(2);
						novo.InserirComponenteDeCusto(componenteNovoId,CaractereAleat�rio(50));
					}
					catch(Exception e)  
					{
						deuPau = true;
					}
				} while (deuPau == true );
					 
				for ( int x = 0 ; x < TestePerformace.valoresPorComponenteDeCusto ; x++ ) 
				{

					do 
					{
						deuPau = false;
						try 
						{
							novo.InserirValorComponenteDeCusto(componenteNovoId,TestePerformace.DataRandomica(), TestePerformace.DoubleAleat�rio (100000) ,"10");
						} 
						catch(Exception e) 
						{
							deuPau = true;
								
						}
					} while (deuPau == true);
				}


			}
		}

	}
}
