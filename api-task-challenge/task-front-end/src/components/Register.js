import React, { useState, useEffect } from "react";
import { useNavigate, Link } from "react-router-dom";
import axios from 'axios';

const Register = (props) => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [username, setUsername] = useState('');
    const [users, setUsers] = useState([]);

    const userUrl = 'https://localhost:7195/users';
    const navigate = useNavigate();

    useEffect(() => {
        fetch('https://localhost:7195/users')
        .then(res => res.json())
        .then(data => setUsers(data))
    }, [users]);

    const handleSubmit = async (e) => {
        let flag = false;
        e.preventDefault();
        if ( users.length === 0) {
            const data = {
                Username: username,
                Password: password,
                Email: email
            };

            axios.post(userUrl, data).then(res => {
                console.log(res.data);
            });
            navigate('/login');
        } else {
            for (var i = 0; i < users.length; i++) {
                if (users[i].username === username) {
                    flag = true;
                    break;
                }
            }
        }

        if (flag === false) {
            const data = {
                Username: username,
                Password: password,
                Email: email
            };

            await axios.post(userUrl, data).then(res => {
                console.log(res.data);
            });
            console.log(users)
            navigate('/login');
        } else {
            alert("Wrong credentials");
            setUsername('');
            setEmail('');
            setPassword('');
        }
    }

    return (
        <div className="auth-form-container">
            <div className="form-container">
                <h2>Register</h2>
                <form className="register-form" onSubmit={handleSubmit}>
                    <label htmlFor="username">Username</label>
                    <input value={username} name="username" onChange={(e) => setUsername(e.target.value)} id="username" placeholder="Username" />
                    <label htmlFor="email">Email</label>
                    <input value={email} onChange={(e) => setEmail(e.target.value)}type="email" placeholder="youremail@gmail.com" id="email" name="email" />
                    <label htmlFor="password">Password</label>
                    <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" placeholder="********" id="password" name="password" />
                    <button className="link-btn" type="submit">Create Account</button>
                </form>
                <Link to='/login'>
                    Already have an account? Login here.
                </Link>
            </div>
        </div>
    )
}

export default Register;
