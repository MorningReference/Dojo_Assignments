import React, { useState } from 'react';

function UserForm(props) {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const [firstNameError, setFirstNameError] = useState('');
    const [lastNameError, setLastNameError] = useState('');
    const [emailError, setEmailError] = useState('');
    const [passwordError, setPasswordError] = useState('');
    const [confirmPasswordError, setConfirmPasswordError] = useState('');

    const handleFirst = (e) => {
        setFirstName(e.target.value);
        if (e.target.value.length < 3 && e.target.value.length >= 1) {
            setFirstNameError('First Name must be at least 2 characters long!');
        } else {
            setFirstNameError('');
        }
    };
    const handleLast = (e) => {
        setLastName(e.target.value);
        if (e.target.value.length < 3 && e.target.value.length >= 1) {
            setLastNameError('Last Name must be at least 2 characters long!');
        } else {
            setLastNameError('');
        }
    };
    const handleEmail = (e) => {
        setEmail(e.target.value);
        if (e.target.value.length < 5 && e.target.value.length >= 1) {
            setEmailError('Email must be at least 5 characters long!');
        } else {
            setEmailError('');
        }
    };
    const handlePassword = (e) => {
        setPassword(e.target.value);
        if (e.target.value.length < 8 && e.target.value.length >= 1) {
            setPasswordError('Password must be at least 8 characters long!');
        } else {
            setPasswordError('');
        }
    };
    const handleConfirmPassword = (e) => {
        setConfirmPassword(e.target.value);
        if (e.target.value.length < 8 && e.target.value.length >= 1) {
            setConfirmPasswordError(
                'Confirm must be at least 8 characters long!'
            );
        } else {
            setConfirmPasswordError('');
        }
    };

    return (
        <div>
            <form>
                <div>
                    <label>First Name:</label>
                    <input type="text" onChange={handleFirst} />
                    {firstNameError ? (
                        <p style={{ color: 'red' }}>{firstNameError}</p>
                    ) : (
                        ''
                    )}
                </div>
                <div>
                    <label>Last Name:</label>
                    <input type="text" onChange={handleLast} />
                    {lastNameError ? (
                        <p style={{ color: 'red' }}>{lastNameError}</p>
                    ) : (
                        ''
                    )}
                </div>
                <div>
                    <label>Email:</label>
                    <input type="text" onChange={handleEmail} />
                    {emailError ? (
                        <p style={{ color: 'red' }}>{emailError}</p>
                    ) : (
                        ''
                    )}
                </div>
                <div>
                    <label>Password:</label>
                    <input type="password" onChange={handlePassword} />
                    {passwordError ? (
                        <p style={{ color: 'red' }}>{passwordError}</p>
                    ) : (
                        ''
                    )}
                </div>
                <div>
                    <label>Confirm Password:</label>
                    <input type="password" onChange={handleConfirmPassword} />
                    {confirmPasswordError ? (
                        <p style={{ color: 'red' }}>{confirmPasswordError}</p>
                    ) : (
                        ''
                    )}
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
