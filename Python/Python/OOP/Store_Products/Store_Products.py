import Store
import Product

# class Store:
#     def __init__(self, name):
#         self.name = name
#         self.product_list = []

#     def add_product(self, new_product):
#         self.product_list.append(new_product)
#         return self

#     def sell_product(self, id):
#         print(f"{self.product_list[id]} was sold!")
#         self.product_list.pop(id)
#         return self

#     def inflation(self, percent_increase):
#         for product in self.product_list:
#             product.update_price(percent_increase, True)
#         return self

#     def set_clearance(self, category, percent_discount):
#         for product in self.product_list:
#             product.update_price(percent_discount, False)
#         return self


# class Product:
#     def __init__(self, name, price, category):
#         self.name = name
#         self.price = price
#         self.category = category

#     def update_price(self, percent_change, is_increased):
#         # self.price += (self.price * percent_change) if is_increased else self.price -= (self.price * percent_change)
#         if(is_increased):
#             self.price += (self.price * percent_change)
#         else:
#             self.price -= (self.price * percent_change)
#         return self

#     def print_info(self):
#         print(f"The name of the product is: {self.name}, the category is: {self.category}, and the price is: ${self.price}.")
#         return self

#     def __repr__(self):
#         return f"{self.name}"



ralphs = Store.Store('Ralphs')
rice = Product.Product('rice', 10, 'grains', 1234)
steak = Product.Product('steak', 30, 'meats', 2345)
rosemary = Product.Product('rosemary', 3, 'herbs', 3456)


ralphs.add_product(rice).add_product(steak).add_product(rosemary)
rice.print_info()
steak.print_info()
rosemary.print_info()
print(ralphs.product_list)

ralphs.inflation(0.25)
rice.print_info()
steak.print_info()
rosemary.print_info()

ralphs.set_clearance('meats',0.1)
steak.print_info()

ralphs.sell_product(3456)
print(ralphs.product_list)

