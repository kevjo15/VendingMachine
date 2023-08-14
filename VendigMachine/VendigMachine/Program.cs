using System.Security.Cryptography.X509Certificates;

namespace VendigMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string? userInput;

            //välkomst meddelande
            Console.WriteLine("Welcome to the VendingMachine!");
            Console.WriteLine();
            //Console.WriteLine("Choose your product:");
            Console.WriteLine();

            #region Objekt & Listor
            //skapar mina listor
            List<Candys> candyList = new List<Candys>();
            List<Drinks> drinkList = new List<Drinks>();

            //skapar mina objekt
            Candys snickers = new Candys("Snicker", 50, "Sickers is a chocolate bar, 300 kcal", "1", 5);
            Candys marabo = new Candys("Marabo", 100, "Marabo is chocolate bar, 500 kcal", "2", 15);
            Candys reeses = new Candys("Reese´s", 215, "Reese´s is a penutbutter chocolatebar, 670 kcal", "3", 18);
            Drinks mountainDew = new Drinks("Mountain Dew", 250, "Mountain Dew, is a soda drink, 200 kcal", "4", 30);
            Drinks Coke = new Drinks("Coca Cola", 250, "Coca Cola, is a soda drink, 230 kcal", "5", 30);
            Drinks fanta = new Drinks("Fanta Orange", 250, "Fanta Orange, is a soda drink, 210 kcal", "6", 25);

            User user = new User();

            //Lägger till Objekt till lista
            candyList.Add(snickers);
            candyList.Add(marabo);
            candyList.Add(reeses);
            drinkList.Add(mountainDew);
            drinkList.Add(Coke);
            drinkList.Add(fanta);

            #endregion

            //sätter plånbokens värde baserat på antalet av varje valör
            int walletBalance = (user.enKrUser * 1) + (user.tvåKrUser * 2) + (user.femKrUser * 5) + (user.tioKrUser * 10) + (user.tjugoKrUser * 20) + (user.femtioKrUser * 50) + (user.hundraKrUser * 100) + (user.tvåHundraKrUser * 200) + (user.femHundraKrUser * 500);
            int amount = 0;

            DepositMoney();

            void DepositMoney()
            {

                //Visa hur mycket pengar som finns i användaren plånbok
                #region Denomination WriteLine
                Console.WriteLine("Your wallet has " + user.enKrUser + " enKr");
                Console.WriteLine("Your wallet has " + user.tvåKrUser + " tvåKr");
                Console.WriteLine("Your wallet has " + user.femKrUser + " femKr");
                Console.WriteLine("Your wallet has " + user.tioKrUser + " tioKr");
                Console.WriteLine("Your wallet has " + user.tjugoKrUser + " tjugoKr");
                Console.WriteLine("Your wallet has " + user.femtioKrUser + " femtioKr");
                Console.WriteLine("Your wallet has " + user.hundraKrUser + " hundraKr");
                Console.WriteLine("Your wallet has " + user.tvåHundraKrUser + " tvåHundraKr");
                Console.WriteLine("Your wallet has " + user.femHundraKrUser + " femHundraKr");
                Console.WriteLine();
                Console.WriteLine("Which totals " + walletBalance + " kr");
                Console.WriteLine("----------------------------------");
                #endregion

                Console.WriteLine("Insert money");
                Console.WriteLine();
                Console.WriteLine("Choose denomination (1kr, 2Kr, 5kr, 10kr, 20kr, 50kr, 100kr, 200kr, 500kr) ");
                string denomination = Console.ReadLine();
                Console.WriteLine("How much of this denomination would you like to deposit?");
                amount = Convert.ToInt32(Console.ReadLine());

                //switch case för att ta bort amount från rätt denomination i user
                switch (denomination)
                {
                    case ("1kr"):
                        //guard clause, if statement protects code in case
                        if (user.enKrUser < amount) { NotEnough(); return; }
                        user.enKrUser = Case(1, user.enKrUser);
                        break;
                    case ("2kr"):
                        if (user.tvåKrUser < amount) { NotEnough(); return; }
                        user.tvåKrUser = Case(2, user.tvåKrUser);
                        break;
                    case ("5kr"):
                        if (user.femKrUser < amount) { NotEnough(); return; }
                        user.femKrUser = Case(5, user.femKrUser);
                        break;
                    case ("10kr"):
                        if (user.tioKrUser < amount) { NotEnough(); return; }
                        user.tioKrUser = Case(10, user.tioKrUser);
                        break;
                    case ("20kr"):
                        if (user.tjugoKrUser < amount) { NotEnough(); return; }
                        user.tjugoKrUser = Case(20, user.tjugoKrUser);
                        break;
                    case ("50kr"):
                        if (user.femtioKrUser < amount) { NotEnough(); return; }
                        user.femtioKrUser = Case(50, user.femtioKrUser);
                        break;
                    case ("100kr"):
                        if (user.hundraKrUser < amount) { NotEnough(); return; }
                        user.hundraKrUser = Case(100, user.hundraKrUser);
                        break;
                    case ("200kr"):
                        if (user.tvåHundraKrUser < amount) { NotEnough(); return; }
                        user.tvåHundraKrUser = Case(200, user.tvåHundraKrUser);
                        break;
                    case ("500kr"):
                        if (user.femHundraKrUser < amount) { NotEnough(); return; }
                        user.femHundraKrUser = Case(500, user.femHundraKrUser);
                        break;
                    default:
                        Console.WriteLine("Invalid Denomination");
                        break;
                }
                //Samt att öka amount i rätt denomination i vending machine
                Console.WriteLine("Money left in your wallet: " + walletBalance);
                Console.WriteLine("Money inserted in machine: " + user.insertedMoney);
                Menu();
            }

            void NotEnough()
            {
                Console.Clear();
                Console.WriteLine("!!!You do not have enough of this denomination!!!");
                Console.WriteLine("----------------------------------");
                DepositMoney();
                return;
            }

            int Case(int num, int kr)
            {
                user.insertedMoney = (user.insertedMoney += num) * amount;
                walletBalance -= user.insertedMoney;
                kr -= amount;
                return kr;
            }

            #region Purchase method
            void Purchase()
            {
                //for loop jämför användarens input med alla taggar i candyList
                for (int i = 0; i < candyList.Count; i++)
                {

                    if (userInput == candyList[i].tag)
                    {
                        //en if-sats som frågar om använderen vill köpa produkten och inväntar svar
                        candyList[i].Description(candyList[i].description + ", price is " + candyList[i].price + "kr");
                        Console.Write("Do you want to purchase this item? Yes(y), or (n)");
                        string keyInput = Console.ReadLine();
                        if (keyInput == "y")
                        {
                            //användaren köper produkten, så vi kallar på våran Buy() metod.
                            if (candyList[i].Buy(candyList[i].name, user.insertedMoney))
                            {
                                //tar bort pengar från vendingmachine
                                user.insertedMoney -= candyList[i].price;
                                //retunerar pengar från vendingmachine till wallet
                                walletBalance += user.insertedMoney;
                                Console.WriteLine("Returned " + user.insertedMoney + "kr to your wallet. You now have: " + walletBalance);

                                //Skriver ut vilken valör resterande pengar returneras i
                                CheckReturn();

                                user.insertedMoney = 0;
                            }
                            else
                            {
                                //retunerar pengar från vendingmachine till wallet
                                walletBalance += user.insertedMoney;
                                Console.WriteLine("Returned " + user.insertedMoney + "kr to your wallet. You now have: " + walletBalance);
                                //Skriver ut vilken valör resterande pengar returneras i

                                CheckReturn();

                                user.insertedMoney = 0;
                            }

                        }
                        Console.WriteLine("Press any key to return to menu");
                        string anyKey = Console.ReadLine();
                        if (anyKey != null)
                        {
                            Console.Clear();
                            DepositMoney();
                        }

                    }
                }
                //for loop jämför användarens input med alla taggar i drinkList
                for (int i = 0; i < drinkList.Count; i++)
                {
                    if (userInput == drinkList[i].tag)
                    {
                        drinkList[i].Description(drinkList[i].description + ", price is " + drinkList[i].price);
                        Console.Write("Do you want to purchase this item? Yes(y), or (n)");
                        string keyInput = Console.ReadLine();
                        if (keyInput == "y")
                        {
                            if (drinkList[i].Buy(drinkList[i].name, user.insertedMoney))
                            {
                                user.insertedMoney -= drinkList[i].price;
                                walletBalance += user.insertedMoney;
                                Console.WriteLine("Returned " + user.insertedMoney + "kr to your wallet. You now have: " + walletBalance);
                                //Skriv ut vilken valör resterande pengar returneras i

                                CheckReturn();

                                user.insertedMoney = 0;
                            }
                            else
                            {
                                walletBalance += user.insertedMoney;
                                Console.WriteLine("Returned " + user.insertedMoney + "kr to your wallet. You now have: " + walletBalance);
                                //Skriv ut vilken valör resterande pengar returneras i

                                CheckReturn();

                                user.insertedMoney = 0;
                            }
                        }
                        Console.WriteLine("Press any key to return to menu");
                        string anyKey = Console.ReadLine();
                        if (anyKey != null)
                        {
                            Console.Clear();
                            DepositMoney();
                        }
                    }
                }
            }
            #endregion

            void CheckReturn()
            {
                int money = user.insertedMoney;
                int temp = 0;

                temp = (money / 500);
                user.femHundraKrUser += temp;
                money -= (temp * 500);
                if (money % 500 != 0)
                {
                    temp = (money / 200);
                    user.tvåHundraKrUser += temp;
                    money -= (temp * 200);

                    if (money % 200 != 0)
                    {
                        temp = (money / 100);
                        user.hundraKrUser += temp;
                        money -= (temp * 100);

                        if (money % 100 != 0)
                        {
                            temp = (money / 50);
                            user.femtioKrUser += temp;
                            money -= (temp * 50);

                            if (money % 50 != 0)
                            {
                                temp = (money / 20);
                                user.tjugoKrUser += temp;
                                money -= (temp * 20);

                                if (money % 20 != 0)
                                {
                                    temp = (money / 10);
                                    user.tioKrUser += temp;
                                    money -= (temp * 10);

                                    if (money % 10 != 0)
                                    {
                                        temp = (money / 5);
                                        user.femKrUser += temp;
                                        money -= (temp * 5);

                                        if (money % 2 != 0)
                                        {
                                            temp = (money / 2);
                                            user.tvåKrUser += temp;
                                            money -= (temp * 2);

                                            if (money % 5 != 0)
                                            {
                                                temp = (money / 1);
                                                user.enKrUser += temp;
                                                money -= (temp * 1);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            #region Menu method
            void Menu()
            {
                //en for-loop som skriver ut produkter
                for (int i = 0; i < candyList.Count; i++)
                {
                    var c = candyList[i];
                    Console.WriteLine(c.tag + ": " + c.name);
                }

                //en for-loop som skriver ut produkter
                for (int i = 0; i < drinkList.Count; i++)
                {
                    var d = drinkList[i];
                    Console.WriteLine(d.tag + ": " + d.name);
                }

                Console.WriteLine();
                Console.WriteLine("Press (Q) to exit");

                userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    walletBalance += user.insertedMoney;
                    Console.WriteLine("Returned " + user.insertedMoney + "kr to your wallet. You now have: " + walletBalance);
                    user.insertedMoney = 0;
                    Environment.Exit(-1);
                }

                Purchase();
            }
            #endregion
        }
    }
}