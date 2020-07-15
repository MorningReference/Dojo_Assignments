import React, { useState } from 'react';

function Pokemon() {
    const [pokemons, setPokemons] = useState([]);

    function getPokemon() {
        fetch('https://pokeapi.co/api/v2/pokemon?limit=807')
            .then((res) => res.json())
            .then((res) => setPokemons(res.results))
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
