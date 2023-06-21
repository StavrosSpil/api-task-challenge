import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import axios from "axios";

const AddTask = () => {

    const getTasksUrl = 'https://localhost:7195/tasks';

    const [tasks, setTasks] = useState([]);
    const userTasks = [];
    let availableTasks = [];
    const [mappings, setMappings] = useState([]);
    const { state } = useLocation();
    const navigate = useNavigate();

    const initialize = () => {
        mappings.map(mapping => {
            if (state.id === mapping.userId ) {
                tasks.map(task => {
                    if (mapping.toDoItemId === task.id) {
                        userTasks.push(task);
                    }
                })
            }
        })
        availableTasks = tasks.filter((item) => ! userTasks.includes(item))
    }

    useEffect(() => {
        fetch(getTasksUrl)
        .then(res => res.json())
        .then(data => setTasks(data))
    }, [])

    useEffect(() => {
        fetch('https://localhost:7195/mappings')
        .then(res => res.json())
        .then(data => setMappings(data))
    }, [])

    const handleAdd = async (taskId) => {
        const mapping = {
            Completed: false,
            UserId: state.id,
            ToDoItemId: taskId
        }

        axios.post('https://localhost:7195/mappings', mapping).then(res => {
            console.log(res);
        })
    }

    const handleDelete = async (id) => {
        await fetch(`https://localhost:7195/tasks/${id}`,
            {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                }
            })

        await fetch(getTasksUrl)
        .then(res => res.json())
        .then(data => setTasks(data))
    }

    const handleBack = () => {
        navigate('/dashboard', { state: state})
    }

    return (
        <div className="parent-div">
            {initialize()}
            <header>
                <h2>Available Tasks</h2>
            </header>
            {availableTasks.map((task, index) => {
                return (
                    <li className="task" key={index}>
                        <p>
                            Id: {task.id}
                        </p>
                        <p>
                            Description: {task.descreption}
                        </p>
                        <button className="action-button" onClick={() => handleAdd(task.id)}>Add Task</button>
                        <button className="delete-button" onClick={() => handleDelete(task.id)}>Delete Task</button>
                    </li>
                )
            })}
            <button className="back-button" onClick={() => handleBack()}>
                Back
            </button>
        </div>
    )
}

export default AddTask;