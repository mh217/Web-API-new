import './App.css';
import { useState } from 'react';
import { useEffect } from 'react';
import AddAnimal from './AddAnimal';
import GetAnimals from './GetAnimals';
import EditAnimal from './EditAnimal';

function App() {
  const [animals, setAnimals] = useState([]);
  const [selectedAnimalId, setSelectedAnimalId] = useState(null);

  useEffect(() => {
    const storedAnimals = JSON.parse(localStorage.getItem('animals'));
    if (storedAnimals) {
      setAnimals(storedAnimals);
    }
  }, []);

  useEffect(() => {
    localStorage.setItem('animals', JSON.stringify(animals));
  }, [animals]);


  const handleSelectAnimal = (id) => {
    setSelectedAnimalId(id);
  };

  return (
    <div>
      <GetAnimals animals={animals} setAnimals={setAnimals}  onSelectAnimal={handleSelectAnimal}/>
      <AddAnimal animals={animals} setAnimals={setAnimals} />
      {selectedAnimalId && <EditAnimal animalId={selectedAnimalId} animals={animals} setAnimals={setAnimals} setSelectedAnimalId={setSelectedAnimalId} />}
    </div>
  );
  

}
export default App;
