import './App.css';
import axios from 'axios';
import { useState } from 'react';
import { useEffect } from 'react';
import AddAnimalForm from './AddAnimalForm';
import EditAnimalForm from './EditAnimalForm';
import AnimalTable from './AnimalTable';
import AnimalCard from './AnimalCard';

function App() {
  const [animals, setAnimals] = useState([]);
  const [animalList, setAnimalList] = useState([]);
  const [selectedAnimalId, setSelectedAnimalId] = useState(null);
  const [selectedAnimalIdForMore, setselectedAnimalIdForMore] = useState(null);
  const [pageNumber, setPageNumber] = useState(1);
  const [rpp, setRpp] = useState(4);
  const [orderBy, setOrderBy] = useState('Name'); 
  

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
      .get('http://localhost:5135/api/Animal/GetAllAnimals') 
      .then(response => {
        let allAnimals = response.data; 
        setAnimalList(allAnimals)
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, [animals]);

  useEffect(() => {
    axios
      .get('http://localhost:5135/api/Animal', {params: {orderBy, pageNumber, rpp}}) 
      .then(response => {
        let animalData = response.data; 
        setAnimals(animalData)

      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, [animals,orderBy, pageNumber, rpp]);

  
  

  const totalPages = Math.ceil(animalList.length / rpp);
  const handlePageChange = (direction) => {
    if (direction === 'next' && pageNumber < totalPages) {
      setPageNumber(prev => prev + 1);
    } else if (direction === 'prev' && pageNumber > 1) {
      setPageNumber(prev => prev - 1);
    }
  };
  
  const handleSelectAnimal = (id) => {
    setSelectedAnimalId(id);
  };
  
  const handleSelectedAnimalForMore = (id) => {
    setselectedAnimalIdForMore(id);
  };

  const handleSelectLess = (id) => {
    setselectedAnimalIdForMore(null);
  };


  return (
    <div>
      <select value={orderBy} onChange={e => setOrderBy(e.target.value)}>
          <option value="Name">Name</option>
          <option value="Specise">Species</option>
          <option value="Age">Age</option>
      </select>
      <AnimalTable animals={animals} setAnimals={setAnimals}  onSelectAnimal={handleSelectAnimal} onSelectMore={handleSelectedAnimalForMore} onSelectLess={handleSelectLess}/>
      <div className="pagination">
        <button onClick={() => handlePageChange('prev')} disabled={pageNumber === 1}>Previous</button>
        <span> {pageNumber} - {totalPages}</span>
        <button onClick={() => handlePageChange('next')} disabled={pageNumber === totalPages}>Next</button>
      </div>
      {selectedAnimalIdForMore && <AnimalCard animalId={selectedAnimalIdForMore} setSelectedAnimalId={setselectedAnimalIdForMore} />}
      <AddAnimalForm animals={animals} setAnimals={setAnimals} />
      {selectedAnimalId && <EditAnimalForm animalId={selectedAnimalId} animals={animals} setAnimals={setAnimals} setSelectedAnimalId={setSelectedAnimalId} />}
    </div>
  );
  

}
export default App;
