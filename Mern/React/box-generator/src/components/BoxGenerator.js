import React, { useState } from 'react';
import { container, boxStyle } from './Boxes.module.css';

function BoxGenerator() {
    const [color, setColor] = useState('');
    const [dimension, setDimension] = useState(0);
    const [boxes, setBoxes] = useState([]);

    function handleSubmit(event) {
        event.preventDefault();
        const box = {
            color,
            height: dimension + 'px',
            width: dimension + 'px',
        };
        console.log('color is: ', color, 'height and width are: ', dimension);
        setBoxes([...boxes, box]);

        setColor('');
        setDimension(0);
    }

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label>Color</label>
                <input
                    value={color}
                    type="text"
                    onChange={(event) => setColor(event.target.value)}
                />
                <label>Dimension</label>
                <input
                    value={dimension}
                    type="number"
                    onChange={(event) => setDimension(event.target.value)}
                />
                <button type="submit">Submit</button>
            </form>
            <div className={container}>
                {boxes.map((box, idx) => (
                    <div
                        className={boxStyle}
                        key={idx}
                        style={{
                            background: box.color,
                            height: box.height,
                            width: box.width,
                        }}
                    >
                        Here it is
                    </div>
                ))}
            </div>
        </div>
    );
}
export default BoxGenerator;
