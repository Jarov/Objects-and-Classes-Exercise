namespace _07.AndreyAndBilliard
{
    using System.Collections.Generic;

    class Customer
    {
        public string Name;
        public Dictionary<string, int> Order = new Dictionary<string, int>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddOrder(string product, int count)
        {
            if (!Order.ContainsKey(product))
                Order[product] = 0;

            Order[product] += count;
        }
    }
}
