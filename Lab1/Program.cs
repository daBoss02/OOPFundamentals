/*
A vending machine has a set of coins to handle purchase operations.
When a customer buys a product from the machine and pays, the machine
will return the remaining money from the coins in its internal storage.
Suppose our machine has the following coins:
$1, $2, $5, $10, $20
The machine tracks the quantity of each coin: for example, the quantity of $5 coins is 15,
which means the machine currently has 15 pieces of $5 coins.
*/


using Lab1;
using System.Threading.Channels;

bool isCancel(string inp)
{
    if (inp.ToUpper() == "CANCEL")
    {
        return true;
    }
    else
    {
        return false;
    }
}
string getCode(VendingMachine vendor)
{
    int length = vendor.codeCount;

    char[] letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

    char letter = letters[length / 10];
    int number = length % 10;
    return $"{letter}{number}";
}

Dictionary<int, int> coins = new Dictionary<int, int>()
{
        {20, 1 },
        {10, 1 },
        {5, 3 },
        {2, 5 },
        {1, 5 }
};

VendingMachine vendor = new VendingMachine(coins);

Product beans = new Product(getCode(vendor), "Beans", 4);
vendor.StockItem(beans, 1);
vendor.StockItem(beans, 2);
Product apple = new Product(getCode(vendor), "Apple", 2);
vendor.StockItem(apple, 4);
Product skittles = new Product(getCode(vendor), "Skittles", 6);
vendor.StockItem(skittles, 3);
vendor.StockItem(skittles, 7);

bool continueTransaction = true;
bool cancel = false;

while (continueTransaction)
{
    Console.WriteLine("Type 'cancel' at any time to terminate the processes");
    Console.WriteLine("Please input the amount of money you wish to spend:");
    Console.Write("$");
    string moneyInp = Console.ReadLine();
    int userMoney = 0;
    bool noMoney = true;
    if (isCancel(moneyInp)) { break; }
    try
    {
        userMoney = int.Parse(moneyInp);
        noMoney = false;
    }
    catch
    {
        noMoney = true;
    }

    while (string.IsNullOrWhiteSpace(moneyInp) || noMoney)
    {
        Console.WriteLine("Please input an amount of money:");
        Console.Write("$");
        moneyInp = Console.ReadLine();
        if (isCancel(moneyInp)) { cancel = true; break; }
        try
        {
            userMoney = int.Parse(moneyInp);
            noMoney = false;
        }
        catch
        {
            noMoney = true;
        }
    }
    if (cancel) { break; }
    Console.WriteLine("Please Select an Item:");
    vendor.printInv();
    string chosenItem = Console.ReadLine().ToUpper();
    if (isCancel(chosenItem)) { break; }
    while (string.IsNullOrWhiteSpace(chosenItem))
    {
        Console.WriteLine("Please Select a valid Item:");
        chosenItem = Console.ReadLine().ToUpper();
        if (isCancel(chosenItem)) { cancel = true; break; }

    }
    if (cancel) { break; }

    vendor.VendItem(chosenItem, userMoney);
}