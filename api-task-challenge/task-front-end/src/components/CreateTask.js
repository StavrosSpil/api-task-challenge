import { useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import axios from 'axios';

const CreateTask = () => {

    const [descreption, setDescreption] = useState('')
    const taskUrl = 'https://localhost:7195/tasks';
    const { state } = useLocation();
    const navigate = useNavigate();


    const handleCreateTask = async (e) => {
        e.preventDefault();
        const data = {
            Descreption: descreption
        }
        axios.post(taskUrl, data).then(res => {
            console.log(res.data);
        });

        setDescreption('');
    }

    const handleBack = () => {
        navigate('/dashboard', { state: state})
    }

    return (
        <div className="parent-div">
            <form className="create-task-form" onSubmit={handleCreateTask}>
                <h2>Create A Task</h2>
                <label htmlFor="Descreption">Description : </label>
                <input id="Descreption" 
                    name="Descreption" 
                    type="text"  
                    onChange={(e) => {setDescreption(e.target.value)}} 
                    value={descreption}
                    required>
                </input>

                <div className="action-section">
                    <button className="action-button" type="submit" >
                        Create Task
                    </button>
                    <button className="back-button" onClick={() => handleBack()}>
                        Back
                    </button>
                    </div>
            </form>
        </div>
    )
}

export default CreateTask;