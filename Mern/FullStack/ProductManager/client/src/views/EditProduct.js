import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { navigate } from '@reach/router';
import ProductForm from '../components/ProductForm';

function EditProduct(props) {
    const [title, setTitle] = useState('');
    const [price, setPrice] = useState(0.0);
    const [description, setDescription] = useState('');
    const [loaded, setLoaded] = useState(false);

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/products/' + props.id)
            .then((res) => {
                setTitle(res.data.title);
                setPrice(res.data.price);
                setDescription(res.data.description);
                setLoaded(true);
            })
            .catch(console.log);
    }, []);

    const updateProduct = (product) => {
        axios
            .put('http://localhost:8000/api/products/' + props.id, product)
            .then((res) => {
                navigate(`/${props.id}`);
            })
            .catch(console.log);
    };

    return (
        <div>
            {loaded && (
                <ProductForm
                    onSubmitProp={updateProduct}
                    initialTitle={title}
                    initialPrice={price}
                    initialDescription={description}
                />
            )}
        </div>
    );
}

export default EditProduct;
