import { useState, useEffect } from 'react';
import axios from 'axios';

function EditAnimalForm({ animalId, animals, setAnimals, setSelectedAnimalId }) {
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
        const updatedItem = animals.map((animal) => {
          return animal.id === animalId ? updatedAnimal : animal;
        });
        
        axios.put(`http://localhost:5135/api/Animal/${animalId}`, updatedAnimal)
        .then(response => {
            console.log('Update successfull', response)
            setSelectedAnimalId(null);
        })
        .catch(error => {
            console.log('Error:', error)
        })
        setAnimals(updatedItem);
      }

    return (
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
    );
}
  
export default EditAnimalForm;