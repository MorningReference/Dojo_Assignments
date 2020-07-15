import React, { useState } from 'react';
import axios from 'axios';

function Pokemon() {
    const [pokemons, setPokemons] = useState([]);

    function getPokemon() {
        axios
            .get('https://pokeapi.co/api/v2/pokemon?limit=807')
            .then((res) => setPokemons(res.data.results))
            .catch(console.log);
    }

    return (
        <div>
            <button onClick={getPokemon}>Fetch Pokemon</button>
            {pokemons.map((pokemon, idx) => (
                <li key={idx}>{pokemon.name}</li>
            ))}
        </div>
    );
}

export default Pokemon;
