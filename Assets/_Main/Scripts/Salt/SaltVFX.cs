using UnityEngine;

public class SaltVFX : MonoBehaviour
{
	[SerializeField] private GameObject saltableGameObject;

	[Header("VFX")]
	[SerializeField] private ParticleSystem saltParticle;
	[SerializeField] private ParticleSystem saltingEndParticle;

	private ISaltable saltable;

	private void Awake()
	{
		if (!saltableGameObject.TryGetComponent(out saltable))
		{
			Debug.LogError($"On {saltableGameObject.name} no ISaltable component");
			return;
		}
	}

	private void Start()
	{
		saltable.Salt.OnValueChanged += OnSaltValueChanged;
		saltable.Salt.OnSaltingEnded += OnSaltingEnded;
	}

	private void OnDestroy()
	{
		saltable.Salt.OnValueChanged -= OnSaltValueChanged;
		saltable.Salt.OnSaltingEnded -= OnSaltingEnded;
	}

	private void OnSaltingEnded()
	{
		saltingEndParticle.Play();
	}

	private void OnSaltValueChanged(float obj)
	{
		saltParticle.Play();
	}
}
