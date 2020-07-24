import React, { useState, useEffect } from 'react';
import io from 'socket.io-client';
// import logo from './logo.svg';
import './App.css';

function App() {
    const [socket] = useState(() => io(':8000'));

    useEffect(() => {
        console.log('This is running');
        socket.on('welcome', console.log);
        return () => socket.disconnect(true);
    }, [socket]);
    return (
        <div className="App">
            <h1>Socket Test</h1>
        </div>
    );
}

export default App;
