using System;
using System.Collections.Generic;
using System.Text;

namespace ATM
{
    class User
    {
        private string _name;
        private string _surname;
        private Card _creditCard;

        public string FullName
        {
            get
            {
                return this._name + " " + this._surname;
            }
        }

    
        public User(string Name, string Surname, Card CreditCard)
        {
            this._name = Name;
            this._surname = Surname;
            this._creditCard = CreditCard;
        }


    }
}
