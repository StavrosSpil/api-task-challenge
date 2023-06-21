import { useNavigate, useLocation } from "react-router-dom";

const Dashboard = () => {

    const { state } = useLocation();
    const navigate = useNavigate();

    const handleAddTask = () => {
        navigate('/addTask', {state: state});
    }

    const handleSeeYourTasks = () => {
        navigate('/tasks', {state: state});
    }

    const handleCreateTask = () => {
        navigate('/createTask', {state: state})
    }

    return (
        <div className="parent-dashboard">
            <div className="dashboard">
                <button className="action-button" onClick={() => handleSeeYourTasks()}>
                    See your tasks
                </button>
                <button className="action-button" onClick={() => handleCreateTask()}>
                    Create a task
                </button>
                <button className="action-button" onClick={() => handleAddTask()}>
                    Add a task
                </button>
            </div>
        </div>
    )
}

export default Dashboard;