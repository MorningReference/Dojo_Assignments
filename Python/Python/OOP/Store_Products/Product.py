class Product:
    def __init__(self, name, price, category, unique_id):
        self.name = name
        self.price = price
        self.category = category
        self.unique_id = unique_id

    def update_price(self, percent_change, is_increased):
        # self.price += (self.price * percent_change) if is_increased else self.price -= (self.price * percent_change)


        if(is_increased):
            self.price += (self.price * percent_change)
        else:
            self.price -= (self.price * percent_change)
        return self

    def print_info(self):
        print(f"The name of the product is: {self.name}, the category is: {self.category}, and the price is: ${self.price}.")
        return self

    def __repr__(self):
        return f"{self.name}"