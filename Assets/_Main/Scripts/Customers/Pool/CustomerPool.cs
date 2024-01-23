using UnityEngine;

public class CustomerPool: MonoBehaviour
{
    [SerializeField] private int poolSise;
    [SerializeField] private bool isAutoExpand;
    [SerializeField] private Customer prefab;

    private ExpansionControlObjectPool<Customer> customers;

    public int PoolSise { get { return poolSise; } }

    private void Start()
    {
        customers = new ExpansionControlObjectPool<Customer>(prefab, isAutoExpand, transform, poolSise);
    }

    public Customer CreateEnemie()
    {
        return customers.GetFreeElement();
    }

    public void Deactivate(Customer customer)
    {
        customer.gameObject.SetActive(false);
    }
}