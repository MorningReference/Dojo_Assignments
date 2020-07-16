import React from 'react';
import { Router } from '@reach/router';
// import logo from './logo.svg';
import './App.css';
import Home from './components/Home';
import Input from './components/Input';

function App() {
    return (
        <div className="App">
            <Router>
                <Home path="/home" />
                <Input path="/:input" />
                <Input path="/:input/:color/:background" />
            </Router>
        </div>
    );
}

export default App;
