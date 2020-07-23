const AuthorController = require('../controllers/author.controller');
module.exports = function (app) {
    app.post('/api/authors/new', AuthorController.createNewAuthor);
    app.get('/api/authors', AuthorController.findAllAuthors);
    app.get('/api/authors/:id', AuthorController.findSingleAuthor);
    app.put('/api/authors/:id', AuthorController.updateExistingAuthor);
    app.delete('/api/authors/:id', AuthorController.deleteAuthor);
};
