import Product

class Store:
    def __init__(self, name):
        self.name = name
        self.product_list = []

    def add_product(self, new_product):
        self.product_list.append(new_product)
        return self

    def sell_product(self, unique_id):
        count = 0
        for product in self.product_list:
            if product.unique_id == unique_id:
                nameOfProduct = product.name
                self.product_list.pop(count)
                print(f"{nameOfProduct} was sold!")
            else:
                count += 1
        return self
        # print(f"{self.product_list[unique_id]} was sold!")
        # self.product_list.pop(unique_id)
        # return self

    def inflation(self, percent_increase):
        for product in self.product_list:
            product.update_price(percent_increase, True)
        return self

    def set_clearance(self, category, percent_discount):
        for product in self.product_list:
            product.update_price(percent_discount, False)
        return self
