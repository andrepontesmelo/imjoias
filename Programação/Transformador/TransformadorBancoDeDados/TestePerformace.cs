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
		
		//Teste de 1 século: nova tabela a cada 1 mes: ou seja, 1200 records de preço por componente_de_custo
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
		
		public  static string CaractereAleatório(int quantos) 
		{
			Thread.Sleep( 10 );
			Random aleatório = new Random();
			string final="";
			for ( short x=0; x < quantos ; x ++ ) 
			{
				char b = (char) (97+(aleatório.NextDouble()*148));
				final+= b.ToString();
			}
			return final;
			
		}
		public  static double DoubleAleatório(double até) 
		{
			Thread.Sleep( 2 );
			Random aleatório = new Random();
			//Random a = new Random();
			return  (aleatório.NextDouble() * até);
			
		}

		public static DateTime DataRandomica() 
		{
			
			return DateTime.Parse(IntAleatório(1,28).ToString() + "/" + IntAleatório(1,12).ToString() + "/" + IntAleatório(2004,2100).ToString() + " " + IntAleatório(1,23).ToString() + ":" + IntAleatório(1,59).ToString() + ":" + IntAleatório(1,59).ToString() );

		}
		public  static int IntAleatório(int minimo,double até) 
		{
			return  (int) (DoubleAleatório(até)+minimo);
			
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
							novaReferencia = TestePerformace.CaractereAleatório(40);
							novo.InserirMercadoria(TestePerformace.CaractereAleatório(100),TestePerformace.DoubleAleatório(100).ToString(),TestePerformace.DoubleAleatório(30).ToString(),"a",TestePerformace.IntAleatório(0,9).ToString(),novaReferencia,"1","0");		
							componenteDeCusto = "";

							for ( int y = 0 ; y < TestePerformace.cadaNovaMercadoriaTemQuantosComponentesDeCusto ; y++ ) 
							{
								do 
								{
									deuPau = false;
									try  
									{
									
									
										componenteDeCusto =  novo.ComandoString("SELECT codigo FROM `componentecusto ` order by RAND() LIMIT 1");
										novo.InserirVinculoMercadoriaComponenteCusto(novaReferencia,componenteDeCusto,TestePerformace.DoubleAleatório(1000).ToString());
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
				
						componenteNovoId = CaractereAleatório(2);
						novo.InserirComponenteDeCusto(componenteNovoId,CaractereAleatório(50));
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
							novo.InserirValorComponenteDeCusto(componenteNovoId,TestePerformace.DataRandomica(), TestePerformace.DoubleAleatório (100000) ,"10");
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
