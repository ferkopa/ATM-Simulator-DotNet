/*
 * Author: Paulina Ferko
 * Student Number: 991476228
 * File: ClientAccount.cs
 * 
 * Solution Name: AS_S2022_991476228
 * Files included in project:
 *        AtmMachiine.cs
 *        AtmManagement.cs
 * 
 * Description: Classes for all accounts and rewards program. All classes are 
 *              utilized in the Library of Collections and the main class.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMangementLibrary
{
    //parent class that holds all variables for customer bank account
    public class ClientAccount
    {
        
        //declaring private variables that cannot be accessed outside of the class without accessors/mutators
        private long _accountNumber;
        private string _clientFirstName;
        private string _clientLastName;
        private int _clientPin;
        private string _clientEmail;
        private string _clientAddress;
        private string _clientPhone;

        private double _balance;
        private int _points;
        private string _accountType;
        private double _monthlyCharge;

        //default constructor for client account class
        public ClientAccount()
        {
            _clientFirstName = "Johnny";
            _clientLastName = "Appleseed";
            _clientPin = 1234;
            _clientEmail = "johnny.appleseed@demo.com";
            _clientPhone = "905-281-2683";
            _clientAddress = "45 Main Street";
            

            _accountNumber = 0000000000L;
            _balance = 0.00;
            _points = 0;
            _accountType = "Chequing Account";
            _monthlyCharge = 10.00;
        }

        //argument constructor for client account class
        public ClientAccount(string clientFirstName, string clientLastName, int clientPin, string email, string address, string phone)
        {
            _clientFirstName = clientFirstName;
            _clientLastName = clientLastName;
            _clientPin = clientPin;
            _clientEmail = email;
            _clientPhone = phone;
            _clientAddress = address;

        }

        //accessors and mutators for the private variables for client account class
        public long AccountNumber { get; set; }       
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public int ClientPin { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }


        public double Balance { get; set; }
        public int Points { get; set; }
        public string AccountType { get; set; }
        public double MonthlyCharge { get; set; }

       
        //withdraw method that returns the new account balace upon withdrawal
        public double WithdrawFromAccount(double withdraw, double balance)
        {
            //condiitonal statement for error handling user input
            if(withdraw > 0 && withdraw <= balance)
            {
                balance = balance - withdraw;
            }
            else
            {
                Console.WriteLine($"Insufficient funds to withdraw {withdraw.ToString("C2")}");
            }
            return balance;
        }

        //deposit method that returns the updated account balance upon user depositing to account
        public double DepositToAccount(double deposit, double balance)
        {
            //condiitonal statement to error handling user input
            if(deposit > 0)
            {
                balance += deposit;
            }
            else
            {
                Console.WriteLine($"Insufficient funds entered to deposit {deposit.ToString("C2")}");
            }
            return balance;
        }
       
    }

    //Chequing account class inheriting from the client account class 
    public class ChequingAccount : ClientAccount
    {
        //constructor to set the default account type and monthly charge for each user
        public ChequingAccount()
        {
            this.AccountType = "Chequing Account";
            this.MonthlyCharge = 10.00;
        }
    }


    //Basic account account class inheriting from the client account class 
    public class BasicAccount : ClientAccount
    {
        //constructor to set the default account type and monthly charge for each user
        public BasicAccount()
        {
            this.AccountType = "Basic Account";
            this.MonthlyCharge = 13.00;
        }
    }


    //ultimate account class inheriting from the client account class 
    public class UltimateAccount : ClientAccount
    {
        //constructor to set the default account type and monthly charge for each user
        public UltimateAccount()
        {
            this.AccountType = "Ultimate Account";
            this.MonthlyCharge = 20.00;
        }

        
            
    }


    //preferred account class inheriting from the client account class 
    public class PreferredAccount : ClientAccount
    {
        //constructor to set the default account type and monthly charge for each user
        public PreferredAccount()
        {
            this.AccountType = "Preferred Account";
            this.MonthlyCharge = 17.00;
        }
    }
    //rewards class to calculate the points - related to the ultimate account
    public class RewardProgram : UltimateAccount
    {
        public RewardProgram()
        {
            this.AccountType = "Rewards Program";
        }
        //method to calculate points
        public int PointsCalculator(double balance)
        {
            int amount = 0;

            if (balance > 2000)
            {
                //calculating points based on balance

                //adds 10 points if the balance is over 2000
                amount += 10;

                //calculates additional points for every 500 dollars voer
                int calcPoints = 0;
                calcPoints = (int)((balance - 2000) / 500);
                calcPoints *= 5;

                amount += calcPoints;
            }
            else
            {
                amount = 0;
            }
            return amount;
        }
    }

}
