import React, { useState, useEffect } from 'react';
import axios from 'axios';

const Products = (props) => {
    const [products, setProducts] = useState(null);

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/products')
            .then((res) => {
                setProducts(res.data);
            })
            .catch(console.log);
    }, []);
    if (products == null) {
        return <p>There are no products available to display!</p>;
    }
    return (
        <div>
            <h1>All Products</h1>

            {products.map((product) => {
                return (
                    <div key={product.id}>
                        <h3>{product.title}</h3>
                        <p>Price: {product.price}</p>
                        <p>Description: {product.description}</p>
                    </div>
                );
            })}
        </div>
    );
};
