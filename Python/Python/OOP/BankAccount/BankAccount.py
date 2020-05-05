class BankAccount:
    def __init__(self, int_rate, balance = 0):
        self.balance = balance
        self.int_rate = int_rate
    def deposit(self, amount):
        self.balance += amount
        return self
    def withdraw(self, amount):
        self.balance -= amount
        return self
    def display_account_info(self):
        print(f"Balance: {self.balance}")
        return self
    def yield_interest(self):
        self.balance = self.balance + (self.balance * self.int_rate)
        return self

#Create 2 accounts
accountNoBalance = BankAccount(0.02)
accountWithBalanace = BankAccount(0.03, 500)

#To the first account, make 3 deposits and 1 withdrawal, then yield interest and display the account's info all in one line of code (i.e. chaining)
accountNoBalance.deposit(200).deposit(30).deposit(50).withdraw(100).yield_interest().display_account_info()

#To the second account, make 2 deposits and 4 withdrawals, then yield interest and display the account's info all in one line of code (i.e. chaining)
accountWithBalanace.deposit(5000).deposit(60).withdraw(700).withdraw(300).withdraw(20).yield_interest().display_account_info()
