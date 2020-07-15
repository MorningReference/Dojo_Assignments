import React, { useState } from 'react';
import styles from './TodoList.module.css';
// import 'bootstrap/dist/css/bootstrap.min.css';

function TodoList() {
    const [tasks, setTasks] = useState([]);
    const [isCompleted, setIsCompleted] = useState(false);
    const [newTask, setNewTask] = useState('');

    function handleSubmit(event) {
        event.preventDefault();

        const task = newTask;
        setTasks([...tasks, task]);
        console.log(tasks);

        setNewTask('');
    }

    function handleCompleted(e) {
        setIsCompleted(true);
        e.target.parentElement.classList.toggle(styles.completed);
        console.log(e.target);
        console.log(isCompleted);
    }

    function handleDelete(index) {
        setTasks(tasks.filter((_, idx) => idx !== index));
    }

    return (
        <div>
            <form onSubmit={handleSubmit} className="form">
                <label>
                    <h1>Task</h1>
                </label>
                <input
                    value={newTask}
                    type="text"
                    className="form-control"
                    onChange={(event) => setNewTask(event.target.value)}
                />
                <button type="submit" className="btn btn-primary">
                    Add
                </button>
            </form>
            <div>
                {tasks.map((task, idx) => (
                    <div className="" key={idx}>
                        <span className="">{task}</span>
                        <input
                            type="checkbox"
                            onChange={(e) => handleCompleted(e)}
                        ></input>
                        <button
                            className="btn btn-dark"
                            onClick={() => handleDelete(idx)}
                        >
                            Delete
                        </button>
                    </div>
                ))}
            </div>
        </div>
    );
}
export default TodoList;
