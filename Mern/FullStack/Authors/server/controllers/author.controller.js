const Author = require('../models/author.model');
const { json } = require('express');

module.exports.createNewAuthor = (req, res) => {
    Author.create(req.body)
        .then((newAuthor) => res.json(newAuthor))
        .catch((err) => res.status(400).json(err));
};

module.exports.findAllAuthors = (_, res) => {
    Author.find()
        .sort('name')
        .then((allAuthors) => res.json(allAuthors))
        .catch((err) => res.status(400).json(err));
};

module.exports.findSingleAuthor = (req, res) => {
    Author.findById(req.params.id)
        .then((singleAuthor) => res.json(singleAuthor))
        .catch((err) => res.status(400).json(err));
};

module.exports.updateExistingAuthor = (req, res) => {
    // console.log('*****************************');
    // console.log('updating existing author');
    console.log(req);
    Author.findById(req.params.id)
        .then((author) => {
            // console.log('*****');
            // console.log('found author with id ' + req.params.id);
            author
                .updateOne(req.body, { runValidators: true })
                .then((status) => res.json(status))
                .catch((err) => res.status(400).json(err));
        })
        .catch((err) => {
            // console.log('IN AUTHOR.FINDBYID.CATCH');
            console.log(res);
            res.status(400).json(err);
        });
};

module.exports.deleteAuthor = (req, res) => {
    Author.findById(req.params.id)
        .then((author) => {
            author
                .remove()
                .then((removedAuthor) => {
                    res.json(removedAuthor);
                })
                .catch((err) => json(err));
        })
        .catch((err) => res.status(400).json(err));
};
