class User:

    def __init__(self, username, email_address):
        self.name = username
        self.email = email_address
        self.account_balance = 0

    def make_deposit(self, amount):
        self.account_balance += amount
        return self

    def make_withdrawl(self, amount):
        self.account_balance -= amount
        return self
    
    def display_user_balance(self):
        print(f"User: {self.name}, Balance: {self.account_balance}")
        return self

    def transfer_money(self, other_user, amount):
        self.account_balance -= amount
        other_user.account_balance += amount
        return self

#Create 3 instances of the User class
guido = User("Guido", "guido@gmail.com")
monty = User("Monty", "monty@gmail.com")
aric = User("Aric", "aric@gmail.com")

#Have the first user make 3 deposits and 1 withdrawal and then display their balance
guido.make_deposit(20).make_deposit(300).make_deposit(40).make_withdrawl(70).display_user_balance()

# Have the second user make 2 deposits and 2 withdrawals and then display their balance
monty.make_deposit(500).make_deposit(600).make_withdrawl(200).make_withdrawl(100).display_user_balance()

# Have the third user make 1 deposits and 3 withdrawals and then display their balance
aric.make_deposit(10000).make_withdrawl(20).make_withdrawl(220).make_withdrawl(770).display_user_balance()

# BONUS: Add a transfer_money method; have the first user transfer money to the third user and then print both users' balances
guido.transfer_money(aric, 20).display_user_balance()
aric.display_user_balance()