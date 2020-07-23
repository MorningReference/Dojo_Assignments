import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { navigate } from '@reach/router';

function EditProduct(props) {
    const [title, setTitle] = useState('');
    const [price, setPrice] = useState(0.0);
    const [description, setDescription] = useState('');

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/products/' + props.id)
            .then((res) => {
                setTitle(res.data.title);
                setPrice(res.data.price);
                setDescription(res.data.description);
            })
            .catch(console.log);
    }, []);

    const handleSubmit = (e) => {
        e.preventDefault();

        const editedProduct = {
            title,
            price,
            description,
        };

        axios
            .put(
                'http://localhost:8000/api/products/' + props.id,
                editedProduct
            )
            .then((res) => {
                console.log(props.id);
                navigate(`/${props.id}`);
            })
            .catch(console.log);
    };

    return (
        <form onSubmit={(e) => handleSubmit(e)}>
            <h1>{title}</h1>
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
            <button type="submit">Update</button>
        </form>
    );
}

export default EditProduct;
