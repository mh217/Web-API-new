import { useState, useEffect } from 'react';

function EditAnimalForm({ animalId, animals, setAnimals, setSelectedAnimalId }) {
    const [updatedAnimal, setUpdatedAnimal] = useState({});

    useEffect(() => {
        const animal = animals.find((animal) => animal.id === animalId);
        if (animal) {
            setUpdatedAnimal(animal);
        }
    }, [animalId, animals]);


    function handleEditInputChange(e) {
        setUpdatedAnimal({ ...updatedAnimal, [e.target.name]: e.target.value });
    }

    function handleEditFormSubmit(e) {
        e.preventDefault();
        handleUpdateAnimal(animalId, updatedAnimal);
        setSelectedAnimalId(null);
      }

    function handleUpdateAnimal(animalId, updatedAnimal) {
        const updatedItem = animals.map((animal) => {
          return animal.id === animalId ? updatedAnimal : animal;
        });
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