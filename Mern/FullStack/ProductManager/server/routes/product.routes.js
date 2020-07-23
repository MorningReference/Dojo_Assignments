const ProductController = require('../controllers/product.controller');
module.exports = function (app) {
    app.post('/api/products/new', ProductController.createNewProduct);
    app.get('/api/products', ProductController.findAllProducts);
    app.get('/api/products/:id', ProductController.findSingleProduct);
    app.put('/api/products/:id', ProductController.updateExistingProduct);
    app.delete('/api/products/:id', ProductController.deleteProduct);
};
