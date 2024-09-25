import { useState, useEffect } from 'react';
import axios from 'axios';
import './AnimalCard.css';

function AnimalCard({animalId, setSelectedAnimalId}) {
    const [showAnimal, setShowAnimal] = useState({
        name: '',
        species: '',
        age: '',
        dateOfBirth: '',
        ownerId:''
    });

    useEffect(() => {
        axios.get(`http://localhost:5135/api/Animal/${animalId}`)
        .then(response => {
            setShowAnimal(response.data)
        })
        .catch(error => {
            console.error('Error:', error)
        })
    }, [animalId])


return(
    <div className="card">
        <div className="container">
            <h4><b>{showAnimal.name}</b></h4>
            <p>Species: {showAnimal.species}</p>
            <p>Age: {showAnimal.age}</p>
            <p>Date: {showAnimal.dateOfBirth}</p>  
            <p>Owner: {showAnimal.owner ? `${showAnimal.owner.firstName} ${showAnimal.owner.lastName}` : "No Owner"}</p>
        </div>
    </div>
); 
    
}

export default AnimalCard;