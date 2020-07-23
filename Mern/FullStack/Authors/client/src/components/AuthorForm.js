import React, { useState } from 'react';
import { Link, navigate } from '@reach/router';
import axios from 'axios';

export default (props) => {
    const { initialName, initialQuote, method, url, id } = props;
    const [name, setName] = useState(initialName);
    const [quote, setQuote] = useState(initialQuote);
    const [errors, setErrors] = useState([]);

    const onSubmitHandler = (e) => {
        e.preventDefault();
        // console.log('name: ', name, 'quote: ', quote);
        // onSubmitProp({ name, quote });
        axios[method](url, { name, quote })
            .then((res) => {
                console.log(props);
                console.log('in .then():', res);
                navigate(`/${id}`);
            })
            .catch((err) => {
                console.log('in .catch():', err);
                setErrors(
                    Object.values(err?.response?.data?.errors).map(
                        (val) => val?.properties?.message
                    )
                );
            });
    };

    console.log(errors, props);

    return (
        <>
            {errors.map((err, idx) => (
                <p key={idx} className="text-red">
                    {err}
                </p>
            ))}
            <form className="form" onSubmit={onSubmitHandler}>
                <div className="form-group">
                    <label>Name:</label>
                    <input
                        className="form-control"
                        value={name}
                        type="text"
                        onChange={(e) => setName(e.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label>Quote:</label>
                    <input
                        className="form-control"
                        value={quote}
                        type="text"
                        onChange={(e) => setQuote(e.target.value)}
                    />
                </div>
                <Link to="/">
                    <button className="btn btn-light">Cancel</button>
                </Link>
                <button className="btn btn-primary">Submit</button>
            </form>
        </>
    );
};
