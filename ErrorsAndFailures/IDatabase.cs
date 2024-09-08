namespace ErrorsAndFailures
{
    public interface IDatabase
    {
        Customer? GetById(int id);
        Result Save(Customer customer);
    }
}
