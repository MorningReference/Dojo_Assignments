import React from 'react';
import axios from 'axios';

export default (props) => {
    const { authorId, successCallback } = props;
    const deleteAuthor = (e) => {
        axios
            .delete('http://localhost:8000/api/authors/' + authorId)
            .then((res) => successCallback(res.data._id));
    };
    return <button onClick={deleteAuthor}>Delete</button>;
};
