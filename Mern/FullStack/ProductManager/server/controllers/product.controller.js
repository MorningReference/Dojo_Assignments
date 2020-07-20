const Product = require('../models/product.model');

module.exports.createNewProduct = (req, res) => {
    Product.create(req.body)
        .then((newProduct) => res.json({ product: newProduct }))
        .catch((err) =>
            res.json({ message: 'Product could not be added', error: err })
        );
};

module.exports.findAllProducts = (req, res) => {
    Product.find()
        .then((allProducts) => res.json({ products: allProducts }))
        .catch((err) =>
            res.json({ message: 'Products could not be loaded', error: err })
        );
};
