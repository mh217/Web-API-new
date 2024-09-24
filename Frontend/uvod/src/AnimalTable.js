import './AnimalTable.css';


function AnimalTable({ animals, setAnimals, onSelectAnimal }) {

  function handleDelete(id) {
    const updatedAnimals = animals.filter((animal) => animal.id !== id); 
    setAnimals(updatedAnimals)
  }

    return (
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Species</th>
            <th>Age</th>
            <th>Delete</th>
            <th>Update</th>
          </tr>
        </thead>
        <tbody>
          {animals.map((animal) => {
            return (
              <tr key={animal.id}>
                <td>{animal.name}</td>
                <td>{animal.species}</td>
                <td>{animal.age}</td>
                <td><button type="button" onClick ={() => handleDelete(animal.id)}>Delete</button></td>
                <td><button type="edit" onClick ={() => onSelectAnimal(animal.id)}>Update</button></td>
              </tr>
            );
        })}
        </tbody>
      </table>
    );
}

export default AnimalTable;
