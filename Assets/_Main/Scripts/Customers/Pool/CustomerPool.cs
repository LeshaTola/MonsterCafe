using UnityEngine;

public class CustomerPool: MonoBehaviour
{
    [SerializeField] private int _poolSise;
    [SerializeField] private bool _isAutoExpand;
    [SerializeField] private Customer _prefab;
    private ObjectPool<Customer> _enemies;

    public int PoolSise { get { return _poolSise; } }

    private void Start()
    {
        _enemies = new ObjectPool<Customer>(_prefab, _isAutoExpand, transform, _poolSise);
    }

    public Customer CreateEnemie()
    {
        return _enemies.GetFreeElement();
    }

    public void Deactivate(Customer customer)
    {
        customer.gameObject.SetActive(false);
    }
}