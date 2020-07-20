const ProductController = require('../controllers/product.controller');
module.exports = function (app) {
    app.post('/api/products/new', ProductController.createNewProduct);
    app.get('/api/products', ProductController.findAllProducts);
};
