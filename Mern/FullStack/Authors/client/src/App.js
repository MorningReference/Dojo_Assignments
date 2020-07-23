import React from 'react';
// import './App.css';
import { Router } from '@reach/router';
import Authors from './views/Authors';
import NewAuthor from './views/NewAuthor';
import Author from './views/Author';
import EditAuthor from './views/EditAuthor';

function App() {
    return (
        <div className="App">
            <Router>
                <Authors path="/" />
                <NewAuthor path="/new" />
                <Author path="/:id" />
                <EditAuthor path="/:id/edit" />
            </Router>
        </div>
    );
}

export default App;
