import { useState, useEffect } from 'react';
import axios from 'axios';
import './AnimalCard.css';
import { useParams } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

function AnimalCard() {
    const {animalId} = useParams(); 
    const navigate = useNavigate();
    
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
        <>
            <button className='homeBTN' onClick={() => navigate('/')}>Back</button>
            <div className="card">
                <div className="container">
                    <h4><b>{showAnimal.name}</b></h4>
                    <p>Species: {showAnimal.species}</p>
                    <p>Age: {showAnimal.age}</p>
                    <p>Date: {new Date(showAnimal.dateOfBirth).toDateString()}</p>  
                    <p>Owner: {showAnimal.owner ? `${showAnimal.owner.firstName} ${showAnimal.owner.lastName}` : "No Owner"}</p>
                </div>
            </div>
        </>
    ); 
    
}

export default AnimalCard;