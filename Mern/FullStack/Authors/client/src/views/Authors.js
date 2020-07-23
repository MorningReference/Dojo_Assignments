import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from '@reach/router';
import EditButton from '../components/EditButton';
import DeleteButton from '../components/DeleteButton';

export default function Authors() {
    const [allAuthors, setAllAuthors] = useState(null);

    useEffect(() => {
        axios
            .get('http://localhost:8000/api/authors')
            .then((res) => {
                setAllAuthors(res.data);
            })
            .catch(console.log);
    }, []);

    const removeFromDom = (delId) => {
        setAllAuthors(allAuthors.filter((author) => author._id !== delId));
    };

    if (allAuthors == null) {
        // return (
        //     <>
        //         <h1>Favorite Authors</h1>
        //         <Link to="/new">Add an author</Link>
        //     </>
        // );

        return <p>No authors for you</p>;
    }
    return (
        <div>
            <h1>Favorite Authors</h1>
            <Link to="/new">Add an author</Link>
            <p>We have quotes by:</p>
            <table className="table">
                <thead>
                    <tr>
                        <th scopt="col">Author</th>
                        <th scopt="col">Actions available</th>
                    </tr>
                </thead>
                <tbody>
                    {allAuthors.map((author) => {
                        return (
                            <tr key={author._id}>
                                <td>
                                    <Link to={`/${author._id}`}>
                                        {author.name}
                                    </Link>
                                </td>
                                <td>
                                    <EditButton authorId={author._id} />{' '}
                                    <DeleteButton
                                        authorId={author._id}
                                        successCallback={() =>
                                            removeFromDom(author._id)
                                        }
                                    />
                                </td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
}
