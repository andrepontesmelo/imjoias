using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Acesso.Comum
{
	/// <summary>
	/// Representa��o de uma imagem no banco de dados.
	/// </summary>
	[Serializable]
	public class DbFoto : IDisposable
	{
		private byte [] imagem;

		/// <summary>
		/// Constr�i uma imagem vazia.
		/// </summary>
		public DbFoto()
		{
			this.imagem = null;
		}

		/// <summary>
		/// Constr�i uma imagem a partir de um vetor de bytes.
		/// </summary>
		/// <param name="imagem">Vetor de bytes.</param>
		public DbFoto(byte [] imagem)
		{
			this.imagem = imagem;
		}

		/// <summary>
		/// Constr�i uma imagem a partir de um vetor de bytes.
		/// </summary>
		/// <param name="imagem">Vetor de bytes.</param>
		public DbFoto(object imagem)
		{
			if (imagem != null && imagem != DBNull.Value)
				this.imagem = (byte []) imagem;
			else
				this.imagem = null;
		}

		/// <summary>
		/// Constr�i um DbFoto a partir de uma imagem.
		/// </summary>
		/// <param name="imagem">Imagem original.</param>
		public DbFoto(Image imagem)
		{
            if (imagem != null)
            {
                MemoryStream stream = new MemoryStream();

                try
                {
                    try
                    {
                        imagem.Save(stream, ImageFormat.Png);
                    }
                    catch
                    {
                        try
                        {
                            imagem = new Bitmap(imagem);
                            imagem.Save(stream, ImageFormat.Png);
                        }
                        catch
                        {
                            imagem.Save(stream, imagem.RawFormat);
                        }
                    }
                    this.imagem = stream.ToArray();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao tentar formar uma imagem com o Image dado. Observe se no banco de dados n�o existe alguma figura inv�lida.", e);
                }
                finally
                {
                    stream.Close();
                }
            }
            else
                this.imagem = null;
		}

//		/// <summary>
//		/// Constroi uma imagem a partir de um bitmap
//		/// </summary>
//		/// <param name="bitmap"></param>
//		public DbFoto(Bitmap bitmap)
//		{
//
//			MemoryStream stream = new MemoryStream();
//
//			try
//			{
//				bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
//			}
//			catch (Exception e)
//			{
//				throw new Exception("N�o foi poss�vel criar DbFoto apartir de bitmap!\n\n" + e.ToString());
//			}
//
//			this.imagem = stream.ToArray();
//		}

		/// <summary>
		/// Converte um vetor de bytes para uma imagem
		/// </summary>
		/// <returns>Imagem</returns>
		public static implicit operator Image(DbFoto foto)
		{
			if (foto != null && foto.imagem != null)
			{
				Image		 imagem;
				MemoryStream memStream;

				memStream = new MemoryStream(foto.imagem);

				try
				{
					imagem = new Bitmap(Image.FromStream(memStream));
				} 
				catch
				{
					imagem = null;
				}
				finally
				{
					memStream.Close();
				}

				return imagem;
			}
			else
				return null;
		}

		/// <summary>
		/// Retorna a representa��o do vetor de bytes da imagem.
		/// </summary>
		/// <returns>Vetor de bytes.</returns>
		public static implicit operator byte [] (DbFoto foto)
		{
			return foto != null ? foto.imagem : null;
		}

		/// <summary>
		/// Constr�i um DbFoto a partir de um vetor de bytes.
		/// </summary>
		/// <param name="vetor">Vetor de bytes.</param>
		/// <returns>DbFoto</returns>
		public static implicit operator DbFoto(byte [] vetor)
		{
			return new DbFoto(vetor);
		}

		/// <summary>
		/// Constr�i um DbFoto a partir de uma imagem.
		/// </summary>
		/// <param name="foto">Imagem.</param>
		/// <returns>DbFoto</returns>
		public static implicit operator DbFoto(Image foto)
		{
			return new DbFoto(foto);
		}

		/// <summary>
		/// Imagem.
		/// </summary>
		public Image Imagem
		{
			get { return this; }
		}

		/// <summary>
		/// Representa��o da imagem em vetor de bytes.
		/// </summary>
		public byte [] Vetor
		{
			get { return this; }
		}

		#region IDisposable Members

		public void Dispose()
		{
			imagem = null;
		}

		#endregion
	}
}
