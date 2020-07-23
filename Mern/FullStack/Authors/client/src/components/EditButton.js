import React from 'react';
import { Link } from '@reach/router';

export default (props) => {
    const { authorId } = props;
    return (
        <Link to={`/${authorId}/edit`}>
            <button>Edit</button>
        </Link>
    );
};
