//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34014
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------
using System;

public class Cached<T, TArgs>
{
	public Cached(Func<TArgs, T> initializer)
	{
		_initializer = initializer;
	}

	public T GetValue(TArgs args)
	{
		if (!_initialized || !args.Equals(_lastArgs))
		{
			_value = _initializer(args);
			_lastArgs = args;
			_initialized = true;
		}

		return _value;
	}

	public void Reset()
	{
		_value = default(T);
		_initialized = false;
	}

	private T _value;
	private bool _initialized;
	private TArgs _lastArgs;
	private readonly Func<TArgs, T> _initializer;
	private readonly Func<bool> _deprecated;
}
