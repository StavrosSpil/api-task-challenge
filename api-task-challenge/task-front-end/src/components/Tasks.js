import { useNavigate, useLocation } from "react-router-dom";
import { useState, useEffect } from "react";

const Tasks = () => {

    const navigate = useNavigate();
    const { state } = useLocation();
    const [mappings, setMappings] = useState([]);
    const [tasks, setTasks] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7195/mappings')
        .then(res => res.json())
        .then(data => setMappings(data))
    }, [])

    useEffect(() => {
        fetch('https://localhost:7195/tasks')
        .then(res => res.json())
        .then(data => setTasks(data))
    }, [])

    const handleDelete = async (id) => {
        await fetch(`https://localhost:7195/mappings/${id}`,
        {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })

        await fetch('https://localhost:7195/mappings')
        .then(res => res.json())
        .then(data => setMappings(data))
    }

    const handleBack = () => {
        navigate('/dashboard', { state: state})
    }

    return (
        <div className="parent-div">
            <header>
                <h2>Tasks for {state.username} with id: {state.id}</h2>
                    <ul>
                        {mappings.map((mapping, index) => {
                            if (mapping.userId === state.id) {
                                return (
                                    <li className="mapping" key={index}>
                                        <p>
                                            Id : {mapping.id}
                                        </p>
                                        <p>
                                            UserId : {mapping.userId}
                                        </p>
                                        <p>
                                            TaskId : {mapping.toDoItemId}
                                        </p>
                                        <p>
                                            Description : {tasks.map((task) => {
                                                if (mapping.toDoItemId === task.id) {
                                                   return (
                                                    task.descreption
                                                   ) 
                                                }
                                                })
                                            }
                                        </p>
                                    <button className="delete-button" onClick={() => handleDelete(mapping.id)}>Delete Task</button>
                                </li>
                                )
                            }
                    })  }
                </ul>
            </header>
            <button className="back-button" onClick={() => handleBack()}>
                Back
            </button>
        </div>
    )
}

export default Tasks;