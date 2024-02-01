using UnityEngine;

public class SaltShaker : MonoBehaviour
{
	[SerializeField] private ParticleSystem saltParticle;
	[SerializeField] private Transform spawnPoint;

	[SerializeField] private float yDifference;
	[SerializeField] private float cooldown;
	[SerializeField, Range(0, 1)] private float saltPower;
	[SerializeField] private LayerMask layerMask;

	private float prevYPosition;
	private float cooldownTimer;
	private bool strongSwing = false;
	private ObjectPool<ParticleSystem> saltPool;

	private void Awake()
	{
		SetupSaltPool();
	}

	private void Update()
	{
		if (!strongSwing)
		{
			strongSwing = IsStrongSwing();
		}

		cooldownTimer -= Time.deltaTime;
		if (cooldownTimer <= 0)
		{
			Salting();
		}
		prevYPosition = transform.position.y;
	}

	private void Salting()
	{
		if (strongSwing && IsSwingEnded())
		{
			//saltTriggerAnimation.StartAnimation();

			var particle = saltPool.Get();
			Timer particleLifeTime = new Timer(particle.main.startLifetime.constantMax, endAction: () =>
			{
				saltPool.Release(particle);
			});
			StartCoroutine(particleLifeTime.Start());

			cooldownTimer = cooldown;
			strongSwing = false;
		}
	}

	private void SetupSaltPool()
	{
		saltPool = new ObjectPool<ParticleSystem>(() =>
		{
			return Instantiate(saltParticle);
		},

		(saltParticle) =>
		{
			saltParticle.gameObject.SetActive(true);
			saltParticle.Play();
			saltParticle.transform.position = spawnPoint.position;
			saltParticle.transform.rotation = spawnPoint.rotation;
		},

		(saltParticle) =>
		{
			saltParticle.gameObject.SetActive(false);
		},

		5
		);
	}

	private bool IsStrongSwing()
	{
		return transform.position.y - prevYPosition < yDifference;
	}

	private bool IsSwingEnded()
	{
		return transform.position.y - prevYPosition >= 0;
	}

	private void OnSaltParticleCollide(ISaltable saltable)
	{
		saltable.Salting(saltPower);
	}
}