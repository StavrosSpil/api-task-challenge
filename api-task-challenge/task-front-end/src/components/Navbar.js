import { Link, useNavigate } from 'react-router-dom';

const Navbar = ( { loggedInUser, setLoggedInUser } ) => {
    const navigate = useNavigate();

    const handleSignOut = () => {
        setLoggedInUser(null)
        navigate('/login');
    }
    return (
        <nav>
           {!loggedInUser &&<Link to='/'>Home</Link>}
           {loggedInUser &&<a onClick={() => handleSignOut()}href=''>Sign Out</a>}
           {!loggedInUser &&<Link to='/login'>Login</Link>}
           {!loggedInUser &&<Link to='/register'>Register</Link>}  
        </nav>
    )
}

export default Navbar;