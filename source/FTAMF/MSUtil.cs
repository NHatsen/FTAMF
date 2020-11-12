using OpenMcdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FTAMF
{
    class MSUtil
    {
		/// <summary>
		/// Uncompress a stream using LW77.
		/// </summary>
		/// <param name="input"></param>
		/// <returns>A memory stream.</returns>
		public static MemoryStream UncompressLW77(Stream input)
		{
			MemoryStream output = new MemoryStream();
			BinaryReader reader = new BinaryReader(input);
			bool escape = false;

			bool processBlock = true;
            try
            {
				while (processBlock)
				{
					long controlBytes = 0;
					int size = reader.ReadUInt16() | (reader.ReadInt16() << 16);
					size += 4;
					controlBytes += 4;
					if ((size + input.Position) > input.Length) processBlock = false;

					long dummyWord = reader.ReadUInt16() | (reader.ReadInt16() << 16);
					controlBytes += 4;

					while (controlBytes < size)
					{
						int flagByte = reader.ReadUInt16();
						controlBytes += 2;
						for (int i = 0; i < 16; i++)
						{
							if (controlBytes >= size) break;
							if ((flagByte & (0x0001 << i)) == 0)
							{
								// Uncompressed block. Copy just one byte.
								byte temp = reader.ReadByte();
								controlBytes += 1;
								output.WriteByte(temp);
							}
							else
							{
								// Compressed block. Read block.
								ushort block = reader.ReadUInt16();
								controlBytes += 2;

								int count = (block & 0x0F) + 1;
								int disp = ((block & 0xFF00) >> 8) | ((block & 0xF0) << 4);

								if (disp > output.Length)
								{
									Console.WriteLine("Out-the-range offset");
									escape = true;
									break;
								}

								long outPos = output.Position;
								long copyPos = output.Position - disp;

								// Copy all bytes.
								for (int j = 0; j < count; j++)
								{
									output.Position = copyPos++;
									byte b = (byte)output.ReadByte();
									output.Position = outPos++;
									output.WriteByte(b);
								}
							}
							if (escape) break;
						}
						if (escape) break;
					}
					if (escape) break;
				}

			}
			catch (Exception exc)
            {
				output = new MemoryStream();
				MessageBox.Show($"Read Error ({exc.Message})", "Atention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			
			output.Position = 0;
			return output;
		}

		/// <summary>
		/// Remove starting segment from stream.
		/// </summary>
		/// <param name="input"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static MemoryStream RemoveTrailingSegment(Stream input, int length)
		{
			MemoryStream ms = new MemoryStream();
			BinaryReader reader = new BinaryReader(input);
			if (length > 0 & length < input.Length)
			{
				reader.ReadBytes(length);
                byte[] array = new byte[input.Length - 8L];
				input.Read(array, 0, array.Length);
				ms.Write(array, 0, array.Length);
				ms.Position = 0L;
			}
			return ms;
		}

		/// <summary>
		/// Convert Compound File stream into memory stream.
		/// </summary>
		/// <param name="st"></param>
		/// <returns></returns>
		public static MemoryStream CFtoMStream(CFStream st)
		{
			byte[] buffer = new byte[st.Size];
			st.Read(buffer, 0L, (int)st.Size);
			return new MemoryStream(buffer);
		}

		/// <summary>
		/// Returns true if the stream is compressed wit LW77.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static bool IsCompressedWithLW77(CFStream stream)
		{
			byte[] array = new byte[5];
			if (stream.Size > 5L)
			{
				stream.Read(array, 0L, 5);
				return array[4] != 1;
			}
			return false;
		}

		/// <summary>
		/// True if the memory stream is a Compound File stream.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public static bool IsCompoundFile(MemoryStream stream)
		{
			byte[] array = new byte[20];
			stream.Read(array, 0, 20);
			return array[10] == 208 & array[11] == 207;
		}

		/// <summary>
		/// Indicates if a Compound File stream is an image.
		/// </summary>
		/// <param name="ms"></param>
		/// <returns>0: Unknown - 1: BMP - 2: JPEG</returns>
		public static int VerifyIfImage(CFStream ms)
		{
			byte[] buffer = new byte[20];
			ms.Read(buffer, 0L, 20);
			if (buffer[10] == 0xFF & buffer[11] == 0xD8 & buffer[12] == 0xFF & buffer[13] == 0xE0)
			{
				// It's BMP
				return 1;
			}
			else if (buffer[8] == 0xFF & buffer[9] == 0xD8 & buffer[10] == 0xFF & buffer[11] == 0xE0)
			{
				// It's JPEG
				return 2;
			}
			else if ((buffer[10] == 0x42) & (buffer[11] == 0x4D))
			{
				// It's BMP
				return 1;
			}
			return 0;
		}

	}
}
