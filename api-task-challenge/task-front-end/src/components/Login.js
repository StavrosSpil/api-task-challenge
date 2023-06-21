import React, { useState, useEffect } from "react";
import { useNavigate, Link } from "react-router-dom";

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPass] = useState('');
    const [users, setUsers] = useState([]);

    const navigate = useNavigate();

    useEffect(() => {
        fetch('https://localhost:7195/users')
        .then(res => res.json())
        .then(data => setUsers(data))
    }, []);

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(users)
        for (var i = 0; i < users.length; i++){
            if (users[i].username === username) {
                if (users[i].password === password) {
                    const user = {
                        id: users[i].id,
                        username: users[i].username,
                    }
                    console.log("Correct credentials");
                    navigate("/dashboard", {state: user});
                    return;
                } 
            }
        }
        alert("Wrong credentials");
        setUsername('')
        setPass('')
    }

    return (
        <div className="auth-form-container">
            <div className="form-container">
                <h2>Login</h2>
                <form className="login-form" onSubmit={handleSubmit}>
                    <label htmlFor="username">Username</label>
                    <input value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        type="username" placeholder="username.."
                        id="username"
                        name="username"
                        required
                    />
                    <label htmlFor="password">Password</label>
                    <input value={password}
                        onChange={(e) => setPass(e.target.value)}
                        type="password"
                        placeholder="********"
                        id="password"
                        name="password"
                        required
                    />
                    <button className="link-btn" type="submit">Log In</button>
                </form>
                <Link to={'/register'}>                   
                    Don't have an account? Register here.
                </Link>
            </div>
        </div>
    )
}

export default Login;