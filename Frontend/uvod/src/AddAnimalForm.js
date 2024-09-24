import { useState } from 'react';
import './AddAnimalForm.css';

function AddAnimalForm({ animals, setAnimals }) {
    const [animal, setAnimal] = useState({});

    function handleChanges(e) {
        setAnimal({ ...animal, [e.target.name]: e.target.value });
    }

    function submitChange() {
        const newAnimal = { ...animal, id: animals.length + 1 }; 
        setAnimals([...animals, newAnimal]);
        setAnimal({ name: '', species: '', age: '' });   
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
            <button className='submit' type="button" onClick={submitChange}>Submit</button>
        </>
    );
}

export default AddAnimalForm;
