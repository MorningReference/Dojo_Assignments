import React, { useState, useEffect } from 'react';
import axios from 'axios';

export default function Result(props) {
    const [name, setName] = useState('');
    const [result, setResult] = useState(null);
    const [resultKeys, setResultKeys] = useState([]);

    useEffect(() => {
        axios
            .get('https://swapi.dev/api/' + props.criteria + '/' + props.id)
            .then((res) => {
                setResult(res.data);
                setResultKeys(Object.keys(res.data));
                setName(resultKeys['name']);
            })
            .catch("These aren't the droids you're looking for");
    }, [props.criteria, props.id]);

    return (
        <div>
            <h1>{name}</h1>
            {resultKeys.map((res, idx) => (
                <p key={idx}>
                    <strong>{res}: </strong>
                    {result[res]}
                </p>
            ))}
        </div>
    );
}
