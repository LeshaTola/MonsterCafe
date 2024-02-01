public interface ISaltable
{
	public Salt Salt { get; set; }

	public void Salting(float value)
	{
		Salt.Salting(value);
	}
}