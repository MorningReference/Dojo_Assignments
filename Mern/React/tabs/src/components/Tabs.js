import React, { useState } from 'react';
import { tabContainer, contentContainer } from './Tabs.module.css';

function Tabs(props) {
    // const [tabs, setTabs] = useState([]);
    const array = props.array;
    const [content, setContent] = useState('');

    function handleClick(index, content) {
        setContent(content);
    }
    return (
        <div>
            <div className={tabContainer}>
                {array.map((tab, idx) => (
                    <div
                        className={tabContainer}
                        key={idx}
                        onClick={() => handleClick(idx, tab)}
                    >
                        Tab {idx + 1}
                    </div>
                ))}
            </div>
            <div className={contentContainer}>{content}</div>
        </div>
    );
}
export default Tabs;
