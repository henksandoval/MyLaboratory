namespace NetCoreExamples.NewFeatures.CS_6
{
    using System;

    public class NullConditionalOperator : IRunnable
    {
        public void Run()
        {
            Customer example1 = new Customer()
            {
                Name = "Pedro",
            };

            Customer example2 = new Customer()
            {
                Name = "Juan",
                Address = new Address()
                {
                    Street = "Las Delicias"
                }
            };

            LogCustomer(example1);

            LogCustomer(example2);
        }

        public void LogCustomer(Customer customer)
        {
            string message = string.Empty;

            if (customer == null || customer.Address == null)
                message += "NoStreet";
            else
                message += customer.Address.Street;

            string customerName = customer?.Name;
            string street = customer?.Address?.Street ?? "NoStreet";

            Console.WriteLine($"Name: {customerName} - Street: {message}");
        }
    }

    public class Customer
    {
        public string Name { get; set; }

        public Address Address { get; set; }
    }

    public enum ClientType
    {
        Standard,
        Employee,
        VIP
    }

    public class Address
    {
        public string Street { get; set; }
        public int? PostalCode { get; set; }
    }
}
