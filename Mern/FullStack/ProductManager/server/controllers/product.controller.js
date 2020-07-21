const Product = require('../models/product.model');

module.exports.createNewProduct = (req, res) => {
    Product.create(req.body)
        .then((newProduct) => res.json(newProduct))
        .catch((err) =>
            res.json({ message: 'Product could not be added', error: err })
        );
};

module.exports.findAllProducts = (req, res) => {
    Product.find()
        .then((allProducts) => res.json(allProducts))
        .catch((err) =>
            res.json({ message: 'Products could not be loaded', error: err })
        );
};

module.exports.findSingleProduct = (req, res) => {
    Product.findById(req.params.id)
        .then((singleProduct) => res.json(singleProduct))
        .catch((err) =>
            res.json({
                message: 'The product searched, could not be found',
                error: err,
            })
        );
};
