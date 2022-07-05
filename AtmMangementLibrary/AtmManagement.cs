/*
 * Author: Paulina Ferko
 * Student Number: 991476228
 * File: AtmManagement.cs
 * 
 * Solution Name: AS_S2022_991476228
 * Files included in project:
 *        AtmMachiine.cs
 *        ClientAccount.cs
 * 
 * Description: Library of records featuring a List<T> collection. AtmMachine.cs 
 *              retrieves records from here via LINQ queries.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmMangementLibrary
{
    public class AtmManagement
    {
        //pre-loading data for the collection - uses the client account, but creates specific instances of objects within list
        public static List<ClientAccount> LoadAllClientData()
        {
            List<ClientAccount> clientAccount = new List<ClientAccount>() { 
                
                new ChequingAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Michael", ClientLastName = "Scott", ClientPin = 8945, ClientEmail = "mscott@dm.com", ClientPhone = "467-555-3141", ClientAddress = "600 King St. Unit 201", Balance = 4000.78, AccountType = "Chequing Account", Points = 0, MonthlyCharge = 10.00},

                new ChequingAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Dwight", ClientLastName = "Schrute", ClientPin = 1876, ClientEmail = "dschrute@dm.com", ClientPhone = "467-555-2871", ClientAddress = "1 Schrute Farms", Balance = 6150.12, AccountType = "Chequing Account", Points = 0, MonthlyCharge = 10.00},

                new ChequingAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Angela", ClientLastName = "Martin", ClientPin = 4236, ClientEmail = "amartin@dm.com", ClientPhone = "467-555-0121", ClientAddress = "13 Senator Road", Balance = 760.89, AccountType = "Chequing Account", Points = 0, MonthlyCharge = 10.00},

                new ChequingAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Kevin", ClientLastName = "Malone", ClientPin = 2222, ClientEmail = "kmalone@dm.com", ClientPhone = "467-555-3987", ClientAddress = "1817 MisTrail Cres.", Balance = 21.56, AccountType = "Chequing Account", Points = 0, MonthlyCharge = 10.00},

                new ChequingAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Stanley", ClientLastName = "Hudson", ClientPin = 0908, ClientEmail = "shudson@dm.com", ClientPhone = "467-555-2322", ClientAddress = "34 Credit Vallies Blvd", Balance = 4509.76, AccountType = "Chequing Account", Points = 0, MonthlyCharge = 10.00},


                new BasicAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Jim", ClientLastName = "Halpert", ClientPin = 1345, ClientEmail = "jhalpert@dm.com", ClientPhone = "467-555-6354", ClientAddress = "30 Banker Street", Balance = 14560.7, AccountType = "Basic Account", Points = 0, MonthlyCharge = 13.00},

                new BasicAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Phyllis", ClientLastName = "Lapin-Vance", ClientPin = 6567, ClientEmail = "plapinvance@dm.com", ClientPhone = "467-555-1412", ClientAddress = "8906 Horneby Road", Balance = 2340.89, AccountType = "Basic Account", Points = 0, MonthlyCharge = 13.00},

                new BasicAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Andrew", ClientLastName = "Bernard", ClientPin = 5199, ClientEmail = "abernard@dm.com", ClientPhone = "467-555-4332", ClientAddress = "310 Sailer Way", Balance = 1000.99, AccountType = "Basic Account", Points = 0, MonthlyCharge = 13.00},

                new BasicAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Erin", ClientLastName = "Hannon", ClientPin = 9087, ClientEmail = "ehannon@dm.com", ClientPhone = "467-555-4321", ClientAddress = "1901 Wallace Ave. Unit 506", Balance = 1423.45, AccountType = "Basic Account", Points = 0, MonthlyCharge = 13.00},

                new BasicAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Oscar", ClientLastName = "Martinez", ClientPin = 8762, ClientEmail = "omartinez@dm.com", ClientPhone = "467-555-1567", ClientAddress = "67 Victory Street", Balance = 1865.2, AccountType = "Basic Account", Points = 0, MonthlyCharge = 13.00},


                new PreferredAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Pam", ClientLastName = "Halpert", ClientPin = 9176, ClientEmail = "phalpert@dm.com", ClientPhone = "467-555-0106", ClientAddress = "30 Banker Street", Balance = 2813.09, AccountType = "Preferred Account", Points = 0, MonthlyCharge = 17.00 },

                new PreferredAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Meredith", ClientLastName = "Palmer", ClientPin = 8345, ClientEmail = "mpalmer@dm.com", ClientPhone = "467-555-1405", ClientAddress = "1880 Rosee Blvd", Balance = 345.90, AccountType = "Preferred Account", Points = 0 , MonthlyCharge = 17.00},

                new PreferredAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Creed", ClientLastName = "Bratton", ClientPin = 5657, ClientEmail = "cbratton@dm.com", ClientPhone = "467-555-3786", ClientAddress = "80 Bradford Street", Balance = 1865.0, AccountType = "Preferred Account", Points = 0 , MonthlyCharge = 17.00},

                new PreferredAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Roy", ClientLastName = "Anderson", ClientPin = 3045, ClientEmail = "randerson@dm.com", ClientPhone = "467-555-3678", ClientAddress = "28 Banker Street", Balance = 1560.34, AccountType = "Preferred Account", Points = 0 , MonthlyCharge = 17.00},

                new PreferredAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Kelly", ClientLastName = "Kapoor", ClientPin = 6978, ClientEmail = "kkapoor@dm.com", ClientPhone = "467-555-3456", ClientAddress = "18-8909 Benny Blvd", Balance = 34.22, AccountType = "Preferred Account", Points = 0 , MonthlyCharge = 17.00},

                new UltimateAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Toby", ClientLastName = "Flenderson", ClientPin = 1234, ClientEmail = "tflenderson@dm.com", ClientPhone = "467-555-5567", ClientAddress = "2 Flanders Road", Balance = 2849.09, AccountType = "Ultimate Account", Points = 15 , MonthlyCharge = 20.00},

                new UltimateAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Ryan", ClientLastName = "Howard", ClientPin = 1765, ClientEmail = "rhoward@dm.com", ClientPhone = "467-555-2567", ClientAddress = "650 Credens Cres", Balance = 1999.99, AccountType = "Ultimate Account", Points = 0 , MonthlyCharge = 20.00},

                new UltimateAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Holly", ClientLastName = "Flax", ClientPin = 9804, ClientEmail = "hflax@dm.com", ClientPhone = "467-555-3854", ClientAddress = "10 Cadbury Road", Balance = 6743.1, AccountType = "Ultimate Account", Points = 55, MonthlyCharge = 20.00},

                new UltimateAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Robert", ClientLastName = "California", ClientPin = 6989, ClientEmail = "rcalifornia@dm.com", ClientPhone = "467-555-1880", ClientAddress = "245 Hollywood Blvd", Balance = 8976.2, AccountType = "Ultimate Account", Points = 75, MonthlyCharge = 20.00},

                new UltimateAccount(){AccountNumber = GenerateAccountNumber(), ClientFirstName = "Karen", ClientLastName = "Filipelli", ClientPin = 6183, ClientEmail = "kfilipelli@dm.com", ClientPhone = "467-555-7878", ClientAddress = "98 Maine Road", Balance = 12031.65, AccountType = "Ultimate Account", Points = 110, MonthlyCharge = 20.00 }

            };
            return clientAccount;
        }

        //method to generate randomly assigned account number
        public static long GenerateAccountNumber()
        {
            Random random = new Random();
            long accountNo = (long)random.Next(100000000, 999999999);
            return accountNo;
        }

    }
}
