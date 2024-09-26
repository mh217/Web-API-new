import { useState, useEffect } from 'react';
import './AddAnimalForm.css';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function AddAnimalForm() {
    const navigate = useNavigate(); 
    const [animal, setAnimal] = useState({
        name: '',
        species: '',
        age: '',
        dateOfBirth: '',
        ownerId:''
    });
    const [owners, setOwners] = useState([]);

    useEffect(() => {
        axios
          .get('http://localhost:5135/api/Owner') 
          .then(response => {
            setOwners(response.data)
          })
          .catch(error => {
            console.error('Error fetching data:', error);
          });
    }, [owners]);

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
        <button className='addAnimalForm' onClick={() => navigate('/')}>Back</button>
        <div className='card'> 
            <div className='container'>
                <h2>Add Animal</h2>
                <input
                    name="name"
                    value={animal.name}
                    onChange={handleChanges}
                    required
                    placeholder="Name"
                />
                <br />
                <input
                    name="species"
                    value={animal.species}
                    onChange={handleChanges}
                    placeholder="Species"
                />
                <br />
                <input
                    name="age"
                    type='number'
                    min = "1"
                    value={animal.age}
                    onChange={handleChanges}
                    placeholder="Age"
                />
                <br />
                <input
                    type='date'
                    name="dateOfBirth"
                    value={animal.dateOfBirth}
                    onChange={handleChanges}
                    placeholder="Date of Birth"
                />
                <br />
                <select name="ownerId" value={animal.ownerId} onChange={handleChanges}>
                    <option value="" disabled hidden>Select Owner</option>
                    {owners.map(owner => (
                        <option key={owner.id} value={owner.id}>
                            {owner.firstName} {owner.lastName}
                        </option>
                    ))}
                </select>
                <br />
                <button className='submit' type="button" onClick={submitChange}>Submit</button>
                <br />
            </div>
        </div>
    </>
    );
}

export default AddAnimalForm;
