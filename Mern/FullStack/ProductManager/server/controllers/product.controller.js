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

module.exports.updateExistingProduct = (req, res) => {
    Product.findOneAndUpdate({ _id: req.params.id }, req.body, { new: true })
        .then((updatedProduct) => res.json(updatedProduct))
        .catch((err) => res.status(400).json(err));

    // Product.findById(req.params.id)
    //     .then((product) => {
    //         product.updateOne(req.body).then((status) => res.json(status));
    //     })
    //     .catch((err) => res.json(err));
};

module.exports.deleteProduct = (req, res) => {
    Product.findByIdAndDelete(req.params.id)
        .then((productToDelete) => res.json(productToDelete))
        .catch((err) =>
            res.json({
                message: 'The product to delete does not exist',
                error: err,
            })
        );
};
