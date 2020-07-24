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
let name = '';
let message = [];

io.on('connection', (socket) => {
    console.log('Nice to meet you. (shake hand)');
    connectedClients++;
    console.log(`We have ${connectedClients} clients connected!`);
    socket.emit('new_message_from_server', name, message);

    socket.on('new_message_from_client', (userName, newMessage) => {
        name = userName;
        message.push(newMessage);
        io.emit('new_message_from_server', name, message);
    });

    // socket.on('Welcome', (data) => {
    //     console.log('Welcome!!');
    //     socket.emit('Welcome', 'Suhh dude');
    // });

    socket.on('disconnect', () => {
        connectedClients--;
        console.log(`We have ${connectedClients} clients connected!`);
    });
});
