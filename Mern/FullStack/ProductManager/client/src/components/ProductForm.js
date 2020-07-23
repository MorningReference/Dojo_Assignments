import React, { useEffect, useState } from 'react';
import axios from 'axios';

export default (props) => {
    const {
        initialTitle,
        initialPrice,
        initialDescription,
        onSubmitProp,
    } = props;
    const [title, setTitle] = useState(initialTitle);
    const [price, setPrice] = useState(initialPrice);
    const [description, setDescription] = useState(initialDescription);
    const onSubmitHandler = (e) => {
        e.preventDefault();
        onSubmitProp({ title, price, description });
    };

    return (
        <form onSubmit={onSubmitHandler}>
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
            {/* <button type="submit">Update</button> */}
            <input type="submit" />
        </form>
    );
};
