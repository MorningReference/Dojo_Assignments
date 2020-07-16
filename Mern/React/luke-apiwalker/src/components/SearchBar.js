import React, { useState, useEffect } from 'react';
import { navigate } from '@reach/router';
import axios from 'axios';

export default function SearchBar() {
    const [criterias, setCriterias] = useState([]);
    const [selectedCriteria, setSelectedCriteria] = useState('people');
    const [id, setId] = useState(0);

    useEffect(() => {
        axios
            .get('https://swapi.dev/api/')
            .then((res) => setCriterias(Object.keys(res.data)))
            // .then((res) => console.log(Object.keys(res.data)))
            .catch(console.log);
    }, []);

    function handleSubmit(e) {
        e.preventDefault();
        // console.log(selectedCriteria, id);
        navigate('/' + selectedCriteria + '/' + id);
    }

    return (
        <form onSubmit={(e) => handleSubmit(e)}>
            <label>Search for: </label>
            <select
                value={selectedCriteria}
                onChange={(e) => setSelectedCriteria(e.target.value)}
            >
                {criterias.map((criteria, idx) => (
                    <option key={idx} value={criteria}>
                        {criteria}
                    </option>
                ))}
            </select>

            <label>ID: </label>
            <input type="number" onChange={(e) => setId(e.target.value)} />
            <button type="submit">Search</button>
        </form>
    );
}
