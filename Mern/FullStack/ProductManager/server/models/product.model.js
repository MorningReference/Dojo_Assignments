const mongoose = require('mongoose');

const ProductSchema = new mongoose.Schema(
    {
        title: { type: String },
        price: { type: Number },
        description: { type: String },
    },
    { timestampes: true }
);

const Product = mongoose.model('product', ProductSchema);

module.exports = Product;
