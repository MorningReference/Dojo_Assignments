import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, navigate } from '@reach/router';
import AuthorForm from '../components/AuthorForm';

export default function EditAuthor(props) {
    const [name, setName] = useState('');
    const [quote, setQuote] = useState('');
    const [errors, setErrors] = useState([]);
    const [loaded, setLoaded] = useState(false);

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/authors/' + props.id)
            .then((res) => {
                console.log(res.data);
                setName(res.data.name);
                setQuote(res.data.quote);
                setLoaded(true);
            })
            .catch((err) => {
                setErrors(err.response.data.errors);
            });
    }, []);

    // const updateAuthor = (author) => {
    //     axios
    //         .put(`http://localhost:8000/api/authors/${props.id}`, author)
    //         .then((res) => navigate(`/${props.id}`))
    //         .catch((err) => {
    //             console.log(err.response.data);
    //             const errorResponse = err.response.data.errors;
    //             const errorArr = [];
    //             for (const key of Object.keys(errorResponse)) {
    //                 errorArr.push(errorResponse[key].message);
    //             }
    //             console.log(errorArr);
    //             setErrors(errorArr);
    //         });
    // };

    return (
        <div>
            <h1>Favorite Authors</h1>
            <Link to="/">Home</Link>
            <p>Edit this author:</p>
            {console.log(errors)}

            {loaded && (
                <AuthorForm
                    id={props.id}
                    initialName={name}
                    initialQuote={quote}
                    // onSubmitProp={updateAuthor}
                    method="put"
                    url={`http://localhost:8000/api/authors/${props.id}`}
                />
            )}
        </div>
    );
}
