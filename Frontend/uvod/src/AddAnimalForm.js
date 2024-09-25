import { useState } from 'react';
import './AddAnimalForm.css';
import axios from 'axios';

function AddAnimalForm({ animals, setAnimals }) {
    const [animal, setAnimal] = useState({
        name: '',
        species: '',
        age: '',
        dateOfBirth: '',
        ownerId:''
    });

    function handleChanges(e) {
        setAnimal({ ...animal, [e.target.name]: e.target.value });
        
    }
    

    function submitChange() {
        const formattedAnimal = {
            ...animal,
            age: animal.age ? parseInt(animal.age) : 1,
        };
        axios.post('http://localhost:5135/api/Animal', formattedAnimal) 
        .then(response => {
            console.log('Product created', response)
            setAnimal({
                name: '',
                species: '',
                age: '',
                dateOfBirth: '',
                ownerId:''
            });
        })
        .catch(error => {
            console.log(error); 
        })  
    }



    return (
        <>
            <h2>Add Animal</h2>
            <label>
                Name:{' '}
                <input
                    name="name"
                    value={animal.name}
                    onChange={handleChanges}
                    required
                />
            </label>
            <br />
            <label>
                Species:{' '}
                <input
                    name="species"
                    value={animal.species}
                    onChange={handleChanges}
                />
            </label>
            <br />
            <label>
                Age:{' '}
                <input
                    name="age"
                    value={animal.age}
                    onChange={handleChanges}
                />
            </label>
            <br />
            <label>
                Date Of Birth:{' '}
                <input
                    type='date'
                    name="dateOfBirth"
                    value={animal.dateOfBirth}
                    onChange={handleChanges}
                />
            </label>
            <br />
            <label>
                Owner:{' '}
                <input
                    name="ownerId"
                    value={animal.ownerId}
                    onChange={handleChanges}
                />
            </label>
            <br />
            <button className='submit' type="button" onClick={submitChange}>Submit</button>
        </>
    );
}

export default AddAnimalForm;
