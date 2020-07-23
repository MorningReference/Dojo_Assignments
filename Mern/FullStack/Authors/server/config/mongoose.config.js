const mongoose = require('mongoose');

mongoose
    .connect(`mongodb://localhost/authors`, {
        useNewUrlParser: true,
        useUnifiedTopology: true,
        useFindAndModify: false,
    })
    .then(() => console.log(`Successfully connected to authors database`))
    .catch((err) => console.log('mongoose connection failed: ', err));
