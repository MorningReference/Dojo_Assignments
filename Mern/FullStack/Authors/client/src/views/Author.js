import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link, navigate } from '@reach/router';
import EditButton from '../components/EditButton';
import DeleteButton from '../components/DeleteButton';

export default function Author(props) {
    const [author, setAuthor] = useState(null);

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/authors/' + props.id)
            .then((res) => setAuthor(res.data))
            .catch(console.log);
    });

    const redirectToHome = () => {
        navigate('/');
    };

    if (author == null) {
        return <p>The author you are looking for doesn't exist!</p>;
    }

    return (
        <div>
            <h1>{author.name}</h1>
            <Link to="/">Home</Link>
            <p>Quote: {author.quote}</p>
            <div>
                <EditButton authorId={author._id} />
                <DeleteButton
                    authorId={author._id}
                    successCallBack={() => redirectToHome()}
                />
            </div>
        </div>
    );
}
