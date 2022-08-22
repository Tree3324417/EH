using UnityEngine;

public struct JavaClassWrapper
{
	public JavaClassWrapper(string encryptedName)
	{
		_instance = new AndroidJavaClass(encryptedName.Decrypt());
	}

	public T GetStatic<T>(string encryptedFieldName)
	{
		return _instance.GetStatic<T>(encryptedFieldName.Decrypt());
	}
	
	public T CallStatic<T>(string encryptedMethodName, params object[] args)
	{
		return _instance.CallStatic<T>(encryptedMethodName.Decrypt(), args);
	}
	
	public JavaObjectWrapper GetStaticObject(string encryptedFieldName)
	{
		return new JavaObjectWrapper(_instance.GetStatic<AndroidJavaObject>(encryptedFieldName.Decrypt()));
	}

	public JavaObjectWrapper CallStaticObject(string encryptedMethodName, params object[] args)
	{
		return new JavaObjectWrapper(_instance.CallStatic<AndroidJavaObject>(encryptedMethodName.Decrypt(), args));
	}	

	private readonly AndroidJavaClass _instance;
}

public struct JavaObjectWrapper
{
	public JavaObjectWrapper(AndroidJavaObject instance)
	{
		_instance = instance;
	}

	public JavaObjectWrapper(string encryptedName, params object[] args)
	{
		_instance = new AndroidJavaObject(encryptedName.Decrypt(), args);
	}

	public T Call<T>(string encryptedMethodName, params object[] args)
	{
		return _instance.Call<T>(encryptedMethodName.Decrypt(), args);
	}

	public string CallForString(string encryptedMethodName, params object[] args)
	{
		return _instance.Call<string>(encryptedMethodName.Decrypt(), args);
	}

	public JavaObjectWrapper CallForObject(string encryptedMethodName, params object[] args)
	{
		return new JavaObjectWrapper(_instance.Call<AndroidJavaObject>(encryptedMethodName.Decrypt(), args));
	}

	public JavaObjectArrayWrapper GetArray(string encryptedFieldName)
	{
		return new JavaObjectArrayWrapper(_instance.Get<AndroidJavaObject[]>(encryptedFieldName.Decrypt()));
	}

	public AndroidJavaObject RawObject { get { return _instance; } }
	
	private readonly AndroidJavaObject _instance;
}

public struct JavaObjectArrayWrapper
{
	public JavaObjectArrayWrapper(AndroidJavaObject[] array)
	{
		_array = array;
	}

	public JavaObjectWrapper this[int index] { get { return new JavaObjectWrapper(_array[index]); } }

	private AndroidJavaObject[] _array;
}
