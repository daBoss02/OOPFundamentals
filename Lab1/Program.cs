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

Dictionary<int, int> coins = new Dictionary<int, int>()
{
    {1, 10},
    {2, 10},
    {5, 5},
    {10, 5},
    {20, 5}
};
VendingMachine vendor = new VendingMachine(coins);
vendor.StockItem();
vendor.StockItem();
vendor.StockItem();
vendor.StockItem();

vendor.printInv();