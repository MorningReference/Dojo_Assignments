class User:

    def __init__(self, username, email_address):
        self.name = username
        self.email = email_address
        self.boa_account = BankAccount(int_rate = 0.02)
        self.chase_account = BankAccount(int_rate = 0.01)
        # self.account = 

        # self.bank_account_list = {bankAccount1, bankAccount2}


    def make_deposit(self, bankAccount, amount):
        if bankAccount == 'boa':
            self.boa_account.balance += amount
            return self
        elif bankAccount == 'chase':
            self.chase_account.balance += amount
            return self


    def make_withdrawl(self, bankAccount, amount):
        if bankAccount == 'boa':
            self.boa_account.balance -= amount
            return self
        elif bankAccount == 'chase':
            self.chase_account.balance -= amount
            return self
    
    def display_user_balance(self, bankAccount):
        if bankAccount == 'boa':
            print(f"User: {self.name}, BOA Balance: {self.boa_account.balance}")
            return self
        elif bankAccount == 'chase':
            print(f"User: {self.name}, Chase Balance: {self.chase_account.balance}")
            return self
        

    # def open_bank_account(self, bankAccount):
    #     self.bank_account_list.append(bankAccount)
    #     return self

    # def transfer_money(self, other_user, amount):
    #     self.account.balance -= amount
    #     other_user.account.balance += amount
    #     return self


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

aric = User('Aric', 'aric@gmail.com')
BoaAccount = BankAccount(0.02)
ChaseAccount = BankAccount(0.01)

# aric.open_bank_account(BoaAccount)

aric.make_deposit('boa', 200).display_user_balance('boa')

aric.make_deposit('chase', 300).make_withdrawl('chase', 30).display_user_balance('chase')
