using System;
using System.Reflection;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {

            Card card1 = new Card("3729563860162678", "5728", "472", "06/22", 500);
            Card card2 = new Card("5737284949393944", "4732", "372", "09/22", 780);
            Card card3 = new Card("5928472912938488", "1038", "289", "05/21", 590);
            Card card4 = new Card("4724854924068382", "6921", "291", "01/22", 1000);
            Card card5 = new Card("0184729395728713", "8390", "783", "04/22", 750);

            User user1 = new User("Name1", "Surname1", card1);
            User user2 = new User("Name2", "Surname2", card2);
            User user3 = new User("Name3", "Surname3", card3);
            User user4 = new User("Name4", "Surname4", card4);
            User user5 = new User("Name5", "Surname5", card5);

            object[] users = { user1, user2, user3, user4, user5 };
            object[] cards = { card1, card2, card3, card4, card5 };

            string pin;

            PropertyInfo[] propertiesCard = typeof(Card).GetProperties();

            byte itemIndex;

            do
            {
                itemIndex = 0;

                Console.WriteLine("Pin Daxil Edin");
                Console.WriteLine("====================================");
                pin = Console.ReadLine();
                Console.WriteLine("====================================");

                foreach (var item in cards)
                {
                    itemIndex++;

                    foreach (PropertyInfo property in propertiesCard)
                    {
                        string cardPin = Convert.ToString(property.GetValue(item));

                        if (pin == cardPin)
                        {
                            Card activeCard = (Card)cards[itemIndex - 1];
                            PropertyInfo[] propertiesUser = typeof(User).GetProperties();

                            foreach (PropertyInfo property1 in propertiesUser)
                            {
                                object activeUser = property1.GetValue(users[itemIndex - 1]);

                                Console.WriteLine($"{activeUser}, Xos gelmisiniz. Zehmet olmasa Asagidakilardan birini secin.");
                                Console.WriteLine("======================================");
                                Console.WriteLine("1. Balans");
                                Console.WriteLine("2. Nağd Pul");
                                Console.WriteLine("======================================");
                            }

                            switch (Console.ReadLine())
                            {
                                case "1":
                                    Console.WriteLine("======================================");
                                    activeCard.ShowBalance();
                                    break;
                                case "2":
                                    Console.WriteLine("======================================");
                                    Console.WriteLine("1. 10 AZN");
                                    Console.WriteLine("2. 20 AZN");
                                    Console.WriteLine("3. 50 AZN");
                                    Console.WriteLine("4. 100 AZN ");
                                    Console.WriteLine("5. DIGER");
                                    Console.WriteLine("======================================");
                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            Console.WriteLine("======================================");
                                            Console.WriteLine($"Balansinizdan 10 AZN Cekildi");
                                            activeCard.DecreaseBalance(10);
                                            activeCard.ShowBalance();
                                            Console.WriteLine("======================================");
                                            break;
                                        case "2":
                                            Console.WriteLine("======================================");
                                            Console.WriteLine($"Balansinizdan 20 AZN Cekildi");
                                            activeCard.DecreaseBalance(20);
                                            activeCard.ShowBalance();
                                            Console.WriteLine("======================================");
                                            break;
                                        case "3":
                                            Console.WriteLine("======================================");
                                            Console.WriteLine($"Balansinizdan 50 AZN Cekildi");
                                            activeCard.DecreaseBalance(50);
                                            activeCard.ShowBalance();
                                            Console.WriteLine("======================================");
                                            break;
                                        case "4":
                                            Console.WriteLine("======================================");
                                            Console.WriteLine($"Balansinizdan 100 AZN Cekildi");
                                            activeCard.DecreaseBalance(100);
                                            activeCard.ShowBalance();
                                            Console.WriteLine("======================================");
                                            break;
                                        case "5":
                                            Console.WriteLine("======================================");
                                            Console.WriteLine("Ne qeder mebleg cekmek isdeyirsiniz ?");
                                            Console.WriteLine("====================================");
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            if (count <= activeCard.Balance)
                                            {
                                                activeCard.DecreaseBalance(count);
                                                Console.WriteLine($"Balansinizdan {count} AZN Cekildi");
                                                activeCard.ShowBalance();
                                            }
                                            else
                                            {
                                                Console.WriteLine("======================================");
                                                Console.WriteLine("Balansinizda kifayet qeder mebleg yoxdur");
                                                Console.WriteLine("======================================");
                                            }

                                            break;
                                        default:
                                            break;
                                    }

                                    break;
                                default:
                                    break;
                            }
                            return;
                        }
                    }
                }

                Console.WriteLine("Bu PIN tapilmadi, lutfen duzgun PIN daxil edin.");
                Console.WriteLine("======================================");

            } while (true);








        }
    }
}
