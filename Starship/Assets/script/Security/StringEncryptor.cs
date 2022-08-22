using System;

public static class StringExtensions
{
	static StringExtensions()
	{
		_table = new char[95];
		for (var i = 0; i < _table.Length; ++i)
		{
			_table[i] = (char)(i+0x20);
		}

		uint w = 0x12345678;
		uint z = 0x87654321;
		for (int i = 0; i < 1000; ++i)
		{
			var i1 = random(ref w, ref z) % _table.Length;
			var i2 = random(ref w, ref z) % _table.Length;
			
			var temp = _table[i1];
			_table[i1] = _table[i2];
			_table[i2] = temp;
		}
	}

	public static string Encrypt(this string data)
	{
		var result = new System.Text.StringBuilder(data.Length);

		for (int i = 0; i < data.Length; ++i)
		{
			int index = Array.IndexOf(_table, data[i]);
			if (index < 0)
				throw new System.ArgumentException();
			result.Append((char)(index + 0x20));
		}
		
		return result.ToString();
	}

	public static string Decrypt(this string data)
	{
		var result = new System.Text.StringBuilder(data.Length);
		
		for (int i = 0; i < data.Length; ++i)
			result.Append(_table[(int)data[i] - 0x20]);
		
		return result.ToString();
	}

	private static uint random(ref uint w, ref uint z)
	{
		z = 36969 * (z & 65535) + (z >> 16);
		w = 18000 * (w & 65535) + (w >> 16);
		return (z << 16) + w;  /* 32-bit result */
	}

	private static char[] _table;
}
