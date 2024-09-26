import './EditAnimalForm.css';
import { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';


function EditAnimalForm() {
    const {animalId} = useParams(); 
    const navigate = useNavigate();
    const [updatedAnimal, setUpdatedAnimal] = useState({
        name: '',
        species: '',
        age: '',
        dateOfBirth: '',
        ownerId:''
    });

    useEffect(() => {
        axios.get(`http://localhost:5135/api/Animal/${animalId}`)
        .then(response => {
            setUpdatedAnimal(response.data)
        })
        .catch(error => {
            console.error('Error:', error)
        })
    }, [animalId])


    function handleEditInputChange(e) {
        setUpdatedAnimal({ ...updatedAnimal, [e.target.name]: e.target.value });
    }

    function handleEditFormSubmit(e) {
        e.preventDefault();
        handleUpdateAnimal(animalId, updatedAnimal);
      }

    function handleUpdateAnimal(animalId, updatedAnimal) {
        axios.put(`http://localhost:5135/api/Animal/${animalId}`, updatedAnimal)
        .then(response => {
            alert('Animal Updated');
        })
        .catch(error => {
            console.log('Error:', error)
        })
      }

    return (
        <>    
        <button className='homeBTN' onClick={() => navigate('/')}>Back</button>   
         <form onSubmit={handleEditFormSubmit}>
            <h2>UpdateAnimal</h2>
            <label>
                Name:{' '}
                <input
                    name="name"
                    value={updatedAnimal.name}
                    onChange={handleEditInputChange}
                />
            </label>
            <br />
            <label>
                Species:{' '}
                <input
                    name="species"
                    value={updatedAnimal.species}
                    onChange={handleEditInputChange}
                />
            </label>
            <br />
            <label>
                Age:{' '}
                <input
                    name="age"
                    value={updatedAnimal.age}
                    onChange={handleEditInputChange}
                />
            </label>
            <br />
            <button className='submit' type="submit">Submit</button>
        </form>
        </>
    );
}
  
export default EditAnimalForm;