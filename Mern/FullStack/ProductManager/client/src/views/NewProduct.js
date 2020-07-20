import React, { useState } from 'react';
import axios from 'axios';
import { navigate } from '@reach/router';

function NewProduct() {
    const [title, setTitle] = useState('');
    const [price, setPrice] = useState(0.0);
    const [description, setDescription] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();

        const newProduct = {
            title,
            price,
            description,
        };

        axios
            .post('http://localhost:8000/api/products/new', newProduct)
            .then((res) => {
                console.log(res);
                navigate('/products');
            });
    };

    return (
        <form onSubmit={(e) => handleSubmit(e)}>
            <h1>Product Manager</h1>
            <label>Title: </label>
            <input
                value={title}
                type="text"
                onChange={(e) => setTitle(e.target.value)}
            />

            <label>Price: </label>
            <input
                value={price}
                type="number"
                onChange={(e) => setPrice(+e.target.value)}
            />

            <label>Description: </label>
            <input
                value={description}
                type="text"
                onChange={(e) => setDescription(e.target.value)}
            />
            <button type="submit">Create</button>
        </form>
    );
}

export default NewProduct;
