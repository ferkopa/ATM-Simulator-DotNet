/*
 * Author: Paulina Ferko
 * Student Number: 991476228
 * File: AtmMachine.cs
 * 
 * Solution Name: AS_S2022_991476228
 * Files included in project:
 *        AtmManagement.cs
 *        ClientAccount.cs
 * 
 * Description: Simulated ATM machine that allows user to create new account, login with an 
 *              existing account and close their accounts. Program calculates user balance
 *              and determines if user has the correct account to collect points. User is 
 *              guided through their transaction using yes or no prompts to determine if
 *              they will continue or not.
 */

using AtmMangementLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS_S2022_991476228
{
    //implements running code to simulate an ATM machine
    public class AtmMachine
    {
        //gloabal instance of Client Account collection - loaded from library
        public static List<ClientAccount> clientAccount = AtmManagement.LoadAllClientData();
        static void Main(string[] args)
        {

            //variables to store user input
            char displayChoice = ' ';
            
            //converted variables from char to int for use in error handling later in project
            int mainMenuChoice1 = (int)'1';
            int mainMenuChoice2 = (int)'2';
            int mainMenuChoice3 = (int)'3';

            //boolean variables to control loop and to determine if email aready exists in collection
            bool continueProgram = true;
            bool newEmail;

            //do while loop that will run the program - shows the main menus to the console for user input
            do
            {
            
                //method to display menu to console
                Display();

                //stores user input by parsing to a char
                displayChoice = Convert.ToChar(Console.Read());

                //converts user input to run thorugh error handling 
                int convertedChoice = (int)displayChoice;

                //clears buffer
                Console.ReadLine();
            
                /* conditional statement to re-direct user to their choice 
                 * compares user input against the numeric equivalent of the character they enter accoriding to ASCII table
                 * i.e. if user enters 1 -> converted to numeric value of that char
                 */
                if (convertedChoice == mainMenuChoice1)
                {
                    Console.WriteLine("\nEnter the number associated with the account type you would like to create.");

                    //calls on method to display the different accounts for user to choose from
                    AccountTypeMenu();
                    Console.Write("Enter your choice: ");

                    //gathering user input as a char to handle errors
                    char getUserChoice = Convert.ToChar(Console.Read());

                    //converting from char to numeric value of that char
                    int convertedChar = (int)getUserChoice;
                    int convertedChoice1 = (int)'1';
                    int convertedChoice2 = (int)'2';
                    int convertedChoice3 = (int)'3';
                    int convertedChoice4 = (int)'4';

                    //empty string that will store user's email for later use
                    string clientEmail = "";

                    //compares user's account choice to the numeric value of char '1'
                    if (convertedChar == convertedChoice1)
                    {
                       
                        //creating a new chequing account object
                        ChequingAccount newChequing = new ChequingAccount();

                        /* calls on method to gather user input and casts info from a ClientAccount object to 
                         * ChequingAccount object
                         */
                        newChequing = (ChequingAccount)GatherNewClientInfo(newChequing);

                        //sets the account type to chequing and generates a random account number
                        newChequing.AccountType = "Chequing Account";
                        newChequing.AccountNumber = GenerateAccountNumber();

                        //LINQ method query to determine if the email already exists in the collection
                        newEmail = clientAccount.Any(cl => cl.ClientEmail == newChequing.ClientEmail);

                        /*conditional statement to infor user if the email has been taken (newEmail == true)
                         * or if they were successfull in their registration
                         */
                        if(newEmail)
                        {
                            Console.WriteLine("Email has been registered previously. Please select a different email");
                        }
                        else
                        {
                            //adds new chequing account to the collection
                            clientAccount.Add(newChequing);

                            //stores the user's email
                            clientEmail = newChequing.ClientEmail;

                            //output to console
                            Console.WriteLine($"\n\nYour account has been successfully created! All details will be emailed to you via your email, {clientEmail}");
                        }
                    }
                    //compares user's account choice to the numeric value of char '2'
                    else if (convertedChar == convertedChoice2)
                    {
                        //creating new basic account object
                        BasicAccount newBasic = new BasicAccount();

                        /* calls on method to gather user input and casts info from a ClientAccount object to 
                         * BasicAccount object
                         */
                        newBasic = (BasicAccount)GatherNewClientInfo(newBasic);

                        //sets account type to basic and generates random number for the account number
                        newBasic.AccountType = "Basic Account";
                        newBasic.AccountNumber = GenerateAccountNumber();

                        //LINQ method query to determine if the email already exists in the collection
                        newEmail = clientAccount.Any(x => x.ClientEmail == newBasic.ClientEmail);
                        if (newEmail)
                        {
                            Console.WriteLine("Email has been registered previously. Please select a different email");
                        }
                        else
                        {
                            //adds new basic account to the collection
                            clientAccount.Add(newBasic);

                            //holds the user's email
                            clientEmail = newBasic.ClientEmail;
                            Console.WriteLine($"\n\nYour account has been successfully created! All details will be emailed to you via your email, {clientEmail}");
                        }



                    }
                    //compares user's account choice to the numeric value of char '3'
                    else if (convertedChar == convertedChoice3)
                    {
                        //creating new preferred account object
                        PreferredAccount newPreferred = new PreferredAccount();

                        /* calls on method to gather user input and casts info from a ClientAccount object to 
                         * PreferredAccount object
                         */
                        newPreferred = (PreferredAccount)GatherNewClientInfo(newPreferred);

                        //sets account type to basic and generates random number for the account number
                        newPreferred.AccountType = "Preferred Account";
                        newPreferred.AccountNumber = GenerateAccountNumber();

                        //LINQ method query to determine if the email already exists in the collection
                        newEmail = clientAccount.Any(x => x.ClientEmail == newPreferred.ClientEmail);
                        if (newEmail)
                        {
                            Console.WriteLine("Email has been registered previously. Please select a different email");
                        }
                        else
                        {
                            //adds new preferred account to the collection
                            clientAccount.Add(newPreferred);

                            //holds user's email
                            clientEmail = newPreferred.ClientEmail;
                            Console.WriteLine($"\n\nYour account has been successfully created! All details will be emailed to you via your email, {clientEmail}");
                        }


                    }
                    //compares user's account choice to the numeric value of char '4'
                    else if (convertedChar == convertedChoice4)
                    {
                        //creating new ultimate account object
                        UltimateAccount newUltimate = new UltimateAccount();

                        /* calls on method to gather user input and casts info from a ClientAccount object to 
                         * PreferredAccount object
                         */
                        newUltimate = (UltimateAccount)GatherNewClientInfo(newUltimate);

                        //sets account type to basic and generates random number for the account number
                        newUltimate.AccountType = "Ultimate Account";
                        newUltimate.AccountNumber = GenerateAccountNumber();

                        //calculates the points that are to be award to the user if they have over 2000 dollars
                        RewardProgram rewards = new RewardProgram();
                        rewards.PointsCalculator(newUltimate.Balance);

                        //sets the points from ultimate account class to the calculated points from the rewards class
                        newUltimate.Points = rewards.Points;


                        //LINQ method query to determine if the email already exists in the collection
                        newEmail = clientAccount.Any(x => x.ClientEmail == newUltimate.ClientEmail);
                        if (newEmail)
                        {
                            Console.WriteLine("Email has been registered previously. Please select a different email");
                        }
                        else
                        {
                            //adds new ultimate account to the collection
                            clientAccount.Add(newUltimate);
                            clientEmail = newUltimate.ClientEmail;
                            Console.WriteLine($"\n\nYour account has been successfully created! All details will be emailed to you via your email, {clientEmail}");
                        }
                    }
                    //if user inputs anything that is not 1-4, they return to the main menu
                    else
                    {
                        Console.WriteLine("You entered an invalid choice. Returning to main menu....\n");
                        
                    }

                }

                //conditional statement if the user chooses to login to their account
                else if (displayChoice == mainMenuChoice2)
                {
                    //prompts for user input for email and pin
                    string email = GatherInput("\nPlease enter your email: ");
                    int pin = Convert.ToInt32(GatherInput("Enter your pin number: "));

                    
                    //LINQ method query to find the record in the collection that matches the email and pin entered by user
                    var findMe = clientAccount.Where(x => x.ClientPin == pin && x.ClientEmail == email);

                    //conditional statement to run if there is a record found in the collection that matches user input
                    if (findMe.Any())
                    {
                        //calls on method to access user's account - takes in pin, email and the client accoutn as parameters
                        AccessingChequingAccount(pin, email);

                    }
                    else
                    {
                        Console.WriteLine("Not found in the system. Try again");
                    }
                   

                    continue;

                }
                // if user chooses to leave application, they get a  good messages and application finishes
                else if(displayChoice == mainMenuChoice3)
                {
                    Console.WriteLine("\nThank you for choosing Dunder Mifflin-Sabre Bank. See you soon...:)\n");
                    break;
                }

                //if user inputs a values that does not match 1-3, they ar given message and looped back to the main menu
                else
                {
                    Console.WriteLine("Invalid choice. Choose another menu item.");
                }

                
                continue;

            // do while loop runs provided that the continue program is true;
            } while (continueProgram);
        }

        //method that gathers input from the user - accepts a string and returns a string
        public static string GatherInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            return input;
        }

        // method to access the user's account       
        public static void AccessingChequingAccount(int pin, string email)
        {
            //LINQ method query to find client based on pin and email matching user's input for pin and email
            var findCustomer = clientAccount.Where(x => x.ClientPin == pin && x.ClientEmail == email);

            //LINQ query to find all records that match user's input of pin and email (used strictly for customer name)
            var custNameQuery = from ca in clientAccount
                           where (ca.ClientEmail == email && ca.ClientPin == pin)
                           select ca;

            //calling on LINQ query to find customer name
            var custName = custNameQuery.First().ClientFirstName;

            //helper variables for later use in the program
            int userChoice;
            int update;
            int tempPinHolder;
            char exitCurrentSelection = 'Y';

            //conditional statement to determine if the rest of program will run
            if (custName != null)
            {
                
                Console.WriteLine($"\nHello, {custName}. Please select one of the following: ");

                
                //do while loop that will runs until the user chooses to exit application
                do
                {   
                    //menu prompt
                    MainMenu();
                    
                    userChoice = Convert.ToInt32(Console.ReadLine());

                    //variable to hold client balance based on the above query
                    var clientBalance = findCustomer.First().Balance;
                    double newAmt;

                    //switch statement for each of the choices in the user account menu
                    switch (userChoice)
                    {
                        //if user chooses option 1 
                        case 1:
                            //prints user's current balance based on today's date
                            Console.WriteLine($"As of {DateTime.Now.ToString("D")}, your current balance is {findCustomer.First().Balance.ToString("C2")}");
                            break;

                        //if user chooses option 2
                        case 2:
                            //gathers user input for withdrawing
                            double withdrawAmt = double.Parse(GatherInput("Enter the amount you would like to withdraw: "));

                            //runs the withdraw amount through the withdraw method from Client account class using LINQ query
                            newAmt = findCustomer.First().WithdrawFromAccount(withdrawAmt, clientBalance);

                            //updates the user's balance to the new amount
                            findCustomer.First().Balance = newAmt;
                            Console.WriteLine($"{withdrawAmt.ToString("C2")} has been withdrawn from your account.");
                            break;

                        //if user chooses option 3
                        case 3:

                            //asks for user input for deposit amount and to confirm their deposit amount
                            double deposit = double.Parse(GatherInput("Enter amount to deposit: "));
                            double confirmDeposit = double.Parse(GatherInput("Confirm the amount to deposit: "));

                            //coditional statement to run upon deposit inputs matching
                            if (deposit >= 0 && deposit == confirmDeposit)
                            {
                                //uses LINQ query to run the deposit method from the client account class for this record
                                newAmt = findCustomer.First().DepositToAccount(deposit, clientBalance);

                                //updates the balance for that particular record using LINQ query
                                findCustomer.First().Balance = newAmt;
                                Console.WriteLine($"{deposit.ToString("C2")} was deposited to your account.");
                            }
                            else
                            {
                                Console.WriteLine("Incorrect deposit amounts. Try again.");
                            }
                            break;

                        //if user chooses option 4
                        case 4:
                            //LINQ query to find account type for that record
                            var accType = findCustomer.First().AccountType;

                            //if account type is not an ultimate account, they have no access to rewards
                            if (accType != "Ultimate Account")
                            {
                                Console.WriteLine("You do not have access to points. Please update your account to Ultimate Account to begin collecting points.");
                            }
                            else
                            {
                                //LINQ query to find the record that matches the pin and email entered by user
                                var pointsQuery = from points in clientAccount
                                                  where (points.ClientEmail == email && points.ClientPin == pin)
                                                  select points;
                                

                                RewardProgram rewards = new RewardProgram();
                                int myRewards = rewards.PointsCalculator(pointsQuery.First().Balance);

                                //uses LINQ querry to find the point balance
                                pointsQuery.First().Points = myRewards;

                                //displays balance to user
                                Console.WriteLine($"Your current points balance is: {pointsQuery.First().Points}");
                            }
                            break;

                        //if user chooses option 5
                        case 5:

                            //confirms with user that they want to close their account
                            char deleteAccount = Convert.ToChar(GatherInput("Are you sure that you want to close your account? [Y]es or [N]o: "));

                            //converted user input to numeric value of char for error handling
                            int convertedDelete = (int)deleteAccount;
                            int choice1 = (int)'y';
                            int choice2 = (int)'Y';

                            //if user input matches numeric value of 'y' or 'Y' they will be removed from the collection
                            if (deleteAccount == choice1 || deleteAccount == choice2)
                            {
                                //removes user based on client email from the client account collection
                                clientAccount.RemoveAll(x => x.ClientEmail == email);
                                Console.WriteLine("Your account has been closed.");
                                exitCurrentSelection = 'Y';

                                //jumps directly to case 8 to return to main menu to prevent error
                                goto case 8;

                            }
                            else
                            {
                                Console.WriteLine("Returning back to the main menu...");
                            }

                            break;

                        //if user chooses option 6
                        case 6:
                            Console.WriteLine("You chose to update your account. Please select one of the following to change");

                            //do while loop to run if the user wants to update their account
                            do
                            {
                                //method to display menu for updating the record
                                UpdateAccount();
                                update = Convert.ToInt32(Console.ReadLine());

                                //LINQ query to find the record based on matching pin and email
                                var updateQuery = from updateAcct in clientAccount
                                                  where (updateAcct.ClientEmail == email && updateAcct.ClientPin == pin)
                                                  select updateAcct;


                                //helper variables to hold temporary variables for updating record
                                string change = "", change2 = "";
                                string addressChange, phoneChange;
                                int tempPin, tempReEnterPin, oldPin, selection;

                                //variables that hold commonly used info based on above LINQ query
                                var firstNameUpdate = updateQuery.First().ClientFirstName;
                                var lastNameUpdate = updateQuery.First().ClientLastName;
                                var customerPin = updateQuery.First().ClientPin;

                                //switch statement to navigate to the correct user choice
                                switch (update)
                                {
                                    //if user chooses option 1, they change their name
                                    case 1: 
                                        Console.WriteLine("Select the: number associated with the change you would like " +
                                            "to make \n\t1. First Name\n\t2. Last Name\n\t3. Both first and last name\n");

                                        selection = Convert.ToInt32(GatherInput("Enter your choice: "));

                                        //confirms that user will change the name by entering pin
                                        tempPin = Convert.ToInt32(GatherInput("Enter your pin to access name change"));

                                        //if user input in matches the one in LINQ collection, they can update their record
                                        if (tempPin == customerPin)
                                        {
                                            //updates first name
                                            if (selection == 1)
                                            {
                                                change = GatherInput("Enter new first name: ");
                                                //updates record using LINQ query
                                                updateQuery.First().ClientFirstName = change;
                                                Console.WriteLine("First name has been updated!");
                                            }
                                            //updates last name
                                            else if (selection == 2)
                                            {
                                                change = GatherInput("Enter new last name: ");
                                                //updates record using LINQ query
                                                updateQuery.First().ClientLastName = change;
                                                Console.WriteLine("First name has been updated!");
                                            }
                                            //updates both first and last name
                                            else if (selection == 3)
                                            {
                                                change = GatherInput("Enter new first name: ");
                                                change2 = GatherInput("Enter new last name: ");
                                                //updates record using LINQ query
                                                updateQuery.First().ClientFirstName = change;
                                                updateQuery.First().ClientLastName = change2;
                                                Console.WriteLine("First and last name has been updated!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid choice");
                                            }
                                        }
                                        else
                                        {
                                            //if pins don't match, error message displayed
                                            Console.WriteLine("Unable to confirm Pin. PLease try again");
                                        }
                                        break;
                                    //email update
                                    case 2: 
                                        tempPin = Convert.ToInt32(GatherInput("Enter your pin to access email change: "));

                                        //if user input in matches the one in LINQ collection, they can update their record
                                        if (tempPin == customerPin)
                                        {
                                            change = GatherInput("Enter your email: ");
                                            //updates record based on LINQ query
                                            updateQuery.First().ClientEmail = change;
                                            Console.WriteLine("Email has been updated!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Unable to validate pin. Please try again.");
                                        }

                                        break;
                                    //address change
                                    case 3: 
                                        tempPin = Convert.ToInt32(GatherInput("Enter your pin to access address change: "));

                                        //if user input in matches the one in LINQ collection, they can update their record
                                        if (tempPin == customerPin)
                                        {
                                            addressChange = GatherInput("Enter new street address: ");
                                            //updates record based on LINQ query
                                            updateQuery.First().ClientAddress = addressChange;
                                            Console.WriteLine("Address has been updated!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Unable to validate pin. PLease try again.");
                                        }

                                        break;
                                    //phone number change
                                    case 4: 
                                        tempPin = Convert.ToInt32(GatherInput("Enter your pin to access phone change: "));

                                        //if user input in matches the one in LINQ collection, they can update their record
                                        if (tempPin == customerPin)
                                        {
                                            phoneChange = GatherInput("Enter new phone in this format: xxx-xxx-xxxx: ");
                                            //updates record based on LINQ query
                                            updateQuery.First().ClientPhone = phoneChange;
                                            Console.WriteLine("Phone has been updated!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Unable to validate pin. PLease try again.");
                                        }
                                        break;

                                    //pin change
                                    case 5: 
                                        oldPin = Convert.ToInt32(GatherInput("Enter your current pin: "));
                                        tempPin = Convert.ToInt32(GatherInput("Enter new pin: "));
                                        tempReEnterPin = Convert.ToInt32(GatherInput("Re-enter new pin to confirm: "));

                                        /*
                                         * if user input in matches the one in LINQ collection, and their new pins match
                                         * record is updated
                                         */
                                        if (tempPin == tempReEnterPin && oldPin == customerPin)
                                        {
                                            //updates record based on LINQ query
                                            updateQuery.First().ClientPin = tempPin;
                                            Console.WriteLine("Pin has been updated!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Unable to validate pin. PLease try again.");
                                        }
                                        break;
                                    //displaying user information
                                    case 6:
                                        tempPin = Convert.ToInt32(GatherInput("Enter your pin to access account info: "));

                                        //if user input in matches the one in LINQ collection, they can update their record
                                        if (tempPin == customerPin)
                                        {
                                            //displaying all info for customer based on LINQ query
                                            Console.WriteLine($"\n\nFirst name: {updateQuery.First().ClientFirstName}");
                                            Console.WriteLine($"Last name: {updateQuery.First().ClientLastName}");
                                            Console.WriteLine($"Account Type: {updateQuery.First().AccountType}");
                                            Console.WriteLine($"Email: {updateQuery.First().ClientEmail}");
                                            Console.WriteLine($"Phone Number: {updateQuery.First().ClientPhone}");
                                            Console.WriteLine($"Address: {updateQuery.First().ClientAddress}\n");
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("Invalid choice.");
                                        break;
                                }
                                Console.WriteLine("Returning to main menu account....");
                              
                               //Console.ReadLine();

                                if (exitCurrentSelection == 'Y' || exitCurrentSelection == 'y')
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            } while (update > 0 && update < 6);
                            break;

                        //if user chooses option 7
                        case 7:
                            tempPinHolder = Convert.ToInt32(GatherInput("Enter your pin to access account info: "));

                            //uses LINQ query to find record of customer based on email and pin input
                            var viewAccountInfo = from updateAcct in clientAccount
                                                  where (updateAcct.ClientEmail == email && updateAcct.ClientPin == pin)
                                                  select updateAcct;

                            //conditional statement displays user info if the pins match collection record
                            if (tempPinHolder == viewAccountInfo.First().ClientPin)
                            {
                                //displaying all info for customer based on LINQ query
                                Console.WriteLine("\n\t------------------Account information-----------------");

                                Console.Write($"\tAccount Number: {viewAccountInfo.First().AccountNumber}\t");
                                Console.WriteLine($"Account Type: {viewAccountInfo.First().AccountType}");
                                Console.WriteLine($"\tMonthly charge for account: {viewAccountInfo.First().MonthlyCharge.ToString("C2")}");

                                Console.WriteLine($"\n\tAccount Holder Name: \t\t{viewAccountInfo.First().ClientFirstName} {viewAccountInfo.First().ClientLastName}");
                                
                                Console.Write($"\tEmail: {viewAccountInfo.First().ClientEmail}\t\t");
                                Console.WriteLine($"Phone Number: {viewAccountInfo.First().ClientPhone}");
                                Console.WriteLine($"\tAddress: {viewAccountInfo.First().ClientAddress}\n");

                            }
                            else
                            {
                                Console.WriteLine("Unable to validate pin number.");
                            }
                            break;

                        //if user chooses option 8
                        case 8:
                            //breaks out of loop
                            exitCurrentSelection = 'Y';
                            break;
                            
                        default:
                            Console.WriteLine("Invalid Choice.");
                            break;

                    }
                    Console.Write("Would you like to make another transaction? (Y)es or (N)o: ");
                    exitCurrentSelection = Convert.ToChar(Console.Read());
                    Console.ReadLine();

                    //breaks out of loop to main menu if the user enters no to another transaction
                    if (exitCurrentSelection == 'N' || exitCurrentSelection == 'n')
                    {
                        Console.WriteLine("Logging you out....\n\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n---------------Please make another selection from the following menu-----------------");
                        continue;
                    }

                //do while loops continues if the user wants to continue transaction
                } while ((int)exitCurrentSelection == (int)'Y' || (int)exitCurrentSelection == (int)'y');
            }
            else
            {
                Console.WriteLine("Sorry. You were not found in the system.");
            }

        }
        //method to generate a random number for the user's account number
        public static long GenerateAccountNumber()
        {
            Random random = new Random();

            //assigns a random number between the given numbers
            long accountNo = (long)random.Next(100000000, 999999999);
            return accountNo;
        }

        //method that displays main menu upon logging in
        public static void MainMenu()
        {

            Console.WriteLine("\t1. Current Balance");
            Console.WriteLine("\t2. Withdraw from account");
            Console.WriteLine("\t3. Deposit to account");
            Console.WriteLine("\t4. Reward Points Balance");
            Console.WriteLine("\t5. Close account");
            Console.WriteLine("\t6. Update my account");
            Console.WriteLine("\t7. View my account info");
            Console.WriteLine("\t8. Exit ATM");
            Console.Write("Enter your choice: ");

        }
        //method that displays atm menu prior to creating account or logging in
        public static void Display()
        {
            Console.WriteLine("\nWelcome. Thank you for choosing Dunder Mifflin-Sabre Bank Partners ATM. Please select one of the following options");
            Console.WriteLine("\t1. Create New Account");
            Console.WriteLine("\t2. Login to my Account");
            Console.WriteLine("\t3. Exit ATM machine");
            Console.Write("Please enter your choice: ");
        }

        //method that displays the 4 different types of accounts
        public static void AccountTypeMenu()
        {
            Console.WriteLine("\t1. Chequing Account");
            Console.WriteLine("\t2. Basic Account");
            Console.WriteLine("\t3. Preferred Package");
            Console.WriteLine("\t4. Ultimate Package");
            
        }
        //method that displays menu for updating your account
        public static void UpdateAccount()
        {
            Console.WriteLine("\t1. Name change");
            Console.WriteLine("\t2. Email change");
            Console.WriteLine("\t3. Address change");
            Console.WriteLine("\t4. Phone change");
            Console.WriteLine("\t5. PIN change");
            Console.WriteLine("\t6. View my information");
            Console.WriteLine("\t7. Back to main menu");
            Console.Write("Enter your choice: ");
        }


        //method that gather new customer information - takes in and returns client account object
        public static ClientAccount GatherNewClientInfo(ClientAccount client)
        {
            //clears buffer
            Console.ReadLine();
            client.ClientFirstName = GatherInput("Please enter your first name: ");
            client.ClientLastName = GatherInput("Please enter your last name: ");
            client.ClientEmail = GatherInput("Enter your email: ");
            client.ClientPhone = GatherInput("Enter your phone number: ");
            client.ClientAddress = GatherInput("Enter your address: ");
           
            //gathers input from user - converts the pin to a integer
            int pin = Convert.ToInt32(GatherInput("Enter a pin: "));
            int reEnterPin = Convert.ToInt32(GatherInput("Re-enter pin: "));

            //loop runs until user inputs 2 matching pins
            while (pin != reEnterPin)
            {
                Console.WriteLine("Pins do not match. Please try again.");
                pin = Convert.ToInt32(GatherInput("Enter a pin: "));
                reEnterPin = Convert.ToInt32(GatherInput("Re-enter pin: "));
            }
            //sets the client pin
            client.ClientPin = pin;
            //sets account number to randomly generated number
            client.AccountNumber = GenerateAccountNumber();
            //asks for deposit amount from user
            client.Balance = double.Parse(GatherInput("Enter the amount you would like to deposit: $"));

            //loop runs until client enters a deposit amount of at least 500 dollars
            do
            {
                if (client.Balance < 500)
                {
                    Console.WriteLine("Unable to deposit. You must deposit an amount of $500 or greater");
                }
            } while (client.Balance < 500);

            return client;
        }
    }
}
