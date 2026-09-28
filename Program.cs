using System;

namespace Session_12
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.1 Find all products that are out of stock
            var products = ListGenerator.ProductsList
                .Where(p => p.UnitsInStock == 0);
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region 1.2 Find all products that are in stock and cost more than 3.00 per unit
            var products2 = ListGenerator.ProductsList
                .Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);
            foreach (var product in products2)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region 1.3 Returns digits whose name is shorter than their value
            string[] Arr =
            {
    "zero", "one", "two", "three", "four",
    "five", "six", "seven", "eight", "nine"
};
            var result3 = Arr.Where((word, index) => word.Length < index);
            foreach (var word in result3)
            {
                Console.WriteLine(word);
            }
            #endregion
            //-----------------------------------------------------------------------------
            #region 2.1 Get first Product out of Stock
            var result1 = ListGenerator.ProductsList
                .First(p => p.UnitsInStock == 0);
            Console.WriteLine(result1);
            #endregion
            #region 2.2 Return the first product whose price is greater than 1000, or null if no such product exists
            var result2 = ListGenerator.ProductsList
                .FirstOrDefault(p => p.UnitPrice > 1000);
            Console.WriteLine(result2);
            #endregion
            #region 2.3 Retrieve the second number greater than 5
            int[] numbers = { 1, 3, 5, 7, 9, 11, 13 };
            var result = numbers
                .Where(n => n > 5)
                .Skip(1)
                .First();
            Console.WriteLine(result);
            #endregion
            //-----------------------------------------------------------------------------
            #region 3.1 Count the odd numbers in the array
            int[] numbers2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result4 = numbers2.Count(n => n % 2 != 0);
            Console.WriteLine(result4);
            #endregion
            #region 3.2 Get customers and number of orders
            var result5 = ListGenerator.CustomersList
                .Select(c => new
                {
                    CustomerName = c.CustomerName,
                    OrdersCount = c.Orders.Length
                });
            foreach (var item in result5)
            {
                Console.WriteLine($"{item.CustomerName} - {item.OrdersCount}");
            }
            #endregion
            #region 3.3 Return a list of categories and how many products each has
            var result6 = ListGenerator.ProductsList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductsCount = g.Count()
                });
            foreach (var item in result6)
            {
                Console.WriteLine($"{item.Category} - {item.ProductsCount}");
            }
            #endregion
            #region 3.4 Get the total of the numbers in the array
            int[] numbers3 = { 1, 2, 3, 4, 5 };
            var result7 = numbers3.Sum();
            Console.WriteLine(result7);
            #endregion
            #region 3.5 Get the total number of characters of all words in dictionary_english.txt
            var words = File.ReadAllLines("dictionary_english.txt");
            var result8 = words.Sum(word => word.Length);
            Console.WriteLine(result8);
            #endregion
            #region 3.6 Get the length of the shortest word in dictionary_english.txt
            var result9 = words.Min(word => word.Length);
            Console.WriteLine(result9);
            #endregion
            #region 3.7 Get the length of the longest word in dictionary_english.txt
            var result10 = words.Max(word => word.Length);
            Console.WriteLine(result10);
            #endregion
            #region 3.8 Get the average length of the words in dictionary_english.txt
            var result11 = words.Average(word => word.Length);
            Console.WriteLine(result11);
            #endregion
            //-----------------------------------------------------------------------------
            #region 4.1 Sort a list of products by name
            var result12 = ListGenerator.ProductsList
                .OrderBy(p => p.ProductName);
            foreach (var product in result12)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region 4.2 Use a custom comparer to sort products by name ignoring case
            var result13 = ListGenerator.ProductsList
                .OrderBy(p => p.ProductName, StringComparer.OrdinalIgnoreCase);
            foreach (var product in result13)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region 4.3 Sort products by UnitsInStock in descending order
            var result14 = ListGenerator.ProductsList
                .OrderByDescending(p => p.UnitsInStock);
            foreach (var product in result14)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region 4.4 Sort digits by name length then alphabetically
            var result15 = Arr
                .OrderBy(word => word.Length)
                .ThenBy(word => word);
            foreach (var word in result15)
            {
                Console.WriteLine(word);
            }
            #endregion
            #region 4.5 Sort words first by length and then case-insensitive alphabetically
            var result16 = words
                .OrderBy(word => word.Length)
                .ThenBy(word => word, StringComparer.OrdinalIgnoreCase);
            foreach (var word in result16)
            {
                Console.WriteLine(word);
            }
            #endregion
            #region 4.6 Sort products by category and then by unit price descending
            var result17 = ListGenerator.ProductsList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);
            foreach (var product in result17)
            {
                Console.WriteLine(product);
            }
            #endregion
            #region 4.7 Sort words first by length and then case-insensitive alphabetically descending
            var result18 = words
                .OrderByDescending(word => word.Length)
                .ThenByDescending(word => word, StringComparer.OrdinalIgnoreCase);
            foreach (var word in result18)
            {
                Console.WriteLine(word);
            }
            #endregion
            #region 4.8 Sort digits whose second letter is 'i' in reverse order
            var result19 = Arr
                .Where(word => word.Length > 1 && word[1] == 'i')
                .Reverse();
            foreach (var word in result19)
            {
                Console.WriteLine(word);
            }
            #endregion
            //-----------------------------------------------------------------------------
            #region 5.1 Return a sequence of just the names of the products
            var result20 = ListGenerator.ProductsList
                .Select(p => p.ProductName);
            foreach (var name in result20)
            {
                Console.WriteLine(name);
            }
            #endregion
            #region 5.2 Produce a sequence of the uppercase and lowercase versions of each word
            var result21 = words
                .Select(word => new
                {
                    Upper = word.ToUpper(),
                    Lower = word.ToLower()
                });
            foreach (var word in result21)
            {
                Console.WriteLine($"{word.Upper} - {word.Lower}");
            }
            #endregion
            #region 5.3 Produce a sequence containing some properties of Products, with UnitPrice renamed to Price
            var result22 = ListGenerator.ProductsList
                .Select(p => new
                {
                    p.ProductName,
                    p.Category,
                    Price = p.UnitPrice
                });
            foreach (var product in result22)
            {
                Console.WriteLine($"{product.ProductName} - {product.Category} - {product.Price}");
            }
            #endregion
            #region 5.4 Determine if the value of int in an array matches its position
            int[] numbers4 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result23 = numbers4
                .Select((number, index) => new
                {
                    Number = number,
                    Index = index,
                    IsMatch = number == index
                });
            foreach (var item in result23)
            {
                Console.WriteLine($"{item.Number} - {item.Index} - {item.IsMatch}");
            }
            #endregion
            #region 5.5 Produce all pairs of numbers from two arrays such that numberA is less than numberB
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var result24 =
                from a in numbersA
                from b in numbersB
                where a < b
                select new
                {
                    A = a,
                    B = b
                };
            foreach (var item in result24)
            {
                Console.WriteLine($"({item.A}, {item.B})");
            }
            #endregion
            #region 5.6 Select all orders where the order total is less than 500
            var result25 = ListGenerator.CustomersList
                .SelectMany(c => c.Orders)
                .Where(o => o.Total < 500);
            foreach (var order in result25)
            {
                Console.WriteLine(order);
            }
            #endregion
            #region 5.7 Select all orders where the order was made in 1998 or later
            var result26 = ListGenerator.CustomersList
                .SelectMany(c => c.Orders)
                .Where(o => o.OrderDate.Year >= 1998);
            foreach (var order in result26)
            {
                Console.WriteLine(order);
            }
            #endregion
        }

    }
}