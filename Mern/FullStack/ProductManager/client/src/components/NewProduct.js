import React, { useState } from 'react';
import axios from 'axios';
import { navigate } from '@reach/router';
import ProductForm from './ProductForm';

function NewProduct() {
    const [title, setTitle] = useState('');
    const [price, setPrice] = useState(0.0);
    const [description, setDescription] = useState('');

    const createProduct = (product) => {
        axios
            .post('http://localhost:8000/api/products/new', product)
            .then((res) => {
                console.log(res);
                navigate(`/${res.data._id}`);
            });
    };

    return (
        <ProductForm
            onSubmitProp={createProduct}
            initialTitle={title}
            initialPrice={price}
            initialDescription={description}
        />
    );
}

export default NewProduct;
