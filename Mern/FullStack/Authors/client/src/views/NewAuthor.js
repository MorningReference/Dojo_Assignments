import React, { useState } from 'react';
import axios from 'axios';
import { Link, navigate } from '@reach/router';
import AuthorForm from '../components/AuthorForm';

export default function NewAuthor() {
    const [name, setName] = useState('');
    const [quote, setQuote] = useState('');
    const [errors, setErrors] = useState([]);

    // const createAuthor = (author) => {
    //     axios
    //         .post('http://localhost:8000/api/authors/new', author)
    //         .then((res) => {
    //             console.log(res);
    //             navigate(`/${res.data._id}`);
    //         })
    //         .catch((err) => {
    //             console.log(err.response.data);
    //             const errorResponse = err.response.data.errors;
    //             const errorArr = [];
    //             for (const key of Object.keys(errorResponse)) {
    //                 errorArr.push(errorResponse[key].properties.message);
    //             }
    //             setErrors(errorArr);
    //         });
    // };
    return (
        <div>
            <h1>Favorite Authors</h1>
            <Link to="/">Home</Link>
            <p>Add a new author:</p>
            {/* {errors.map((err, idx) => (
                <p key={idx}>{err}</p>
            ))} */}
            <AuthorForm
                initialName={name}
                initialQuote={quote}
                // onSubmitProp={createAuthor}
                // passedErrors={errors}
                method="post"
                url={`http://localhost:8000/api/authors/new`}
            />
        </div>
    );
}
