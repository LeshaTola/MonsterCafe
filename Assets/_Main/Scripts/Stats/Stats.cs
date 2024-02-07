using UnityEngine;

public class Stats : MonoBehaviour
{
	public BasicValue Money { get; private set; }
	public BasicValue Rating { get; private set; }

	private void Awake()
	{
		Money = new BasicValue();
		Rating = new BasicValue();
	}

}
