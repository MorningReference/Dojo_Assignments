import React, { useState } from 'react';
import Chat from './Chat';

export default function Login() {
    const [name, setName] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log('submitting');
        return <Chat name={name} />;
    };

    return (
        <div>
            <h1>Get started!</h1>
            <form onSubmit={handleSubmit}>
                <label>I want to start chatting with the name...</label>
                <input
                    value={name}
                    type="text"
                    onChange={(e) => setName(e.target.value)}
                />
                <button type="submit">Start Chatting</button>
            </form>
        </div>
    );
}
