using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTavisca
{
    // Structure contaning all the account details variable
    struct AccountDetails
    {
        public long accountNumber;
        public string accountType;
        public string firstName;
        public string lastName;
        public long phone;
        public int balance;
    }
    class Program
    {
        //Getting index of the object matched through account number
        static int searchAccountId(AccountDetails[] obj)
        {
            Console.WriteLine("Enter Account Number :- ");
            long aNumber = long.Parse(Console.ReadLine());
            for (int index = 1; index <= 5; index++)
            {
                if (obj[index].accountNumber == aNumber)
                {
                    return index;
                }
            }
            return 0;
        }
        //displaying account details of a particular user
        static void checkAccountDetails(AccountDetails[] obj)
        {
            int index = searchAccountId(obj);
            Console.WriteLine("Account Number is :- " + obj[index].accountNumber);
            Console.WriteLine("Account Type is :- " + obj[index].accountType);
            Console.WriteLine("Account Holder's Full name is :- " + obj[index].firstName + " " + obj[index].lastName);
            Console.WriteLine("Account Holder's phone number is :- " + obj[index].phone);
            Console.WriteLine("Balance is :- " + obj[index].balance);
        }
        //function to add money to the user's account
        static void depositMoney(AccountDetails[] obj)
        {
            int index = searchAccountId(obj);
            Console.Write("Enter Amount to Deposit :- ");
            int depositAmount = int.Parse(Console.ReadLine());
            obj[index].balance += depositAmount;
            Console.WriteLine("Current balance is :- {0}", obj[index].balance);
        }
        //function to withdraw money from a particular account!
        static void withdrawMoney(AccountDetails[] obj)
        {
            int index = searchAccountId(obj);
            Console.Write("Enter Amount to Withdraw :- ");
            int withdrawAmount = int.Parse(Console.ReadLine());
            string accType = obj[index].accountType;
            int curBalance,deductedBalance;
            if (accType.Equals("savings"))
            {
                curBalance = obj[index].balance;
                deductedBalance = curBalance - withdrawAmount;
                if (deductedBalance < 1000)
                {
                    Console.WriteLine("Saving Account Minimum Balance is 1000");
                }
                else
                {
                    obj[index].balance -= withdrawAmount;
                }
            }
            else if (accType.Equals("current"))
            {
                curBalance = obj[index].balance;
                deductedBalance = curBalance - withdrawAmount;
                if (deductedBalance < 0)
                {
                    Console.WriteLine("Current Account Minimum Balance is 0");
                }
                else
                {
                    obj[index].balance -= withdrawAmount;
                }
            }
            else
            {
                curBalance = obj[index].balance;
                deductedBalance = curBalance - withdrawAmount;
                if (deductedBalance < -10000)
                {
                    Console.WriteLine("DMAT Account Minimum Balance is -10000");
                }
                else
                {
                    obj[index].balance -= withdrawAmount;
                }
            }
            Console.WriteLine("Current balance is :- {0}", obj[index].balance);
        }
        //Calculating interest of a particular account!
        static void calculateInterest(AccountDetails[] obj)
        {
            int index = searchAccountId(obj);
            int principalAmount = obj[index].balance;
            float simpleInterest=0;
            if (obj[index].accountType.Equals("savings"))
            {
                simpleInterest = (principalAmount * 4 * 1) / 100;
                Console.WriteLine("Interest is :- {0}", simpleInterest);
            }
            else if (obj[index].accountType.Equals("current"))
            {
                simpleInterest = principalAmount * 1 * 1;
                Console.WriteLine("Interest is :- {0}", simpleInterest);
            }
            else
            {
                Console.WriteLine("Interest cannot be appliet on DMAT's Account");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Kindly add 5 Different accounts information! ");
            //Created array of objects
            AccountDetails[] structObject = new AccountDetails[6];
            //getting account details for different object
            for(int index = 1; index <= 5; index++)
            {
                Console.WriteLine("Entering {0} Account Details", index);
                Console.Write("Enter account number :- ");
                structObject[index].accountNumber= long.Parse(Console.ReadLine());
                Console.Write("Enter an account type (savings or current or DMAT account) :- ");
                structObject[index].accountType = Console.ReadLine();
                Console.Write("Enter account holder's first name :- ");
                structObject[index].firstName = Console.ReadLine();
                Console.Write("Enter account holder's last name :- ");
                structObject[index].lastName = Console.ReadLine();
                Console.Write("Enter account holder's phone number :- ");
                structObject[index].phone = long.Parse(Console.ReadLine());
                Console.Write("Enter the balance in the account :- ");
                structObject[index].balance = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }
            int loopStopper = 1; // To stop the do while loop!
            do
            {
                //Asking user to press particular key to perform paticular operations
                Console.Write("Enter \n1 To check Account Details\n2 To deposit money\n3 To withdraw money\n4 Calulate Interest on an account! ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        checkAccountDetails(structObject);
                        break;
                    case 2:
                        depositMoney(structObject);
                        break;
                    case 3:
                        withdrawMoney(structObject);
                        break;
                    case 4:
                        calculateInterest(structObject);
                        break;
                    default:
                        Console.WriteLine("Invalid Entry!");
                        break;

                }
                Console.WriteLine();
                Console.Write("Enter 1 to Continue and 0 To Stop :- ");
                loopStopper = int.Parse(Console.ReadLine());
            }
            while (loopStopper==1);
            Console.ReadKey();
        }
    }
}
