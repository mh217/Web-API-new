import './App.css';
import axios from 'axios';
import { useState } from 'react';
import { useEffect } from 'react';
import AnimalTable from './AnimalTable';
import { Link } from 'react-router-dom';

function App() {
  const [animals, setAnimals] = useState([]);
  const [animalList, setAnimalList] = useState([]);
  const [pageNumber, setPageNumber] = useState(1);
  const [rpp, setRpp] = useState(4);
  const [orderBy, setOrderBy] = useState('Name'); 
  const [orderDirection, setOrderDirection] = useState('DESC'); 
  const [animalName, setAnimalName] = useState(''); 
  const [ageMin, setAgeMin] = useState(); 
  const [ageMax, setAgeMax] = useState(); 
  

  useEffect(() => {
    const storedAnimals = JSON.parse(localStorage.getItem('animals'));
    setAnimals(storedAnimals);

  }, []);

  useEffect(() => {
    if(animals.length > 0) {
      localStorage.setItem('animals', JSON.stringify(animals));
    }
  }, [animals]);

  
  useEffect(() => {
    axios
      .get('http://localhost:5135/api/Animal/GetAllAnimals', 
        {params: {animalName, ageMin, ageMax}}) 
      .then(response => {
        let allAnimals = response.data; 
        setAnimalList(allAnimals)
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, [animals, animalName, ageMin, ageMax]);

  useEffect(() => {
    axios
      .get('http://localhost:5135/api/Animal', 
        {params: {orderBy,orderDirection, animalName, ageMin, ageMax, pageNumber, rpp}}) 
      .then(response => {
        let animalData = response.data; 
        if(animalData.length < 1) {
          setAnimals([]); 
        }
        setAnimals(animalData)

      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, [animals,orderBy,orderDirection, animalName,ageMin,ageMax, pageNumber, rpp]);

  const totalPages = Math.ceil(animalList.length / rpp);
  const handlePageChange = (direction) => {
    if (direction === 'next' && pageNumber < totalPages) {
      setPageNumber(prev => prev + 1);
    } else if (direction === 'prev' && pageNumber > 1) {
      setPageNumber(prev => prev - 1);
    }
  };

  const handleFilter = () => {
    setPageNumber(1);
  }

  return (
    <div>
      <select value={orderBy} onChange={e => setOrderBy(e.target.value)}>
          <option value="Name">Name</option>
          <option value="Specise">Species</option>
          <option value="Age">Age</option>
      </select>
      <select value={orderDirection} onChange={e => setOrderDirection(e.target.value)}>
          <option value="DESC">Descending</option>
          <option value="ASC">Ascending</option>
      </select>
      <div>
        <input
            name="name"
            value={animalName}
            onChange={e => {setAnimalName(e.target.value); handleFilter();}}
            placeholder="Name"
        />
        <input
            name="ageMin"
            type="number"
            value={ageMin}
            onChange={e => {setAgeMin(e.target.value); handleFilter();}}
            placeholder="Minimum age"
            min="0"
        />
        <input
            name="ageMax"
            type="number"
            value={ageMax}
            onChange={e => {setAgeMax(e.target.value); handleFilter()}}
            placeholder="Maximum age"
            min="0"
        />
      </div>
      <AnimalTable animals={animals}/>
      <div className="pagination">
        <button onClick={() => handlePageChange('prev')} disabled={pageNumber === 1}>Previous</button>
        <span> {pageNumber} - {totalPages}</span>
        <button onClick={() => handlePageChange('next')} disabled={pageNumber === totalPages}>Next</button>
      </div>
      <Link to={`/add`}><button className='addAnimalForm'>Add Animals</button></Link>
    </div>
  );
  

}
export default App;

