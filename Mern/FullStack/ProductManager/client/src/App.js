import React from 'react';
import './App.css';
import { Router, Redirect, Link } from '@reach/router';

// import NewProduct from './components/NewProduct';
// import Products from './components/Products';
import Main from './views/Main';
import Product from './views/Product';
import EditProduct from './views/EditProduct';

function App() {
    return (
        <div className="App">
            <Link to="/">Home</Link>
            <Router>
                <Main path="/" />
                <Product path="/:id" />
                <EditProduct path="/:id/edit" />
                {/* <Redirect from="/" to="/products/new" noThrow="true" /> */}
                {/* <NewProduct path="/products/new" />
                <Products path="/products" /> */}
            </Router>
        </div>
    );
}

export default App;
