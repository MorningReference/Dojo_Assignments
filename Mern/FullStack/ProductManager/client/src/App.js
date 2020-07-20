import React from 'react';
import './App.css';
import { Router, Redirect, Link } from '@reach/router';

import NewProduct from './views/NewProduct';
import Products from './views/Products';

function App() {
    return (
        <div className="App">
            <Router>
                <Redirect from="/" to="/products/new" noThrow="true" />
                <NewProduct path="/products/new" />
                {/* <Products path="/products" /> */}
            </Router>
        </div>
    );
}

export default App;
