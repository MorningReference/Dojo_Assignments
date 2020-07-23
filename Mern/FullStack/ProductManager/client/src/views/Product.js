import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { navigate } from '@reach/router';

function Product(props) {
    const [product, setProduct] = useState(null);
    useEffect(() => {
        axios
            .get('http://localhost:8000/api/products/' + props.id)
            .then((res) => {
                console.log(res.data);
                setProduct(res.data);
            })

            .catch(console.log);
    }, []);

    const handleDelete = (delId) => {
        axios
            .delete('http://localhost:8000/api/products/' + delId)
            .then((res) => {
                navigate('/');
            })
            .catch(console.log);
    };

    if (product == null) {
        return <p>The product you are looking for does not exist!</p>;
    }
    return (
        <div key={product._id}>
            <h1>{product.title}</h1>
            <p>Price: {product.price}</p>
            <p>Description: {product.description}</p>
            <button onClick={(e) => navigate(`/${product._id}/edit`)}>
                Edit
            </button>
            <button onClick={(e) => handleDelete(product._id)}>Delete</button>
        </div>
    );
}

export default Product;
