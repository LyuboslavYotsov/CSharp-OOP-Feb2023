using System;
using System.Collections.Generic;

string[] bankAccountsInfo = Console.ReadLine()
    .Split(",");

Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

foreach (string bankAccount in bankAccountsInfo)
{
    string[] accountInfo= bankAccount.Split("-");
    int accountNumber = int.Parse(accountInfo[0]);
    double balance = double.Parse(accountInfo[1]);
    bankAccounts.Add(accountNumber, balance);
}

string command = string.Empty;

while ((command = Console.ReadLine()) != "End")
{
    string[] commandArgs = command.Split(" ");
    string commandType = commandArgs[0];
    int accountNumber = int.Parse(commandArgs[1]);
    double moneyValue = double.Parse(commandArgs[2]);

    try
    {
        if (commandType == "Deposit")
        {
            Deposit(accountNumber, moneyValue);
        }
        else if (commandType == "Withdraw")
        {
            Withdraw(accountNumber, moneyValue);
        }
        else
        {
            throw new ArgumentException("Invalid command!");
        }
        Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}

void Withdraw(int accountNumber, double withdrawValue)
{
    ValidateAccountNumber(accountNumber);
    if (withdrawValue > bankAccounts[accountNumber])
    {
        throw new ArgumentException("Insufficient balance!");
    }
    bankAccounts[accountNumber] -= withdrawValue;
}

void Deposit(int accountNumber, double depositValue)
{
    ValidateAccountNumber(accountNumber);
    bankAccounts[accountNumber] += depositValue;
    
}

void ValidateAccountNumber(int accountNumber)
{
    if (!bankAccounts.ContainsKey(accountNumber))
    {
        throw new ArgumentException("Invalid account!");
    }
}