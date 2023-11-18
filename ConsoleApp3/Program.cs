using System;

class Converter
{
    private decimal usdExchangeRate;
    private decimal eurExchangeRate;

    public Converter()
    {
        usdExchangeRate = 38.00M; 
        eurExchangeRate = 40.00M; 
    }

    public decimal Convert(decimal amount, string fromCurrency, string toCurrency)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Сума від'ємна!");
        }

        if (fromCurrency == "UAH" && toCurrency == "USD")
        {
            return amount / usdExchangeRate;
        }
        else if (fromCurrency == "UAH" && toCurrency == "EUR")
        {
            return amount / eurExchangeRate;
        }
        else if (fromCurrency == "USD" && toCurrency == "UAH")
        {
            return amount * usdExchangeRate;
        }
        else if (fromCurrency == "EUR" && toCurrency == "UAH")
        {
            return amount * eurExchangeRate;
        }
        else if (fromCurrency == toCurrency)
        {
            return amount; 
        }
        else
        {
            throw new ArgumentException("Неправильно написані валюти.");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Converter converter = new Converter();

            Console.WriteLine("Введіть назву валюти яку хочете конвертувати (UAH, USD, EUR): ");
            string fromCurrency = Console.ReadLine().ToUpper();

            Console.Write($"Введіть суму в {fromCurrency}: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Введіть назву валюти, в яку хочете конвертувати попередню валюту (UAH, USD, EUR): ");
            string toCurrency = Console.ReadLine().ToUpper();

            decimal result = converter.Convert(amount, fromCurrency, toCurrency);

            Console.WriteLine($"Результат конвертації: {result} {toCurrency}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: неправильний формат введених даних.");
        }
    }
}
