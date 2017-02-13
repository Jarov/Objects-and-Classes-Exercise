namespace _07.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AndreyAndBilliard
    {
        static void Main()
        {
            Dictionary<string, decimal> PriceList = new Dictionary<string, decimal>();
            addProduct(PriceList);

            List<Customer> Clients = new List<Customer>();

            for (int i = 0; ; i++)
            {
                string[] inPut = Console.ReadLine().Split('-', ',');

                if (inPut[0] == "end of clients") break;

                if (PriceList.ContainsKey(inPut[1]))
                {
                    if (!Clients.Exists(x => x.Name == inPut[0]))
                        Clients.Add(new Customer(inPut[0]));

                    Clients.Find(x => x.Name == inPut[0]).AddOrder(inPut[1], int.Parse(inPut[2]));
                }
            }

            IOrderedEnumerable<Customer> SortedClients = Clients.OrderBy(x => x.Name);

            decimal totalBill = 0;

            foreach (Customer client in SortedClients)
            {
                Console.WriteLine(client.Name);
                decimal bill = 0;

                foreach (KeyValuePair<string, int> productInfo in client.Order)
                {
                    Console.WriteLine($"-- {productInfo.Key} - {productInfo.Value}");

                    bill += productInfo.Value * PriceList[productInfo.Key];
                }

                Console.WriteLine($"Bill: {bill.ToString("0.00")}");
                totalBill += bill;
            }

            Console.WriteLine($"Total bill: {totalBill.ToString("0.00")}");
        }

        static void addProduct(Dictionary<string, decimal> PriceList)
        {
            int ProductsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < ProductsCount; i++)
            {
                string[] inPut = Console.ReadLine().Split('-');

                PriceList[inPut[0]] = decimal.Parse(inPut[1]);
            }
        }
    }
}
