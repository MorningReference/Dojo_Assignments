import React from 'react';
import { Router } from '@reach/router';
import './App.css';
import SearchBar from './components/SearchBar';
import Result from './components/Result';

function App() {
    return (
        <div className="App">
            <SearchBar />
            <Router>
                <Result path="/:criteria/:id" />
            </Router>
        </div>
    );
}

export default App;
