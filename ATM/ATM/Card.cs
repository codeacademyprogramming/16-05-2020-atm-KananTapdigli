using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;

namespace ATM
{
    class Card
    {
        private string _PAN;
        private string _PIN;
        private string _CVC;
        private string _expireDate;
        private decimal _balance;

        public string PIN
        {
            get
            {
                return this._PIN;
            }
        }

        public decimal Balance
        {
            get
            {
                return this._balance;
            }
        }

        public Card(string PAN, string PIN, string CVC, string ExpireDate, decimal Balance)
        {
            this._PAN = PAN;
            this._PIN = PIN;
            this._CVC = CVC;
            this._expireDate = ExpireDate;
            this._balance = Balance;
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Balansinizdaki Mebleg: {this._balance} AZN");
        }

        public  void DecreaseBalance(int count)
        {
            this._balance = this._balance - count;
        }



    }
}
