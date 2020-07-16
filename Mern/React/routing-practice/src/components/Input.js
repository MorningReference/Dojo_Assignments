import React, { useState, useEffect } from 'react';

export default function Input(props) {
    const [input, setInput] = useState('');
    const [color, setColor] = useState('');
    const [background, setBackground] = useState('');

    useEffect(() => {
        if (isNaN(+props.input)) {
            setInput('The word is: ' + props.input);
        } else {
            setInput('The number is: ' + props.input);
        }

        if (props.color) {
            setColor(props.color);
        }

        if (props.background) {
            setBackground(props.background);
        }
    }, []);

    return <h1 style={{ color, background }}>{input}</h1>;
}
