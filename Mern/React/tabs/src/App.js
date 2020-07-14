import React from 'react';
import logo from './logo.svg';
import './App.css';
import Tabs from './components/Tabs';

function App() {
    return (
        <div>
            <link
                rel="stylesheet"
                href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"
                integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk"
                crossorigin="anonymous"
            ></link>
            <Tabs array={[1, 2, 3, 4, 5, 6, 7, 8, 9]}></Tabs>
            <Tabs array={['Python', 'C#', 'Mern', 'WebFun']}></Tabs>
            <Tabs array={['Yellow', 'Blue', 'Green', 'Red']}></Tabs>
        </div>
    );
}

export default App;
