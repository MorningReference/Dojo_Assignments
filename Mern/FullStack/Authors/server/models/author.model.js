const mongoose = require('mongoose');

const AuthorSchema = new mongoose.Schema(
    {
        name: {
            type: String,
            required: [true, "Author's name is required"],
            minlength: [3, 'The name must be 3 characters or longer'],
        },
        quote: {
            type: String,
            required: [true, "Author's quote is required"],
            minlength: [3, 'The quote must be 3 characters or longer'],
        },
    },
    { timestamps: true }
);

const Author = mongoose.model('author', AuthorSchema);
module.exports = Author;
