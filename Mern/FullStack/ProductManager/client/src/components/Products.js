import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, navigate } from '@reach/router';

function Products() {
    const [allProducts, setAllProducts] = useState(null);

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/products')
            .then((res) => {
                setAllProducts(res.data);
            })
            .catch(console.log);
    }, []);

    const handleDelete = (delId) => {
        axios
            .delete('http://localhost:8000/api/products/' + delId)
            .then((res) => {
                const filteredProducts = allProducts.filter((product) => {
                    return product._id !== delId;
                });
                setAllProducts(filteredProducts);
            })
            .catch(console.log);
    };

    if (allProducts == null) {
        return <p>There are no products available to display!</p>;
    }
    return (
        <div>
            <h1>All Products</h1>

            {allProducts.map((product) => {
                return (
                    <div key={product._id}>
                        <Link to={product._id}>
                            <h3>{product.title}</h3>
                        </Link>
                        <button
                            onClick={(e) => navigate(`/${product._id}/edit`)}
                        >
                            Edit
                        </button>
                        <button onClick={(e) => handleDelete(product._id)}>
                            Delete
                        </button>
                    </div>
                );
            })}
        </div>
    );
}

export default Products;
