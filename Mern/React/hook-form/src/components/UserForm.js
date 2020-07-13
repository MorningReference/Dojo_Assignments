import React, { useState } from 'react';

function UserForm(props) {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    return (
        <div>
            <form>
                <div>
                    <label>First Name:</label>
                    <input
                        type="text"
                        onChange={(e) => setFirstName(e.target.value)}
                    />
                </div>
                <div>
                    <label>Last Name:</label>
                    <input
                        type="text"
                        onChange={(e) => setLastName(e.target.value)}
                    />
                </div>
                <div>
                    <label>Email:</label>
                    <input
                        type="text"
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <div>
                    <label>Confirm Password:</label>
                    <input
                        type="password"
                        onChange={(e) => setConfirmPassword(e.target.value)}
                    />
                </div>
            </form>
            <p>Your Form Data</p>
            <p>
                <strong>First Name</strong> <span>{firstName}</span>
            </p>
            <p>
                <strong>Last Name</strong> <span>{lastName}</span>
            </p>
            <p>
                <strong>Email</strong> <span>{email}</span>
            </p>
            <p>
                <strong>Password</strong> <span>{password}</span>
            </p>
            <p>
                <strong>Confirm Password</strong> <span>{confirmPassword}</span>
            </p>
        </div>
    );
}
export default UserForm;
