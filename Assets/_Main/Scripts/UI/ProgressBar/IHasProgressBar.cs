using System;

public interface IHasProgressBar
{
	public event Action<float> OnProgressChanged;
}
