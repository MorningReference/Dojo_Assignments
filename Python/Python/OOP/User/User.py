class User:

    def __init__(self, username, email_address):
        self.name = username
        self.email = email_address
        self.account_balance = 0

    def make_deposit(self, amount):
        self.account_balance += amount

    def make_withdrawl(self, amount):
        self.account_balance -= amount
    
    def display_user_balance(self):
        print(f"User: {self.name}, Balance: {self.account_balance}")

    def transfer_money(self, other_user, amount):
        self.account_balance -= amount
        other_user.account_balance += amount

#Create 3 instances of the User class
guido = User("Guido", "guido@gmail.com")
monty = User("Monty", "monty@gmail.com")
aric = User("Aric", "aric@gmail.com")

#Have the first user make 3 deposits and 1 withdrawal and then display their balance
guido.make_deposit(20)
guido.make_deposit(300)
guido.make_deposit(40)
guido.make_withdrawl(70)
guido.display_user_balance()

# Have the second user make 2 deposits and 2 withdrawals and then display their balance
monty.make_deposit(500)
monty.make_deposit(600)
monty.make_withdrawl(200)
monty.make_withdrawl(100)
monty.display_user_balance()

# Have the third user make 1 deposits and 3 withdrawals and then display their balance
aric.make_deposit(10000)
aric.make_withdrawl(20)
aric.make_withdrawl(220)
aric.make_withdrawl(770)
aric.display_user_balance()

# BONUS: Add a transfer_money method; have the first user transfer money to the third user and then print both users' balances
guido.transfer_money(aric, 20)
guido.display_user_balance()
aric.display_user_balance()