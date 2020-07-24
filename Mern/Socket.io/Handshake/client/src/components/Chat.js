import React, { useState, useEffect } from 'react';
import io from 'socket.io-client';

export default function Chat(props) {
    const [name] = useState(props.name);
    const [messages, setMessages] = useState([]);
    const [message, setMessage] = useState('');
    const [socket] = useState(() => io(':8000'));

    useEffect(() => {
        socket.on('new_message_from_server', (msg) => {
            console.log('This is in useEffect: ', msg);
            setMessages((prevMessages) => {
                console.log('In set messages: ', prevMessages);
                return [msg, ...prevMessages];
            });
        });
    }, [socket]);

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log('This is handleSubmit: ', name, message);
        socket.emit('new_message_from_client', { name, message });
        setMessage('');
    };

    return (
        <div>
            <div>
                {messages.map((message, idx) => {
                    console.log('in return:', message);
                    return (
                        <div key={idx}>
                            <p>{message.name}</p>
                            <p>{message.message}</p>
                        </div>
                    );
                })}
            </div>
            <form onSubmit={handleSubmit}>
                <input
                    value={message}
                    type="text"
                    onChange={(e) => setMessage(e.target.value)}
                />
                <button type="submit">Send</button>
            </form>
        </div>
    );
}
