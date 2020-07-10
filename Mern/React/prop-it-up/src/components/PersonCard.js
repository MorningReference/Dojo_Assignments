import React from 'react';

class PersonCard extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            age: this.props.age,
        };
    }

    addAge = () => {
        this.setState({ age: parseInt(this.state.age) + 1 });
    };

    render() {
        const { firstName, lastName, hairColor } = this.props;
        const age = this.state.age;
        return (
            <div className="PersonCard">
                <h1>
                    {firstName}, {lastName}
                </h1>
                <p>Age: {age}</p>
                <p>Hair Color: {hairColor}</p>
                <button onClick={this.addAge}>
                    Birthday Button for {firstName} {lastName}
                </button>
            </div>
        );
    }
}

export default PersonCard;
