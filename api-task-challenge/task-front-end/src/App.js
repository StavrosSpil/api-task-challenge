
import './App.css';
import { Routes, Route } from 'react-router-dom'
import Home from "./components/Home";
import Login from "./components/Login";
import Register from "./components/Register";
import Navbar from "./components/Navbar";
import CreateTask from "./components/CreateTask";
import Tasks from "./components/Tasks";
import AddTask from "./components/AddTask";
import Dashboard from "./components/Dashboard";


function App() {

  return ( 
    <>
      <Navbar />
      <main>
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/login' element={<Login />} />
        <Route path='/register' element={<Register />} />
        <Route path='/dashboard' element={<Dashboard />} />
        <Route path='/createTask' element={<CreateTask />} />
        <Route path='/addTask' element={<AddTask />} />
        <Route path='/tasks' element={<Tasks />} />
      </Routes>
      </main>
    </>
  );
}

export default App;