const port = 8000;
const express = require('express');
const cors = require('cors');
const { connect } = require('mongoose');
const app = express();

// require('./server/config/mongoose.config');
app.use(express.json());
app.use(cors());
app.use(express.urlencoded({ extended: true }));

// require('./server/routes/author.routes')(app);

const server = app.listen(port, () => {
    console.log(`Listening on port ${port}`);
});

const io = require('socket.io')(server);
let connectedClients = 0;

io.on('connection', (socket) => {
    console.log('Nice to meet you. (shake hand)');
    connectedClients++;
    console.log(`We have ${connectedClients} clients connected!`);
    socket.emit('welcome', 'Thanks for coming');

    // socket.on('Welcome', (data) => {
    //     console.log('Welcome!!');
    //     socket.emit('Welcome', 'Suhh dude');
    // });

    socket.on('disconnect', () => {
        connectedClients--;
        console.log(`We have ${connectedClients} clients connected!`);
    });
});
