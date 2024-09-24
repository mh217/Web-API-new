import './App.css';
import { useState } from 'react';
import { useEffect } from 'react';
import AddAnimalForm from './AddAnimalForm';
import EditAnimalForm from './EditAnimalForm';
import AnimalTable from './AnimalTable';

function App() {
  const [animals, setAnimals] = useState([]);
  const [selectedAnimalId, setSelectedAnimalId] = useState(null);

  useEffect(() => {
    const storedAnimals = JSON.parse(localStorage.getItem('animals'));
    setAnimals(storedAnimals);

  }, []);

  useEffect(() => {
    if(animals.length > 0) {
      localStorage.setItem('animals', JSON.stringify(animals));
    }
  }, [animals]);


  const handleSelectAnimal = (id) => {
    setSelectedAnimalId(id);
  };

  return (
    <div>
      <AnimalTable animals={animals} setAnimals={setAnimals}  onSelectAnimal={handleSelectAnimal}/>
      <AddAnimalForm animals={animals} setAnimals={setAnimals} />
      {selectedAnimalId && <EditAnimalForm animalId={selectedAnimalId} animals={animals} setAnimals={setAnimals} setSelectedAnimalId={setSelectedAnimalId} />}
    </div>
  );
  

}
export default App;
